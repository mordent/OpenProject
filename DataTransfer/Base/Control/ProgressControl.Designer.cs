namespace ThiRA.Base.Control
{
    partial class ProgressControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelBack = new TableLayoutPanel();
            this.tableLayoutPanel = new TableLayoutPanel();
            this.buttonClose = new Button();
            this.progressBar = new ProgressBar();
            this.labelTitle = new Label();
            this.labelProgress = new Label();
            this.richTextBoxMessage = new RichTextBox();
            this.tableLayoutPanelBack.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelBack
            // 
            this.tableLayoutPanelBack.ColumnCount = 3;
            this.tableLayoutPanelBack.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelBack.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 315F));
            this.tableLayoutPanelBack.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelBack.Controls.Add(this.tableLayoutPanel, 1, 1);
            this.tableLayoutPanelBack.Dock = DockStyle.Fill;
            this.tableLayoutPanelBack.Location = new Point(0, 0);
            this.tableLayoutPanelBack.Name = "tableLayoutPanelBack";
            this.tableLayoutPanelBack.RowCount = 3;
            this.tableLayoutPanelBack.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelBack.RowStyles.Add(new RowStyle(SizeType.Absolute, 280F));
            this.tableLayoutPanelBack.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanelBack.Size = new Size(600, 400);
            this.tableLayoutPanelBack.TabIndex = 2;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = SystemColors.Window;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            this.tableLayoutPanel.Controls.Add(this.buttonClose, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.progressBar, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProgress, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.richTextBoxMessage, 0, 3);
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Location = new Point(145, 63);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new Size(309, 274);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = DockStyle.Fill;
            this.buttonClose.Enabled = false;
            this.buttonClose.Location = new Point(3, 243);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new Size(303, 28);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "닫기";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = SystemColors.Window;
            this.progressBar.Dock = DockStyle.Fill;
            this.progressBar.Location = new Point(3, 33);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new Size(303, 24);
            this.progressBar.TabIndex = 3;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = SystemColors.Window;
            this.labelTitle.BorderStyle = BorderStyle.FixedSingle;
            this.labelTitle.Dock = DockStyle.Fill;
            this.labelTitle.Location = new Point(3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new Size(303, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.BorderStyle = BorderStyle.FixedSingle;
            this.labelProgress.Dock = DockStyle.Fill;
            this.labelProgress.Location = new Point(3, 60);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new Size(303, 30);
            this.labelProgress.TabIndex = 6;
            this.labelProgress.Text = "0/100";
            this.labelProgress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.Dock = DockStyle.Fill;
            this.richTextBoxMessage.Location = new Point(3, 93);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.ReadOnly = true;
            this.richTextBoxMessage.Size = new Size(303, 144);
            this.richTextBoxMessage.TabIndex = 7;
            this.richTextBoxMessage.Text = "";
            // 
            // ProgressControl
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.tableLayoutPanelBack);
            this.Name = "ProgressControl";
            this.Size = new Size(600, 400);
            this.tableLayoutPanelBack.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelBack;
        private TableLayoutPanel tableLayoutPanel;
        private ProgressBar progressBar;
        private Label labelTitle;
        private Button buttonClose;
        private Label labelProgress;
        private RichTextBox richTextBoxMessage;
    }
}
