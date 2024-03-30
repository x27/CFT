namespace CFT
{
    partial class DebugLogsFilteringForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDebugLogFilename = new System.Windows.Forms.TextBox();
            this.btnDebugLogFileSelect = new System.Windows.Forms.Button();
            this.cbInsertSpaceLine = new System.Windows.Forms.CheckBox();
            this.nudTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(25, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(380, 165);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(134, 32);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Processing";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Debug Log File:";
            // 
            // tbDebugLogFilename
            // 
            this.tbDebugLogFilename.Enabled = false;
            this.tbDebugLogFilename.Location = new System.Drawing.Point(31, 59);
            this.tbDebugLogFilename.Name = "tbDebugLogFilename";
            this.tbDebugLogFilename.Size = new System.Drawing.Size(443, 25);
            this.tbDebugLogFilename.TabIndex = 7;
            // 
            // btnDebugLogFileSelect
            // 
            this.btnDebugLogFileSelect.Location = new System.Drawing.Point(480, 59);
            this.btnDebugLogFileSelect.Name = "btnDebugLogFileSelect";
            this.btnDebugLogFileSelect.Size = new System.Drawing.Size(34, 25);
            this.btnDebugLogFileSelect.TabIndex = 8;
            this.btnDebugLogFileSelect.Text = "...";
            this.btnDebugLogFileSelect.UseVisualStyleBackColor = true;
            this.btnDebugLogFileSelect.Click += new System.EventHandler(this.btnDebugLogFileSelect_Click);
            // 
            // cbInsertSpaceLine
            // 
            this.cbInsertSpaceLine.AutoSize = true;
            this.cbInsertSpaceLine.Checked = true;
            this.cbInsertSpaceLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInsertSpaceLine.Location = new System.Drawing.Point(67, 104);
            this.cbInsertSpaceLine.Name = "cbInsertSpaceLine";
            this.cbInsertSpaceLine.Size = new System.Drawing.Size(307, 21);
            this.cbInsertSpaceLine.TabIndex = 9;
            this.cbInsertSpaceLine.Text = "Insert space line if interval between events more";
            this.cbInsertSpaceLine.UseVisualStyleBackColor = true;
            this.cbInsertSpaceLine.CheckedChanged += new System.EventHandler(this.cbInsertSpaceLine_CheckedChanged);
            // 
            // nudTime
            // 
            this.nudTime.Location = new System.Drawing.Point(380, 103);
            this.nudTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudTime.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTime.Name = "nudTime";
            this.nudTime.Size = new System.Drawing.Size(94, 25);
            this.nudTime.TabIndex = 10;
            this.nudTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTime.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "µs";
            // 
            // DebugLogsFilteringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(540, 218);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudTime);
            this.Controls.Add(this.cbInsertSpaceLine);
            this.Controls.Add(this.btnDebugLogFileSelect);
            this.Controls.Add(this.tbDebugLogFilename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugLogsFilteringForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debug Logs Filtering";
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDebugLogFilename;
        private System.Windows.Forms.Button btnDebugLogFileSelect;
        private System.Windows.Forms.CheckBox cbInsertSpaceLine;
        private System.Windows.Forms.NumericUpDown nudTime;
        private System.Windows.Forms.Label label2;
    }
}