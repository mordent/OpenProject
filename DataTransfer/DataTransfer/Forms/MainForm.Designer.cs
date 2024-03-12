namespace ThiRA.DataTransfer.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanelMain = new TableLayoutPanel();
            this.tableLayoutPanelSetting = new TableLayoutPanel();
            this.buttonTransfer = new Button();
            this.tableLayoutPanelSourceSetting = new TableLayoutPanel();
            this.labelSourcePreScan = new Label();
            this.labelSourceConnectString = new Label();
            this.comboBoxSourceDataBaseType = new ComboBox();
            this.textBoxSourceConnectionString = new TextBox();
            this.labelSourceDBType = new Label();
            this.buttonSourceScan = new Button();
            this.dataGridViewSourcePreScan = new DataGridView();
            this.DBTypeSource = new DataGridViewTextBoxColumn();
            this.ConnectionStringSource = new DataGridViewTextBoxColumn();
            this.tableLayoutPanelTargetSetting = new TableLayoutPanel();
            this.labelTargetPreScan = new Label();
            this.labelTargetConnectString = new Label();
            this.comboBoxTargetDataBaseType = new ComboBox();
            this.textBoxTargetConnectionString = new TextBox();
            this.labelTargetDBType = new Label();
            this.buttonTargetScan = new Button();
            this.dataGridViewTargetPreScan = new DataGridView();
            this.DBTypeTarget = new DataGridViewTextBoxColumn();
            this.ConnectionStringTarget = new DataGridViewTextBoxColumn();
            this.dataGridViewSourceTable = new DataGridView();
            this.isSelectSource = new DataGridViewCheckBoxColumn();
            this.ownerSource = new DataGridViewTextBoxColumn();
            this.schemaSource = new DataGridViewTextBoxColumn();
            this.tableNameSource = new DataGridViewTextBoxColumn();
            this.dataGridViewTargetTable = new DataGridView();
            this.iSelectTarget = new DataGridViewCheckBoxColumn();
            this.ownerTarget = new DataGridViewTextBoxColumn();
            this.schemaTarget = new DataGridViewTextBoxColumn();
            this.tableNameTarget = new DataGridViewTextBoxColumn();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelSetting.SuspendLayout();
            this.tableLayoutPanelSourceSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewSourcePreScan).BeginInit();
            this.tableLayoutPanelTargetSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewTargetPreScan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewSourceTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewTargetTable).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelSetting, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.dataGridViewSourceTable, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.dataGridViewTargetTable, 1, 1);
            this.tableLayoutPanelMain.Dock = DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F));
            this.tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new Size(1008, 729);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelSetting
            // 
            this.tableLayoutPanelSetting.ColumnCount = 3;
            this.tableLayoutPanelMain.SetColumnSpan(this.tableLayoutPanelSetting, 2);
            this.tableLayoutPanelSetting.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelSetting.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
            this.tableLayoutPanelSetting.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelSetting.Controls.Add(this.buttonTransfer, 1, 0);
            this.tableLayoutPanelSetting.Controls.Add(this.tableLayoutPanelSourceSetting, 0, 0);
            this.tableLayoutPanelSetting.Controls.Add(this.tableLayoutPanelTargetSetting, 2, 0);
            this.tableLayoutPanelSetting.Dock = DockStyle.Fill;
            this.tableLayoutPanelSetting.Location = new Point(3, 3);
            this.tableLayoutPanelSetting.Name = "tableLayoutPanelSetting";
            this.tableLayoutPanelSetting.RowCount = 1;
            this.tableLayoutPanelSetting.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanelSetting.Size = new Size(1002, 244);
            this.tableLayoutPanelSetting.TabIndex = 0;
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Dock = DockStyle.Fill;
            this.buttonTransfer.Image = Datatransfer.Properties.Resources.Arrow_Rignt_disable;
            this.buttonTransfer.Location = new Point(448, 3);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new Size(106, 238);
            this.buttonTransfer.TabIndex = 1;
            this.buttonTransfer.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelSourceSetting
            // 
            this.tableLayoutPanelSourceSetting.ColumnCount = 2;
            this.tableLayoutPanelSourceSetting.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            this.tableLayoutPanelSourceSetting.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanelSourceSetting.Controls.Add(this.labelSourcePreScan, 0, 3);
            this.tableLayoutPanelSourceSetting.Controls.Add(this.labelSourceConnectString, 0, 2);
            this.tableLayoutPanelSourceSetting.Controls.Add(this.comboBoxSourceDataBaseType, 1, 1);
            this.tableLayoutPanelSourceSetting.Controls.Add(this.textBoxSourceConnectionString, 1, 2);
            this.tableLayoutPanelSourceSetting.Controls.Add(this.labelSourceDBType, 0, 1);
            this.tableLayoutPanelSourceSetting.Controls.Add(this.buttonSourceScan, 0, 0);
            this.tableLayoutPanelSourceSetting.Controls.Add(this.dataGridViewSourcePreScan, 1, 3);
            this.tableLayoutPanelSourceSetting.Dock = DockStyle.Fill;
            this.tableLayoutPanelSourceSetting.Location = new Point(3, 3);
            this.tableLayoutPanelSourceSetting.Name = "tableLayoutPanelSourceSetting";
            this.tableLayoutPanelSourceSetting.RowCount = 4;
            this.tableLayoutPanelSourceSetting.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanelSourceSetting.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanelSourceSetting.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.tableLayoutPanelSourceSetting.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanelSourceSetting.Size = new Size(439, 238);
            this.tableLayoutPanelSourceSetting.TabIndex = 2;
            // 
            // labelSourcePreScan
            // 
            this.labelSourcePreScan.AutoSize = true;
            this.labelSourcePreScan.BorderStyle = BorderStyle.FixedSingle;
            this.labelSourcePreScan.Dock = DockStyle.Fill;
            this.labelSourcePreScan.Location = new Point(3, 143);
            this.labelSourcePreScan.Margin = new Padding(3);
            this.labelSourcePreScan.Name = "labelSourcePreScan";
            this.labelSourcePreScan.Size = new Size(74, 92);
            this.labelSourcePreScan.TabIndex = 16;
            this.labelSourcePreScan.Text = "이전 스캔";
            this.labelSourcePreScan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelSourceConnectString
            // 
            this.labelSourceConnectString.AutoSize = true;
            this.labelSourceConnectString.BorderStyle = BorderStyle.FixedSingle;
            this.labelSourceConnectString.Dock = DockStyle.Fill;
            this.labelSourceConnectString.Location = new Point(3, 63);
            this.labelSourceConnectString.Margin = new Padding(3);
            this.labelSourceConnectString.Name = "labelSourceConnectString";
            this.labelSourceConnectString.Size = new Size(74, 74);
            this.labelSourceConnectString.TabIndex = 15;
            this.labelSourceConnectString.Text = "연결 문자열";
            this.labelSourceConnectString.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxSourceDataBaseType
            // 
            this.comboBoxSourceDataBaseType.Dock = DockStyle.Fill;
            this.comboBoxSourceDataBaseType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxSourceDataBaseType.FormattingEnabled = true;
            this.comboBoxSourceDataBaseType.Location = new Point(83, 33);
            this.comboBoxSourceDataBaseType.Name = "comboBoxSourceDataBaseType";
            this.comboBoxSourceDataBaseType.Size = new Size(353, 23);
            this.comboBoxSourceDataBaseType.TabIndex = 0;
            this.comboBoxSourceDataBaseType.Tag = "Source";
            // 
            // textBoxSourceConnectionString
            // 
            this.textBoxSourceConnectionString.Dock = DockStyle.Fill;
            this.textBoxSourceConnectionString.Location = new Point(83, 63);
            this.textBoxSourceConnectionString.Multiline = true;
            this.textBoxSourceConnectionString.Name = "textBoxSourceConnectionString";
            this.textBoxSourceConnectionString.Size = new Size(353, 74);
            this.textBoxSourceConnectionString.TabIndex = 10;
            this.textBoxSourceConnectionString.Tag = "Source";
            this.textBoxSourceConnectionString.Text = resources.GetString("textBoxSourceConnectionString.Text");
            // 
            // labelSourceDBType
            // 
            this.labelSourceDBType.AutoSize = true;
            this.labelSourceDBType.BorderStyle = BorderStyle.FixedSingle;
            this.labelSourceDBType.Dock = DockStyle.Fill;
            this.labelSourceDBType.Location = new Point(3, 33);
            this.labelSourceDBType.Margin = new Padding(3);
            this.labelSourceDBType.Name = "labelSourceDBType";
            this.labelSourceDBType.Size = new Size(74, 24);
            this.labelSourceDBType.TabIndex = 13;
            this.labelSourceDBType.Text = "DB 종류";
            this.labelSourceDBType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonSourceScan
            // 
            this.tableLayoutPanelSourceSetting.SetColumnSpan(this.buttonSourceScan, 2);
            this.buttonSourceScan.Dock = DockStyle.Fill;
            this.buttonSourceScan.Location = new Point(3, 3);
            this.buttonSourceScan.Name = "buttonSourceScan";
            this.buttonSourceScan.Size = new Size(433, 24);
            this.buttonSourceScan.TabIndex = 18;
            this.buttonSourceScan.Tag = "Source";
            this.buttonSourceScan.Text = "원본 DB 테이블 검색";
            this.buttonSourceScan.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSourcePreScan
            // 
            this.dataGridViewSourcePreScan.AllowUserToAddRows = false;
            this.dataGridViewSourcePreScan.AllowUserToDeleteRows = false;
            this.dataGridViewSourcePreScan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSourcePreScan.Columns.AddRange(new DataGridViewColumn[] { this.DBTypeSource, this.ConnectionStringSource });
            this.dataGridViewSourcePreScan.Dock = DockStyle.Fill;
            this.dataGridViewSourcePreScan.Location = new Point(83, 143);
            this.dataGridViewSourcePreScan.Name = "dataGridViewSourcePreScan";
            this.dataGridViewSourcePreScan.ReadOnly = true;
            this.dataGridViewSourcePreScan.RowTemplate.Height = 25;
            this.dataGridViewSourcePreScan.Size = new Size(353, 92);
            this.dataGridViewSourcePreScan.TabIndex = 19;
            this.dataGridViewSourcePreScan.Tag = "Source";
            // 
            // DBTypeSource
            // 
            this.DBTypeSource.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.DBTypeSource.DataPropertyName = "DB_TYPE";
            this.DBTypeSource.Frozen = true;
            this.DBTypeSource.HeaderText = "DB 종류";
            this.DBTypeSource.Name = "DBTypeSource";
            this.DBTypeSource.ReadOnly = true;
            this.DBTypeSource.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.DBTypeSource.Width = 57;
            // 
            // ConnectionStringSource
            // 
            this.ConnectionStringSource.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.ConnectionStringSource.DataPropertyName = "CONNECTION_STRING";
            this.ConnectionStringSource.Frozen = true;
            this.ConnectionStringSource.HeaderText = "연결 문자열";
            this.ConnectionStringSource.Name = "ConnectionStringSource";
            this.ConnectionStringSource.ReadOnly = true;
            this.ConnectionStringSource.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.ConnectionStringSource.Width = 77;
            // 
            // tableLayoutPanelTargetSetting
            // 
            this.tableLayoutPanelTargetSetting.ColumnCount = 2;
            this.tableLayoutPanelTargetSetting.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            this.tableLayoutPanelTargetSetting.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanelTargetSetting.Controls.Add(this.labelTargetPreScan, 0, 3);
            this.tableLayoutPanelTargetSetting.Controls.Add(this.labelTargetConnectString, 0, 2);
            this.tableLayoutPanelTargetSetting.Controls.Add(this.comboBoxTargetDataBaseType, 1, 1);
            this.tableLayoutPanelTargetSetting.Controls.Add(this.textBoxTargetConnectionString, 1, 2);
            this.tableLayoutPanelTargetSetting.Controls.Add(this.labelTargetDBType, 0, 1);
            this.tableLayoutPanelTargetSetting.Controls.Add(this.buttonTargetScan, 0, 0);
            this.tableLayoutPanelTargetSetting.Controls.Add(this.dataGridViewTargetPreScan, 1, 3);
            this.tableLayoutPanelTargetSetting.Dock = DockStyle.Fill;
            this.tableLayoutPanelTargetSetting.Location = new Point(560, 3);
            this.tableLayoutPanelTargetSetting.Name = "tableLayoutPanelTargetSetting";
            this.tableLayoutPanelTargetSetting.RowCount = 4;
            this.tableLayoutPanelTargetSetting.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanelTargetSetting.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanelTargetSetting.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.tableLayoutPanelTargetSetting.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanelTargetSetting.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            this.tableLayoutPanelTargetSetting.Size = new Size(439, 238);
            this.tableLayoutPanelTargetSetting.TabIndex = 3;
            // 
            // labelTargetPreScan
            // 
            this.labelTargetPreScan.AutoSize = true;
            this.labelTargetPreScan.BorderStyle = BorderStyle.FixedSingle;
            this.labelTargetPreScan.Dock = DockStyle.Fill;
            this.labelTargetPreScan.Location = new Point(3, 143);
            this.labelTargetPreScan.Margin = new Padding(3);
            this.labelTargetPreScan.Name = "labelTargetPreScan";
            this.labelTargetPreScan.Size = new Size(74, 92);
            this.labelTargetPreScan.TabIndex = 24;
            this.labelTargetPreScan.Text = "이전 스캔";
            this.labelTargetPreScan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTargetConnectString
            // 
            this.labelTargetConnectString.AutoSize = true;
            this.labelTargetConnectString.BorderStyle = BorderStyle.FixedSingle;
            this.labelTargetConnectString.Dock = DockStyle.Fill;
            this.labelTargetConnectString.Location = new Point(3, 63);
            this.labelTargetConnectString.Margin = new Padding(3);
            this.labelTargetConnectString.Name = "labelTargetConnectString";
            this.labelTargetConnectString.Size = new Size(74, 74);
            this.labelTargetConnectString.TabIndex = 23;
            this.labelTargetConnectString.Text = "연결 문자열";
            this.labelTargetConnectString.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxTargetDataBaseType
            // 
            this.comboBoxTargetDataBaseType.Dock = DockStyle.Fill;
            this.comboBoxTargetDataBaseType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxTargetDataBaseType.FormattingEnabled = true;
            this.comboBoxTargetDataBaseType.Location = new Point(83, 33);
            this.comboBoxTargetDataBaseType.Name = "comboBoxTargetDataBaseType";
            this.comboBoxTargetDataBaseType.Size = new Size(353, 23);
            this.comboBoxTargetDataBaseType.TabIndex = 19;
            this.comboBoxTargetDataBaseType.Tag = "Target";
            // 
            // textBoxTargetConnectionString
            // 
            this.textBoxTargetConnectionString.Dock = DockStyle.Fill;
            this.textBoxTargetConnectionString.Location = new Point(83, 63);
            this.textBoxTargetConnectionString.Multiline = true;
            this.textBoxTargetConnectionString.Name = "textBoxTargetConnectionString";
            this.textBoxTargetConnectionString.Size = new Size(353, 74);
            this.textBoxTargetConnectionString.TabIndex = 20;
            this.textBoxTargetConnectionString.Tag = "Target";
            this.textBoxTargetConnectionString.Text = "Server=open.thirautech.com;Port=35432;Database=postgres;User Id=ky_mes;Password=solution2023!;";
            // 
            // labelTargetDBType
            // 
            this.labelTargetDBType.AutoSize = true;
            this.labelTargetDBType.BorderStyle = BorderStyle.FixedSingle;
            this.labelTargetDBType.Dock = DockStyle.Fill;
            this.labelTargetDBType.Location = new Point(3, 33);
            this.labelTargetDBType.Margin = new Padding(3);
            this.labelTargetDBType.Name = "labelTargetDBType";
            this.labelTargetDBType.Size = new Size(74, 24);
            this.labelTargetDBType.TabIndex = 22;
            this.labelTargetDBType.Text = "DB 종류";
            this.labelTargetDBType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonTargetScan
            // 
            this.tableLayoutPanelTargetSetting.SetColumnSpan(this.buttonTargetScan, 2);
            this.buttonTargetScan.Dock = DockStyle.Fill;
            this.buttonTargetScan.Location = new Point(3, 3);
            this.buttonTargetScan.Name = "buttonTargetScan";
            this.buttonTargetScan.Size = new Size(433, 24);
            this.buttonTargetScan.TabIndex = 26;
            this.buttonTargetScan.Tag = "Target";
            this.buttonTargetScan.Text = "대상 DB 테이블 검색";
            this.buttonTargetScan.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTargetPreScan
            // 
            this.dataGridViewTargetPreScan.AllowUserToAddRows = false;
            this.dataGridViewTargetPreScan.AllowUserToDeleteRows = false;
            this.dataGridViewTargetPreScan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTargetPreScan.Columns.AddRange(new DataGridViewColumn[] { this.DBTypeTarget, this.ConnectionStringTarget });
            this.dataGridViewTargetPreScan.Dock = DockStyle.Fill;
            this.dataGridViewTargetPreScan.Location = new Point(83, 143);
            this.dataGridViewTargetPreScan.Name = "dataGridViewTargetPreScan";
            this.dataGridViewTargetPreScan.ReadOnly = true;
            this.dataGridViewTargetPreScan.RowTemplate.Height = 25;
            this.dataGridViewTargetPreScan.Size = new Size(353, 92);
            this.dataGridViewTargetPreScan.TabIndex = 27;
            this.dataGridViewTargetPreScan.Tag = "Target";
            // 
            // DBTypeTarget
            // 
            this.DBTypeTarget.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.DBTypeTarget.DataPropertyName = "DB_TYPE";
            this.DBTypeTarget.HeaderText = "DB 종류";
            this.DBTypeTarget.Name = "DBTypeTarget";
            this.DBTypeTarget.ReadOnly = true;
            this.DBTypeTarget.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.DBTypeTarget.Width = 57;
            // 
            // ConnectionStringTarget
            // 
            this.ConnectionStringTarget.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.ConnectionStringTarget.DataPropertyName = "CONNECTION_STRING";
            this.ConnectionStringTarget.HeaderText = "연결 문자열";
            this.ConnectionStringTarget.Name = "ConnectionStringTarget";
            this.ConnectionStringTarget.ReadOnly = true;
            this.ConnectionStringTarget.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.ConnectionStringTarget.Width = 77;
            // 
            // dataGridViewSourceTable
            // 
            this.dataGridViewSourceTable.AllowUserToAddRows = false;
            this.dataGridViewSourceTable.AllowUserToDeleteRows = false;
            this.dataGridViewSourceTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSourceTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSourceTable.Columns.AddRange(new DataGridViewColumn[] { this.isSelectSource, this.ownerSource, this.schemaSource, this.tableNameSource });
            this.dataGridViewSourceTable.Dock = DockStyle.Fill;
            this.dataGridViewSourceTable.Location = new Point(3, 253);
            this.dataGridViewSourceTable.Name = "dataGridViewSourceTable";
            this.dataGridViewSourceTable.RowTemplate.Height = 25;
            this.dataGridViewSourceTable.Size = new Size(498, 473);
            this.dataGridViewSourceTable.TabIndex = 2;
            this.dataGridViewSourceTable.Tag = "Source";
            // 
            // isSelectSource
            // 
            this.isSelectSource.DataPropertyName = "IS_SELECT";
            this.isSelectSource.FalseValue = "0";
            this.isSelectSource.HeaderText = "선택";
            this.isSelectSource.Name = "isSelectSource";
            this.isSelectSource.TrueValue = "1";
            this.isSelectSource.Width = 37;
            // 
            // ownerSource
            // 
            this.ownerSource.DataPropertyName = "OWNER";
            this.ownerSource.HeaderText = "사용자";
            this.ownerSource.Name = "ownerSource";
            this.ownerSource.ReadOnly = true;
            this.ownerSource.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.ownerSource.Width = 49;
            // 
            // schemaSource
            // 
            this.schemaSource.DataPropertyName = "SCHEMA";
            this.schemaSource.HeaderText = "SCHEMA";
            this.schemaSource.Name = "schemaSource";
            this.schemaSource.ReadOnly = true;
            this.schemaSource.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.schemaSource.Width = 62;
            // 
            // tableNameSource
            // 
            this.tableNameSource.DataPropertyName = "TABLE_NAME";
            this.tableNameSource.HeaderText = "테이블명";
            this.tableNameSource.Name = "tableNameSource";
            this.tableNameSource.ReadOnly = true;
            this.tableNameSource.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.tableNameSource.Width = 61;
            // 
            // dataGridViewTargetTable
            // 
            this.dataGridViewTargetTable.AllowUserToAddRows = false;
            this.dataGridViewTargetTable.AllowUserToDeleteRows = false;
            this.dataGridViewTargetTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTargetTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTargetTable.Columns.AddRange(new DataGridViewColumn[] { this.iSelectTarget, this.ownerTarget, this.schemaTarget, this.tableNameTarget });
            this.dataGridViewTargetTable.Dock = DockStyle.Fill;
            this.dataGridViewTargetTable.Location = new Point(507, 253);
            this.dataGridViewTargetTable.Name = "dataGridViewTargetTable";
            this.dataGridViewTargetTable.RowTemplate.Height = 25;
            this.dataGridViewTargetTable.Size = new Size(498, 473);
            this.dataGridViewTargetTable.TabIndex = 4;
            this.dataGridViewTargetTable.Tag = "Target";
            // 
            // iSelectTarget
            // 
            this.iSelectTarget.DataPropertyName = "IS_SELECT";
            this.iSelectTarget.FalseValue = "0";
            this.iSelectTarget.HeaderText = "선택";
            this.iSelectTarget.Name = "iSelectTarget";
            this.iSelectTarget.TrueValue = "1";
            this.iSelectTarget.Width = 37;
            // 
            // ownerTarget
            // 
            this.ownerTarget.DataPropertyName = "OWNER";
            this.ownerTarget.HeaderText = "사용자";
            this.ownerTarget.Name = "ownerTarget";
            this.ownerTarget.ReadOnly = true;
            this.ownerTarget.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.ownerTarget.Width = 49;
            // 
            // schemaTarget
            // 
            this.schemaTarget.DataPropertyName = "SCHEMA";
            this.schemaTarget.HeaderText = "SCHEMA";
            this.schemaTarget.Name = "schemaTarget";
            this.schemaTarget.ReadOnly = true;
            this.schemaTarget.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.schemaTarget.Width = 62;
            // 
            // tableNameTarget
            // 
            this.tableNameTarget.DataPropertyName = "TABLE_NAME";
            this.tableNameTarget.HeaderText = "테이블명";
            this.tableNameTarget.Name = "tableNameTarget";
            this.tableNameTarget.ReadOnly = true;
            this.tableNameTarget.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.tableNameTarget.Width = 61;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1008, 729);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Name = "MainForm";
            this.Text = "DataTransfer";
            this.Load += this.FormLoad;
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelSetting.ResumeLayout(false);
            this.tableLayoutPanelSourceSetting.ResumeLayout(false);
            this.tableLayoutPanelSourceSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewSourcePreScan).EndInit();
            this.tableLayoutPanelTargetSetting.ResumeLayout(false);
            this.tableLayoutPanelTargetSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewTargetPreScan).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewSourceTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewTargetTable).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private TableLayoutPanel tableLayoutPanelSetting;
        private DataGridView dataGridViewSourceTable;
        private DataGridView dataGridViewTargetTable;
        private Button buttonTransfer;
        private TableLayoutPanel tableLayoutPanelSourceSetting;
        private TableLayoutPanel tableLayoutPanelTargetSetting;
        private ComboBox comboBoxSourceDataBaseType;
        private TextBox textBoxSourceConnectionString;
        private Label labelSourceDBType;
        private Label labelSourceConnectString;
        private Label labelSourcePreScan;
        private Button buttonSourceScan;
        private Label labelTargetPreScan;
        private Label labelTargetConnectString;
        private ComboBox comboBoxTargetDataBaseType;
        private TextBox textBoxTargetConnectionString;
        private Label labelTargetDBType;
        private Button buttonTargetScan;
        private DataGridView dataGridViewTargetPreScan;
        private DataGridView dataGridViewSourcePreScan;
        private DataGridViewTextBoxColumn DBTypeTarget;
        private DataGridViewTextBoxColumn ConnectionStringTarget;
        private DataGridViewTextBoxColumn DBTypeSource;
        private DataGridViewTextBoxColumn ConnectionStringSource;
        private DataGridViewCheckBoxColumn iSelectTarget;
        private DataGridViewTextBoxColumn ownerTarget;
        private DataGridViewTextBoxColumn schemaTarget;
        private DataGridViewTextBoxColumn tableNameTarget;
        private DataGridViewCheckBoxColumn isSelectSource;
        private DataGridViewTextBoxColumn ownerSource;
        private DataGridViewTextBoxColumn schemaSource;
        private DataGridViewTextBoxColumn tableNameSource;
    }
}
