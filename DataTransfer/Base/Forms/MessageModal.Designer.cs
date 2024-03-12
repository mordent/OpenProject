namespace ThiRA.Base.Forms
{
    partial class MessageModal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageModal));
            this.tableLayoutPanel = new TableLayoutPanel();
            this.textBoxMessage = new TextBox();
            this.textBoxTitle = new TextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.textBoxMessage, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.textBoxTitle, 0, 0);
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Location = new Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new Size(584, 361);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Dock = DockStyle.Fill;
            this.textBoxMessage.Location = new Point(3, 23);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ReadOnly = true;
            this.textBoxMessage.Size = new Size(578, 335);
            this.textBoxMessage.TabIndex = 0;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Dock = DockStyle.Fill;
            this.textBoxTitle.Location = new Point(3, 3);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new Size(578, 23);
            this.textBoxTitle.TabIndex = 1;
            // 
            // MessageModal
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 361);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Name = "MessageModal";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private TextBox textBoxMessage;
        private TextBox textBoxTitle;
    }
}