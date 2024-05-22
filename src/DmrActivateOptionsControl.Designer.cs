namespace CFT
{
    partial class DmrActivateOptionsControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DmrActivateOptionsControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSilence = new System.Windows.Forms.CheckBox();
            this.cbbEncryptionValue = new System.Windows.Forms.ComboBox();
            this.cbbTimeSlot = new System.Windows.Forms.ComboBox();
            this.tbTGID = new System.Windows.Forms.TextBox();
            this.cbbColorCode = new System.Windows.Forms.ComboBox();
            this.cbbMfid = new System.Windows.Forms.ComboBox();
            this.cbbTrunkSystem = new System.Windows.Forms.ComboBox();
            this.cbEncryptionValue = new System.Windows.Forms.CheckBox();
            this.cbTimeSlot = new System.Windows.Forms.CheckBox();
            this.cbTGID = new System.Windows.Forms.CheckBox();
            this.cbColorCode = new System.Windows.Forms.CheckBox();
            this.cbMFID = new System.Windows.Forms.CheckBox();
            this.cbTrunkSystem = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSilence);
            this.groupBox1.Controls.Add(this.cbbEncryptionValue);
            this.groupBox1.Controls.Add(this.cbbTimeSlot);
            this.groupBox1.Controls.Add(this.tbTGID);
            this.groupBox1.Controls.Add(this.cbbColorCode);
            this.groupBox1.Controls.Add(this.cbbMfid);
            this.groupBox1.Controls.Add(this.cbbTrunkSystem);
            this.groupBox1.Controls.Add(this.cbEncryptionValue);
            this.groupBox1.Controls.Add(this.cbTimeSlot);
            this.groupBox1.Controls.Add(this.cbTGID);
            this.groupBox1.Controls.Add(this.cbColorCode);
            this.groupBox1.Controls.Add(this.cbMFID);
            this.groupBox1.Controls.Add(this.cbTrunkSystem);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 268);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DMR Activate Options";
            // 
            // cbSilence
            // 
            this.cbSilence.AutoSize = true;
            this.cbSilence.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSilence.Location = new System.Drawing.Point(31, 230);
            this.cbSilence.Name = "cbSilence";
            this.cbSilence.Size = new System.Drawing.Size(68, 21);
            this.cbSilence.TabIndex = 18;
            this.cbSilence.Text = "Silence";
            this.cbSilence.UseVisualStyleBackColor = true;
            this.cbSilence.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbbEncryptionValue
            // 
            this.cbbEncryptionValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEncryptionValue.FormattingEnabled = true;
            this.cbbEncryptionValue.Location = new System.Drawing.Point(191, 195);
            this.cbbEncryptionValue.Name = "cbbEncryptionValue";
            this.cbbEncryptionValue.Size = new System.Drawing.Size(179, 25);
            this.cbbEncryptionValue.TabIndex = 17;
            this.toolTip.SetToolTip(this.cbbEncryptionValue, resources.GetString("cbbEncryptionValue.ToolTip"));
            this.cbbEncryptionValue.SelectedIndexChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbbTimeSlot
            // 
            this.cbbTimeSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTimeSlot.FormattingEnabled = true;
            this.cbbTimeSlot.Location = new System.Drawing.Point(191, 164);
            this.cbbTimeSlot.Name = "cbbTimeSlot";
            this.cbbTimeSlot.Size = new System.Drawing.Size(179, 25);
            this.cbbTimeSlot.TabIndex = 15;
            this.cbbTimeSlot.SelectedIndexChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // tbTGID
            // 
            this.tbTGID.Location = new System.Drawing.Point(191, 133);
            this.tbTGID.Name = "tbTGID";
            this.tbTGID.Size = new System.Drawing.Size(179, 25);
            this.tbTGID.TabIndex = 13;
            this.tbTGID.TextChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbbColorCode
            // 
            this.cbbColorCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbColorCode.FormattingEnabled = true;
            this.cbbColorCode.Location = new System.Drawing.Point(191, 102);
            this.cbbColorCode.Name = "cbbColorCode";
            this.cbbColorCode.Size = new System.Drawing.Size(179, 25);
            this.cbbColorCode.TabIndex = 11;
            this.cbbColorCode.SelectedIndexChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbbMfid
            // 
            this.cbbMfid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMfid.FormattingEnabled = true;
            this.cbbMfid.Location = new System.Drawing.Point(191, 70);
            this.cbbMfid.Name = "cbbMfid";
            this.cbbMfid.Size = new System.Drawing.Size(179, 25);
            this.cbbMfid.TabIndex = 7;
            this.cbbMfid.SelectedIndexChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbbTrunkSystem
            // 
            this.cbbTrunkSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTrunkSystem.FormattingEnabled = true;
            this.cbbTrunkSystem.Location = new System.Drawing.Point(191, 39);
            this.cbbTrunkSystem.Name = "cbbTrunkSystem";
            this.cbbTrunkSystem.Size = new System.Drawing.Size(179, 25);
            this.cbbTrunkSystem.TabIndex = 5;
            this.cbbTrunkSystem.SelectedIndexChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbEncryptionValue
            // 
            this.cbEncryptionValue.AutoSize = true;
            this.cbEncryptionValue.Location = new System.Drawing.Point(31, 197);
            this.cbEncryptionValue.Name = "cbEncryptionValue";
            this.cbEncryptionValue.Size = new System.Drawing.Size(123, 21);
            this.cbEncryptionValue.TabIndex = 16;
            this.cbEncryptionValue.Text = "Encryption Value";
            this.cbEncryptionValue.UseVisualStyleBackColor = true;
            this.cbEncryptionValue.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbTimeSlot
            // 
            this.cbTimeSlot.AutoSize = true;
            this.cbTimeSlot.Location = new System.Drawing.Point(31, 166);
            this.cbTimeSlot.Name = "cbTimeSlot";
            this.cbTimeSlot.Size = new System.Drawing.Size(81, 21);
            this.cbTimeSlot.TabIndex = 14;
            this.cbTimeSlot.Text = "Time Slot";
            this.cbTimeSlot.UseVisualStyleBackColor = true;
            this.cbTimeSlot.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbTGID
            // 
            this.cbTGID.AutoSize = true;
            this.cbTGID.Location = new System.Drawing.Point(31, 135);
            this.cbTGID.Name = "cbTGID";
            this.cbTGID.Size = new System.Drawing.Size(88, 21);
            this.cbTGID.TabIndex = 12;
            this.cbTGID.Text = "TGID (Dec)";
            this.cbTGID.UseVisualStyleBackColor = true;
            this.cbTGID.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbColorCode
            // 
            this.cbColorCode.AutoSize = true;
            this.cbColorCode.Location = new System.Drawing.Point(31, 104);
            this.cbColorCode.Name = "cbColorCode";
            this.cbColorCode.Size = new System.Drawing.Size(94, 21);
            this.cbColorCode.TabIndex = 10;
            this.cbColorCode.Text = "Color Code";
            this.cbColorCode.UseVisualStyleBackColor = true;
            this.cbColorCode.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbMFID
            // 
            this.cbMFID.AutoSize = true;
            this.cbMFID.Location = new System.Drawing.Point(31, 72);
            this.cbMFID.Name = "cbMFID";
            this.cbMFID.Size = new System.Drawing.Size(57, 21);
            this.cbMFID.TabIndex = 6;
            this.cbMFID.Text = "MFID";
            this.cbMFID.UseVisualStyleBackColor = true;
            this.cbMFID.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbTrunkSystem
            // 
            this.cbTrunkSystem.AutoSize = true;
            this.cbTrunkSystem.Location = new System.Drawing.Point(31, 41);
            this.cbTrunkSystem.Name = "cbTrunkSystem";
            this.cbTrunkSystem.Size = new System.Drawing.Size(103, 21);
            this.cbTrunkSystem.TabIndex = 4;
            this.cbTrunkSystem.Text = "Trunk System";
            this.cbTrunkSystem.UseVisualStyleBackColor = true;
            this.cbTrunkSystem.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // DmrActivateOptionsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.groupBox1);
            this.Name = "DmrActivateOptionsControl";
            this.Size = new System.Drawing.Size(419, 277);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbEncryptionValue;
        private System.Windows.Forms.TextBox tbTGID;
        private System.Windows.Forms.ComboBox cbbColorCode;
        private System.Windows.Forms.ComboBox cbbMfid;
        private System.Windows.Forms.ComboBox cbbTrunkSystem;
        private System.Windows.Forms.CheckBox cbEncryptionValue;
        private System.Windows.Forms.CheckBox cbTGID;
        private System.Windows.Forms.CheckBox cbColorCode;
        private System.Windows.Forms.CheckBox cbMFID;
        private System.Windows.Forms.CheckBox cbTrunkSystem;
        private System.Windows.Forms.ComboBox cbbTimeSlot;
        private System.Windows.Forms.CheckBox cbTimeSlot;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox cbSilence;
    }
}
