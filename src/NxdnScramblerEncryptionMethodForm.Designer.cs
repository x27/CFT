﻿namespace CFT
{
    partial class NxdnScramblerEncryptionMethodForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbFrequency = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudKey = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFrequency = new System.Windows.Forms.CheckBox();
            this.cbForceMute = new System.Windows.Forms.CheckBox();
            this.cbSourceID = new System.Windows.Forms.CheckBox();
            this.tbSourceID = new System.Windows.Forms.TextBox();
            this.tbKeyId = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbKeyId = new System.Windows.Forms.CheckBox();
            this.cbGroupID = new System.Windows.Forms.CheckBox();
            this.tbGroupID = new System.Windows.Forms.TextBox();
            this.tbRAN = new System.Windows.Forms.TextBox();
            this.cbRAN = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudKey)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Frequency, MHz:";
            // 
            // tbFrequency
            // 
            this.tbFrequency.Location = new System.Drawing.Point(29, 38);
            this.tbFrequency.Name = "tbFrequency";
            this.tbFrequency.Size = new System.Drawing.Size(138, 25);
            this.tbFrequency.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Key (1-32767):";
            // 
            // nudKey
            // 
            this.nudKey.Location = new System.Drawing.Point(338, 39);
            this.nudKey.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudKey.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudKey.Name = "nudKey";
            this.nudKey.Size = new System.Drawing.Size(97, 25);
            this.nudKey.TabIndex = 2;
            this.nudKey.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Notes:";
            // 
            // tbNotes
            // 
            this.tbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNotes.Location = new System.Drawing.Point(29, 327);
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(406, 25);
            this.tbNotes.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(29, 371);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(309, 371);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(126, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFrequency);
            this.groupBox1.Controls.Add(this.cbForceMute);
            this.groupBox1.Controls.Add(this.cbSourceID);
            this.groupBox1.Controls.Add(this.tbSourceID);
            this.groupBox1.Controls.Add(this.tbKeyId);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.cbKeyId);
            this.groupBox1.Controls.Add(this.cbGroupID);
            this.groupBox1.Controls.Add(this.tbGroupID);
            this.groupBox1.Controls.Add(this.tbRAN);
            this.groupBox1.Controls.Add(this.cbRAN);
            this.groupBox1.Location = new System.Drawing.Point(29, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 220);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NXDN Activate Options";
            // 
            // cbFrequency
            // 
            this.cbFrequency.AutoSize = true;
            this.cbFrequency.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbFrequency.Location = new System.Drawing.Point(17, 35);
            this.cbFrequency.Name = "cbFrequency";
            this.cbFrequency.Size = new System.Drawing.Size(90, 21);
            this.cbFrequency.TabIndex = 9;
            this.cbFrequency.Text = "Frequency";
            this.cbFrequency.UseVisualStyleBackColor = true;
            this.cbFrequency.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbForceMute
            // 
            this.cbForceMute.AutoSize = true;
            this.cbForceMute.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbForceMute.Location = new System.Drawing.Point(187, 35);
            this.cbForceMute.Name = "cbForceMute";
            this.cbForceMute.Size = new System.Drawing.Size(96, 21);
            this.cbForceMute.TabIndex = 8;
            this.cbForceMute.Text = "Force Mute";
            this.cbForceMute.UseVisualStyleBackColor = true;
            this.cbForceMute.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbSourceID
            // 
            this.cbSourceID.AutoSize = true;
            this.cbSourceID.Location = new System.Drawing.Point(17, 181);
            this.cbSourceID.Name = "cbSourceID";
            this.cbSourceID.Size = new System.Drawing.Size(83, 21);
            this.cbSourceID.TabIndex = 7;
            this.cbSourceID.Text = "Source ID";
            this.cbSourceID.UseVisualStyleBackColor = true;
            this.cbSourceID.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // tbSourceID
            // 
            this.tbSourceID.Enabled = false;
            this.tbSourceID.Location = new System.Drawing.Point(187, 179);
            this.tbSourceID.Name = "tbSourceID";
            this.tbSourceID.Size = new System.Drawing.Size(197, 25);
            this.tbSourceID.TabIndex = 6;
            // 
            // tbKeyId
            // 
            this.tbKeyId.Enabled = false;
            this.tbKeyId.Location = new System.Drawing.Point(187, 140);
            this.tbKeyId.Name = "tbKeyId";
            this.tbKeyId.Size = new System.Drawing.Size(197, 25);
            this.tbKeyId.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(187, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 25);
            this.textBox1.TabIndex = 5;
            // 
            // cbKeyId
            // 
            this.cbKeyId.AutoSize = true;
            this.cbKeyId.Location = new System.Drawing.Point(17, 142);
            this.cbKeyId.Name = "cbKeyId";
            this.cbKeyId.Size = new System.Drawing.Size(64, 21);
            this.cbKeyId.TabIndex = 4;
            this.cbKeyId.Text = "Key ID";
            this.cbKeyId.UseVisualStyleBackColor = true;
            this.cbKeyId.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbGroupID
            // 
            this.cbGroupID.AutoSize = true;
            this.cbGroupID.Location = new System.Drawing.Point(17, 104);
            this.cbGroupID.Name = "cbGroupID";
            this.cbGroupID.Size = new System.Drawing.Size(80, 21);
            this.cbGroupID.TabIndex = 2;
            this.cbGroupID.Text = "Group ID";
            this.cbGroupID.UseVisualStyleBackColor = true;
            this.cbGroupID.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // tbGroupID
            // 
            this.tbGroupID.Location = new System.Drawing.Point(187, 102);
            this.tbGroupID.Name = "tbGroupID";
            this.tbGroupID.Size = new System.Drawing.Size(197, 25);
            this.tbGroupID.TabIndex = 3;
            // 
            // tbRAN
            // 
            this.tbRAN.Location = new System.Drawing.Point(187, 65);
            this.tbRAN.Name = "tbRAN";
            this.tbRAN.Size = new System.Drawing.Size(197, 25);
            this.tbRAN.TabIndex = 1;
            // 
            // cbRAN
            // 
            this.cbRAN.AutoSize = true;
            this.cbRAN.Location = new System.Drawing.Point(17, 67);
            this.cbRAN.Name = "cbRAN";
            this.cbRAN.Size = new System.Drawing.Size(53, 21);
            this.cbRAN.TabIndex = 0;
            this.cbRAN.Text = "RAN";
            this.cbRAN.UseVisualStyleBackColor = true;
            this.cbRAN.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // NxdnScramblerEncryptionMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(468, 423);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFrequency);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NxdnScramblerEncryptionMethodForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NXDN Scrambler Encryption ";
            ((System.ComponentModel.ISupportInitialize)(this.nudKey)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFrequency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbGroupID;
        private System.Windows.Forms.TextBox tbGroupID;
        private System.Windows.Forms.TextBox tbRAN;
        private System.Windows.Forms.CheckBox cbRAN;
        private System.Windows.Forms.TextBox tbKeyId;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox cbKeyId;
        private System.Windows.Forms.CheckBox cbForceMute;
        private System.Windows.Forms.CheckBox cbSourceID;
        private System.Windows.Forms.TextBox tbSourceID;
        private System.Windows.Forms.CheckBox cbFrequency;
    }
}