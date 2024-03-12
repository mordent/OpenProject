using System.Data;
using System.Text;
using ThiRA.Base.BackGround;
using ThiRA.Base.DB;
using ThiRA.Base.Forms;
using ThiRA.Base.Infos;
using ThiRA.Base.Initialize;
using ThiRA.Base.Util;
using ThiRA.Datatransfer.DataBase;

namespace ThiRA.DataTransfer.Forms
{
    public partial class MainForm : BaseForm
    {
        private bool isChangeSource = false;
        private bool isChangeTarget = false;
        private int limit = 50000;

        public MainForm()
        {
            Initializer.Initialize();
            InitializeComponent();
            SetEvent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            comboBoxSourceDataBaseType.DataSource = Enum.GetNames(typeof(DbmsType)).ToList();
            comboBoxTargetDataBaseType.DataSource = Enum.GetNames(typeof(DbmsType)).ToList();
            LoadSetting();
        }

        #region Event Method
        private void SourceChanged(object? sender, EventArgs e)
        {
            isChangeSource = true;
        }

        private void TargetChanged(object? sender, EventArgs e)
        {
            isChangeTarget = true;
        }

        private void ButtonSourceScanClick(object? sender, EventArgs e)
        {
            Button? button = sender as Button;
            if (button != null && ValidConnectionInfo(comboBoxSourceDataBaseType, textBoxSourceConnectionString))
            {
                BaseBackGroundWorker worker = new BaseBackGroundWorker(TableSelectAndLoadBegin, TableSelectAndLoadComplete);
                SetParameter(worker.Work.Parameters, button);
                worker.RunWorkerAsync();
            }
        }

        private void ButtonTargetScanClick(object? sender, EventArgs e)
        {
            Button? button = sender as Button;
            if (button != null && ValidConnectionInfo(comboBoxTargetDataBaseType, textBoxTargetConnectionString))
            {
                BaseBackGroundWorker worker = new BaseBackGroundWorker(TableSelectAndLoadBegin, TableSelectAndLoadComplete);
                SetParameter(worker.Work.Parameters, button);
                worker.RunWorkerAsync();
            }
        }

        private void PreScanCellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataGridView? dataGridView = sender as DataGridView;
            if (dataGridView != null && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                string flag = GetFlag(dataGridView);
                bool isSource = flag.Equals("Source");
                string dataBaseType = (string)dataGridView.Rows[e.RowIndex].Cells[0].Value;
                string connectionString = (string)dataGridView.Rows[e.RowIndex].Cells[1].Value;
                if (ValidationPreScan(isSource, dataBaseType, connectionString))
                {
                    switch (flag)
                    {
                        case "Source": SetPreScan(comboBoxSourceDataBaseType, dataBaseType, textBoxSourceConnectionString, connectionString); break;
                        default: SetPreScan(comboBoxTargetDataBaseType, dataBaseType, textBoxTargetConnectionString, connectionString); break;
                    }
                }
            }
        }

