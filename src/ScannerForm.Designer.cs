namespace CFT
{
    partial class ScannerForm
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
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnLicenses = new System.Windows.Forms.Button();
            this.btnKeyMappings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisplayAdditionalInfo = new System.Windows.Forms.Button();
            this.btnMacAddress = new System.Windows.Forms.Button();
            this.cbMute = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbLedAlertWhile = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Model:";
            // 
            // cbModel
            // 
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(28, 81);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(294, 25);
            this.cbModel.TabIndex = 1;
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(25, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 17);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(28, 29);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(294, 25);
            this.tbName.TabIndex = 3;
            // 
            // btnLicenses
            // 
            this.btnLicenses.Location = new System.Drawing.Point(19, 34);
            this.btnLicenses.Name = "btnLicenses";
            this.btnLicenses.Size = new System.Drawing.Size(257, 33);
            this.btnLicenses.TabIndex = 4;
            this.btnLicenses.Text = "Licenses ...";
            this.btnLicenses.UseVisualStyleBackColor = true;
            this.btnLicenses.Click += new System.EventHandler(this.btnLicenses_Click);
            // 
            // btnKeyMappings
            // 
            this.btnKeyMappings.Location = new System.Drawing.Point(19, 84);
            this.btnKeyMappings.Name = "btnKeyMappings";
            this.btnKeyMappings.Size = new System.Drawing.Size(257, 33);
            this.btnKeyMappings.TabIndex = 5;
            this.btnKeyMappings.Text = "Key Mapping ...";
            this.btnKeyMappings.UseVisualStyleBackColor = true;
            this.btnKeyMappings.Click += new System.EventHandler(this.btnKeyMappings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbLedAlertWhile);
            this.groupBox1.Controls.Add(this.btnDisplayAdditionalInfo);
            this.groupBox1.Controls.Add(this.btnMacAddress);
            this.groupBox1.Controls.Add(this.cbMute);
            this.groupBox1.Controls.Add(this.btnKeyMappings);
            this.groupBox1.Controls.Add(this.btnLicenses);
            this.groupBox1.Location = new System.Drawing.Point(29, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 304);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btnDisplayAdditionalInfo
            // 
            this.btnDisplayAdditionalInfo.Location = new System.Drawing.Point(19, 180);
            this.btnDisplayAdditionalInfo.Name = "btnDisplayAdditionalInfo";
            this.btnDisplayAdditionalInfo.Size = new System.Drawing.Size(257, 33);
            this.btnDisplayAdditionalInfo.TabIndex = 8;
            this.btnDisplayAdditionalInfo.Text = "Display Additional Info ...";
            this.btnDisplayAdditionalInfo.UseVisualStyleBackColor = true;
            this.btnDisplayAdditionalInfo.Click += new System.EventHandler(this.btnDisplayAdditionalInfo_Click);
            // 
            // btnMacAddress
            // 
            this.btnMacAddress.Location = new System.Drawing.Point(19, 132);
            this.btnMacAddress.Name = "btnMacAddress";
            this.btnMacAddress.Size = new System.Drawing.Size(257, 33);
            this.btnMacAddress.TabIndex = 7;
            this.btnMacAddress.Text = "MAC Address ...";
            this.btnMacAddress.UseVisualStyleBackColor = true;
            this.btnMacAddress.Click += new System.EventHandler(this.btnMacAddress_Click);
            // 
            // cbMute
            // 
            this.cbMute.AutoSize = true;
            this.cbMute.Location = new System.Drawing.Point(19, 231);
            this.cbMute.Name = "cbMute";
            this.cbMute.Size = new System.Drawing.Size(193, 21);
            this.cbMute.TabIndex = 6;
            this.cbMute.Text = "Mute Encrypted Voice Traffic";
            this.cbMute.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(220, 435);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(102, 32);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(28, 435);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbLedAlertWhile
            // 
            this.cbLedAlertWhile.AutoSize = true;
            this.cbLedAlertWhile.Location = new System.Drawing.Point(19, 258);
            this.cbLedAlertWhile.Name = "cbLedAlertWhile";
            this.cbLedAlertWhile.Size = new System.Drawing.Size(220, 21);
            this.cbLedAlertWhile.TabIndex = 9;
            this.cbLedAlertWhile.Text = "LED alert while the voice goes on";
            this.cbLedAlertWhile.UseVisualStyleBackColor = true;
            // 
            // ScannerForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 490);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScannerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scanner";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnLicenses;
        private System.Windows.Forms.Button btnKeyMappings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbMute;
        private System.Windows.Forms.Button btnMacAddress;
        private System.Windows.Forms.Button btnDisplayAdditionalInfo;
        private System.Windows.Forms.CheckBox cbLedAlertWhile;
    }
}