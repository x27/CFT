namespace CFT
{
    partial class P25ActivateOptionsControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSourceID = new System.Windows.Forms.TextBox();
            this.tbKeyID = new System.Windows.Forms.TextBox();
            this.tbNAC = new System.Windows.Forms.TextBox();
            this.cbSilence = new System.Windows.Forms.CheckBox();
            this.tbGroupID = new System.Windows.Forms.TextBox();
            this.cbGroupID = new System.Windows.Forms.CheckBox();
            this.cbSourceID = new System.Windows.Forms.CheckBox();
            this.cbKeyID = new System.Windows.Forms.CheckBox();
            this.cbNAC = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSourceID);
            this.groupBox1.Controls.Add(this.tbKeyID);
            this.groupBox1.Controls.Add(this.tbNAC);
            this.groupBox1.Controls.Add(this.cbSilence);
            this.groupBox1.Controls.Add(this.tbGroupID);
            this.groupBox1.Controls.Add(this.cbGroupID);
            this.groupBox1.Controls.Add(this.cbSourceID);
            this.groupBox1.Controls.Add(this.cbKeyID);
            this.groupBox1.Controls.Add(this.cbNAC);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 214);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "P25 Activate Options";
            // 
            // tbSourceID
            // 
            this.tbSourceID.Location = new System.Drawing.Point(191, 99);
            this.tbSourceID.Name = "tbSourceID";
            this.tbSourceID.Size = new System.Drawing.Size(179, 25);
            this.tbSourceID.TabIndex = 21;
            // 
            // tbKeyID
            // 
            this.tbKeyID.Location = new System.Drawing.Point(191, 68);
            this.tbKeyID.Name = "tbKeyID";
            this.tbKeyID.Size = new System.Drawing.Size(179, 25);
            this.tbKeyID.TabIndex = 20;
            // 
            // tbNAC
            // 
            this.tbNAC.Location = new System.Drawing.Point(191, 37);
            this.tbNAC.Name = "tbNAC";
            this.tbNAC.Size = new System.Drawing.Size(179, 25);
            this.tbNAC.TabIndex = 19;
            // 
            // cbSilence
            // 
            this.cbSilence.AutoSize = true;
            this.cbSilence.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSilence.Location = new System.Drawing.Point(31, 172);
            this.cbSilence.Name = "cbSilence";
            this.cbSilence.Size = new System.Drawing.Size(68, 21);
            this.cbSilence.TabIndex = 18;
            this.cbSilence.Text = "Silence";
            this.cbSilence.UseVisualStyleBackColor = true;
            this.cbSilence.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // tbGroupID
            // 
            this.tbGroupID.Location = new System.Drawing.Point(191, 133);
            this.tbGroupID.Name = "tbGroupID";
            this.tbGroupID.Size = new System.Drawing.Size(179, 25);
            this.tbGroupID.TabIndex = 13;
            this.tbGroupID.TextChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbGroupID
            // 
            this.cbGroupID.AutoSize = true;
            this.cbGroupID.Location = new System.Drawing.Point(31, 135);
            this.cbGroupID.Name = "cbGroupID";
            this.cbGroupID.Size = new System.Drawing.Size(80, 21);
            this.cbGroupID.TabIndex = 12;
            this.cbGroupID.Text = "Group ID";
            this.cbGroupID.UseVisualStyleBackColor = true;
            this.cbGroupID.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbSourceID
            // 
            this.cbSourceID.AutoSize = true;
            this.cbSourceID.Location = new System.Drawing.Point(31, 104);
            this.cbSourceID.Name = "cbSourceID";
            this.cbSourceID.Size = new System.Drawing.Size(83, 21);
            this.cbSourceID.TabIndex = 10;
            this.cbSourceID.Text = "Source ID";
            this.cbSourceID.UseVisualStyleBackColor = true;
            this.cbSourceID.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbKeyID
            // 
            this.cbKeyID.AutoSize = true;
            this.cbKeyID.Location = new System.Drawing.Point(31, 72);
            this.cbKeyID.Name = "cbKeyID";
            this.cbKeyID.Size = new System.Drawing.Size(64, 21);
            this.cbKeyID.TabIndex = 6;
            this.cbKeyID.Text = "Key ID";
            this.cbKeyID.UseVisualStyleBackColor = true;
            this.cbKeyID.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbNAC
            // 
            this.cbNAC.AutoSize = true;
            this.cbNAC.Location = new System.Drawing.Point(31, 41);
            this.cbNAC.Name = "cbNAC";
            this.cbNAC.Size = new System.Drawing.Size(53, 21);
            this.cbNAC.TabIndex = 4;
            this.cbNAC.Text = "NAC";
            this.cbNAC.UseVisualStyleBackColor = true;
            this.cbNAC.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // P25ActivateOptionsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.groupBox1);
            this.Name = "P25ActivateOptionsControl";
            this.Size = new System.Drawing.Size(419, 222);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbGroupID;
        private System.Windows.Forms.CheckBox cbGroupID;
        private System.Windows.Forms.CheckBox cbSourceID;
        private System.Windows.Forms.CheckBox cbKeyID;
        private System.Windows.Forms.CheckBox cbNAC;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox cbSilence;
        private System.Windows.Forms.TextBox tbKeyID;
        private System.Windows.Forms.TextBox tbNAC;
        private System.Windows.Forms.TextBox tbSourceID;
    }
}