        private void HeaderDoubleClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView? dataGridView = sender as DataGridView;
            if (dataGridView == null)
            {
                return;
            }
            BaseBackGroundWorker baseBackGroundWorker = new BaseBackGroundWorker(HeaderDoubleClickBegin, (work) => { dataGridView.DataSource = work.Result; });
            baseBackGroundWorker.Work.Result = dataGridView.DataSource;
            baseBackGroundWorker.RunWorkerAsync();
        }


        private void ButtonTransferClick(object? sender, EventArgs e)
        {
            DataTable sourceTableDataTable = (DataTable)dataGridViewSourceTable.DataSource;
            DataTable targetTableDataTable = (DataTable)dataGridViewTargetTable.DataSource;
            List<string>? list = ValidationTableInfo(sourceTableDataTable, targetTableDataTable);
            if (list == null || list.Count <= 0)
            {
                return;
            }
            BaseBackGroundWorker worker = new BaseBackGroundWorker(TransferDataBegin, TransferProgressChangeAction, TransferDataComplete);
            worker.Work.Atttributes.Add("List", list);
            SetParameter(worker.Work.Parameters);
            worker.RunWorkerAsync();
        }
        #endregion Event Method

        #region WorkMethod
        private void TableSelectAndLoadBegin(WorkInfo work)
        {
            switch (work.Parameters["Flag"])
            {
                case "Source": TableInfoSelect(work, work.Parameters["DataBaseType"], work.Parameters["ConnectionString"]); break;
                default: TableInfoSelect(work, work.Parameters["DataBaseType"], work.Parameters["ConnectionString"]); break;
            }
        }
        private void TableSelectAndLoadComplete(WorkInfo work)
        {
            switch (work.Parameters["Flag"])
            {
                case "Source": LoadAndSaveSetting(work, comboBoxSourceDataBaseType, textBoxSourceConnectionString, dataGridViewSourceTable, dataGridViewSourcePreScan); isChangeSource = false; break;
                default: LoadAndSaveSetting(work, comboBoxTargetDataBaseType, textBoxTargetConnectionString, dataGridViewTargetTable, dataGridViewTargetPreScan); isChangeTarget = false; break;
            }
        }

        private void HeaderDoubleClickBegin(WorkInfo work)
        {
            if (work.Result == null)
            {
                return;
            }
            DataTable? sourceDataTable = (DataTable)work.Result;
            DataTable targetDataTable = sourceDataTable.Copy();
            if (targetDataTable.Columns.Contains("IS_SELECT"))
            {
                DataColumn? dataColumn = targetDataTable.Columns["IS_SELECT"];
                if (dataColumn != null)
                {
                    dataColumn.ReadOnly = false;
                }
            }
            else
            {
                targetDataTable.Columns.Add("IS_SELECT");
            }
            foreach (DataRow dataRow in targetDataTable.Rows)
            {
                if (dataRow["IS_SELECT"] == null || dataRow["IS_SELECT"] == DBNull.Value || "0".Equals(dataRow["IS_SELECT"]))
                {
                    dataRow["IS_SELECT"] = "1";
                }
                else
                {
                    dataRow["IS_SELECT"] = "0";
                }
            }
            work.Result = targetDataTable;
        }

        private void TransferDataBegin(WorkInfo work)
        {
            logger.Debug("TransferDataBegin Start");
            RemoveEvent();
            List<string> list = (List<string>)work.Atttributes["List"];
            work.Title = "테이블 " + list.Count + "개에 대한 Data 이전 시작  ";
            work.Maximum = list.Count;
            ShowProgress(work);
            StringBuilder message = new StringBuilder();
            string flag = string.Empty;
            foreach (string tableName in list)
            {
                using (DbManager sourceDbManager = GetDbManager(work.Parameters["SourceDataBaseType"], work.Parameters["SourceConnectionString"]), targetDbManager = GetDbManager(work.Parameters["TargetDataBaseType"], work.Parameters["TargetConnectionString"]))
                {
                    message.Append(tableName).Append(" Transfer Strart");
                    work.Info(message.ToString()); logger.Debug(message); message.Clear();
                    ChangeProgress(work);
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("TABLE_NAME", tableName);
                    DataTable sourceColumnDataTable = sourceDbManager.SelectDataTable(SqlUtility.getColumnListSQL(work.Parameters["SourceDataBaseType"]), dictionary);
                    DataTable targetColumnDataTable = targetDbManager.SelectDataTable(SqlUtility.getColumnListSQL(work.Parameters["TargetDataBaseType"]), dictionary);
                    string selectSql = SqlUtility.GetSelectSql(tableName, sourceColumnDataTable);
                    string insertSql = SqlUtility.GetInsertSql(tableName, targetColumnDataTable, targetDbManager);
                    message.Append(tableName).Append(" Select Strart");
                    work.Info(message.ToString()); logger.Debug(message); message.Clear();
                    bool hasNext = true;
                    int loopCount = 1;
                    int startIndex = 0;
                    int endIndex = 0;
                    while (hasNext)
                    {
                        long selectStartTime = CurrentTimeMils;
                        startIndex = ((loopCount - 1) * limit) + 1;
                        endIndex = loopCount * limit;
                        DataTable sourceDataTable = sourceDbManager.SelectDataTable(selectSql, startIndex, endIndex);
                        //DataTable sourceDataTable = sourceDbManager.SelectDataTable(selectSql); hasNext = false;
                        long selectElapse = CurrentTimeMils - selectStartTime;
                        message.Append(tableName).Append(" Select End ").Append(sourceDataTable.Rows.Count).Append(" Rows in ").Append(selectElapse);
                        work.Info(message.ToString()); logger.Debug(message); message.Clear();
                        ChangeProgress(work);
                        message.Append(tableName).Append(" Insert Strart");
                        work.Info(message.ToString()); logger.Debug(message); message.Clear();
                        long insertStartTime = CurrentTimeMils;
                        ulong affectRowCount = targetDbManager.Insert(insertSql, sourceDataTable);
                        long insertElapse = CurrentTimeMils - insertStartTime;
                        if (work.IsError)
                        {
                            flag = "Fail";
                            targetDbManager.Rollback();
                        }
                        else
                        {
                            flag = "Success";
                            targetDbManager.Commit();
                        }
                        message.Append(tableName).Append(" Insert ").Append(affectRowCount).Append(" Rows End in ").Append(insertElapse);
                        work.Info(message.ToString()); logger.Debug(message); message.Clear();
                        loopCount++;
                        if (sourceDataTable.Rows.Count < limit)
                        {
                            hasNext = false;
                        }
                    }
                    work.Progress++;
                    work.ReportProgress();
                    logger.Debug("[{0}] Transfer End", tableName);
                }
            }
            logger.Debug("TransferDataBegin End");
        }

        private void TransferProgressChangeAction(WorkInfo work)
        {
            logger.Debug("TransferProgressChangeAction Start");
            System.GC.Collect();
            ChangeProgress(work);
            logger.Debug("TransferProgressChangeAction End");
        }

        private void TransferDataComplete(WorkInfo work)
        {
            logger.Debug("TransferDataComplete Start");
            CompleteProgress();
            SetEvent();
            logger.Debug("TransferDataComplete End");
        }
        #endregion WorkMethod

        #region private Method
        private string GetFlag(Control? control)
        {
            if (control == null)
            {
                return string.Empty;
            }
            return "Source".Equals(control.Tag.ToString(), StringComparison.OrdinalIgnoreCase) ? "Source" : "Target";
        }

        private DbManager GetDbManager(string dataBaseType, string connectionString)
        {
            return DbManager.GetManager((DbmsType)Enum.Parse(typeof(DbmsType), dataBaseType), connectionString);
        }

        private void SetParameter(Dictionary<string, string> dictionary, Control? control = null)
        {
            dictionary.Add("SourceDataBaseType", (string)comboBoxSourceDataBaseType.SelectedItem);
            dictionary.Add("SourceConnectionString", textBoxSourceConnectionString.Text);
            dictionary.Add("TargetDataBaseType", (string)comboBoxTargetDataBaseType.SelectedItem);
            dictionary.Add("TargetConnectionString", textBoxTargetConnectionString.Text);
            if (control == null)
            {
                return;
            }
            dictionary.Add("Flag", GetFlag(control));
            dictionary.Add("DataBaseType", "Source".Equals(dictionary["Flag"]) ? dictionary["SourceDataBaseType"] : dictionary["TargetDataBaseType"]);
            dictionary.Add("ConnectionString", "Source".Equals(dictionary["Flag"]) ? dictionary["SourceConnectionString"] : dictionary["TargetConnectionString"]);
        }

        private bool ValidConnectionInfo(ComboBox comboBoxDBType, TextBox textBoxConnectionString)
        {
            if (comboBoxDBType.SelectedValue == null)
            {
                MessageBox.Show("DB 종류를 선택하세요.");
                comboBoxDBType.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxConnectionString.Text))
            {
                MessageBox.Show("연결 문자열을 입력하세요.");
                textBoxConnectionString.Focus();
                return false;
            }
            return true;
        }

        private bool ValidationPreScan(bool isSource, string dataBaseType, string connectionString)
        {
            StringBuilder title = new StringBuilder();
            StringBuilder body = new StringBuilder();
            if (isSource)
            {
                title.Append("원본");
                body.Append("원본");
            }
            else
            {
                title.Append("대상");
                body.Append("대상");
            }
            title.Append(" DB 연결 정보 변경");
            body.Append("의 DB Type과 연결 문자열을 ").AppendLine();
            body.Append(dataBaseType).Append("과").AppendLine();
            body.Append(connectionString).AppendLine();
            body.Append("로 변경합니다.");
            if (ControlUtility.Confirm(this, body.ToString(), title.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string>? ValidationTableInfo(DataTable sourceTableDataTable, DataTable targetTableDataTable)
        {
            List<string>? list = null;
            if (sourceTableDataTable == null || sourceTableDataTable.Rows.Count <= 0)
            {
                MessageBox.Show("원본 DB의 테이블을 검색하세요.");
                return list;
            }
            if (targetTableDataTable == null || targetTableDataTable.Rows.Count <= 0)
            {
                MessageBox.Show("대상 DB의 테이블을 검색하세요.");
                return list;
            }
            if (isChangeSource)
            {
                MessageBox.Show("원본 연결 설정이 변경되었습니다. 다시 DB의 테이블을 검색하세요.");
                return list;
            }
            if (isChangeTarget)
            {
                MessageBox.Show("대상 연결 설정이 변경되었습니다. 대상 DB의 테이블을 검색하세요.");
                return list;
            }
            DataRow[] sourceTableDataRow = sourceTableDataTable.Select("IS_SELECT = '1'");
            DataRow[] targetTableDataRow = targetTableDataTable.Select("IS_SELECT = '1'");
            if (sourceTableDataRow == null || sourceTableDataRow.Length <= 0)
            {
                MessageBox.Show("원본 DB에 테이블을 선택하세요.");
                return list;
            }
            if (targetTableDataRow == null || targetTableDataRow.Length <= 0)
            {
                MessageBox.Show("대상 DB에 테이블을 선택하세요.");
                return list;
            }
            List<string> sourceTableList = DataUtility.ToList(sourceTableDataRow, "TABLE_NAME");
            List<string> targetTableList = DataUtility.ToList(targetTableDataRow, "TABLE_NAME");
            list = StringUtility.MergeList(sourceTableList, targetTableList);
            if (list == null || list.Count <= 0)
            {
                MessageBox.Show("대상 원본에 일치하는 테이블이 없습니다.");
                return list;
            }
            return list;
        }

        private void TableInfoSelect(WorkInfo work, string dataBaseType, string connectionString)
        {
            try
            {
                using (DbManager dbManager = GetDbManager(dataBaseType, connectionString))
                {
                    DataTable dataTable = dbManager.SelectDataTable(SqlUtility.GeTableListSQL(dataBaseType));
                    work.Result = dataTable;
                }
            }
            catch (Exception ex)
            {
                work.Error(ex);
                ModalException(ex);
            }
        }
        private void SetEvent()
        {
            dataGridViewSourcePreScan.CellDoubleClick += PreScanCellDoubleClick;
            dataGridViewTargetPreScan.CellDoubleClick += PreScanCellDoubleClick;
            dataGridViewSourceTable.ColumnHeaderMouseDoubleClick += HeaderDoubleClick;
            dataGridViewTargetTable.ColumnHeaderMouseDoubleClick += HeaderDoubleClick;
            comboBoxSourceDataBaseType.TextChanged += SourceChanged;
            comboBoxTargetDataBaseType.TextChanged += TargetChanged;
            textBoxSourceConnectionString.TextChanged += SourceChanged;
            textBoxTargetConnectionString.TextChanged += TargetChanged;
            buttonTransfer.Click += ButtonTransferClick;
            buttonTargetScan.Click += ButtonTargetScanClick;
            buttonSourceScan.Click += ButtonSourceScanClick;
        }

        private void RemoveEvent()
        {
            dataGridViewSourcePreScan.CellDoubleClick -= PreScanCellDoubleClick;
            dataGridViewTargetPreScan.CellDoubleClick -= PreScanCellDoubleClick;
            dataGridViewSourceTable.ColumnHeaderMouseDoubleClick -= HeaderDoubleClick;
            dataGridViewTargetTable.ColumnHeaderMouseDoubleClick -= HeaderDoubleClick;
            comboBoxSourceDataBaseType.TextChanged -= SourceChanged;
            comboBoxTargetDataBaseType.TextChanged -= TargetChanged;
            textBoxSourceConnectionString.TextChanged -= SourceChanged;
            textBoxTargetConnectionString.TextChanged -= TargetChanged;
            buttonTransfer.Click -= ButtonTransferClick;
            buttonTargetScan.Click -= ButtonTargetScanClick;
            buttonSourceScan.Click -= ButtonSourceScanClick;
        }
        private void LoadAndSaveSetting(WorkInfo work, ComboBox comboBoxDBType, TextBox textBoxConnectionString, DataGridView dataGridView, DataGridView dataGridViewPreScan)
        {
            if (work.IsError) { return; }
            try
            {
                string dataBaseType = (string)comboBoxDBType.SelectedItem;
                dataGridView.DataSource = work.Result;
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("DB_TYPE", dataBaseType);
                dictionary.Add("CONNECTION_STRING", textBoxConnectionString.Text);
                DataTable preScanDataTable = (DataTable)dataGridViewPreScan.DataSource;
                dataGridViewPreScan.DataSource = DataUtility.AddRow(preScanDataTable, dictionary, true, 10);
                SaveSetting();
            }
            catch (Exception ex)
            {
                work.Error(ex);
                ModalException(ex);
            }
        }

        private void SetPreScan(ComboBox comboBox, string dataBaseType, TextBox textBox, string connectionString)
        {
            ControlUtility.SetValue(comboBox, dataBaseType);
            textBox.Text = connectionString;
        }

        private void SaveSetting()
        {
            Datatransfer.Properties.Settings.Default.sourceDBType = comboBoxSourceDataBaseType.SelectedValue.ToString();
            Datatransfer.Properties.Settings.Default.sourceDBConnectionString = textBoxSourceConnectionString.Text;
            Datatransfer.Properties.Settings.Default.sourceDBPreScan = MessageUtility.ToJson((DataTable)dataGridViewSourcePreScan.DataSource);
            Datatransfer.Properties.Settings.Default.targetDBType = comboBoxTargetDataBaseType.SelectedValue.ToString();
            Datatransfer.Properties.Settings.Default.targetDBConnectionString = textBoxTargetConnectionString.Text;
            Datatransfer.Properties.Settings.Default.targetDBPreScan = MessageUtility.ToJson((DataTable)dataGridViewTargetPreScan.DataSource);
            Datatransfer.Properties.Settings.Default.isSave = true;
            Datatransfer.Properties.Settings.Default.Save();
        }

        private void LoadSetting()
        {
            if (Datatransfer.Properties.Settings.Default.isSave)
            {
                ControlUtility.SetValue(comboBoxSourceDataBaseType, Datatransfer.Properties.Settings.Default.sourceDBType);
                textBoxSourceConnectionString.Text = Datatransfer.Properties.Settings.Default.sourceDBConnectionString;
                dataGridViewSourcePreScan.DataSource = MessageUtility.JsonToDataTable(Datatransfer.Properties.Settings.Default.sourceDBPreScan);
                ControlUtility.SetValue(comboBoxTargetDataBaseType, Datatransfer.Properties.Settings.Default.targetDBType);
                textBoxTargetConnectionString.Text = Datatransfer.Properties.Settings.Default.targetDBConnectionString;
                dataGridViewTargetPreScan.DataSource = MessageUtility.JsonToDataTable(Datatransfer.Properties.Settings.Default.targetDBPreScan);
            }
        }
        #endregion private method
    }
}
