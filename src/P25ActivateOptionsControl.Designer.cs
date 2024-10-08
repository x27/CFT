﻿namespace CFT
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
            this.cbFrequency = new System.Windows.Forms.CheckBox();
            this.tbSourceID = new System.Windows.Forms.TextBox();
            this.tbKeyID = new System.Windows.Forms.TextBox();
            this.tbNAC = new System.Windows.Forms.TextBox();
            this.cbForceMute = new System.Windows.Forms.CheckBox();
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
            this.groupBox1.Controls.Add(this.cbFrequency);
            this.groupBox1.Controls.Add(this.tbSourceID);
            this.groupBox1.Controls.Add(this.tbKeyID);
            this.groupBox1.Controls.Add(this.tbNAC);
            this.groupBox1.Controls.Add(this.cbForceMute);
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
            // cbFrequency
            // 
            this.cbFrequency.AutoSize = true;
            this.cbFrequency.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbFrequency.Location = new System.Drawing.Point(31, 42);
            this.cbFrequency.Name = "cbFrequency";
            this.cbFrequency.Size = new System.Drawing.Size(90, 21);
            this.cbFrequency.TabIndex = 22;
            this.cbFrequency.Text = "Frequency";
            this.cbFrequency.UseVisualStyleBackColor = true;
            this.cbFrequency.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // tbSourceID
            // 
            this.tbSourceID.Location = new System.Drawing.Point(191, 132);
            this.tbSourceID.Name = "tbSourceID";
            this.tbSourceID.Size = new System.Drawing.Size(179, 25);
            this.tbSourceID.TabIndex = 21;
            this.tbSourceID.TextChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // tbKeyID
            // 
            this.tbKeyID.Location = new System.Drawing.Point(191, 101);
            this.tbKeyID.Name = "tbKeyID";
            this.tbKeyID.Size = new System.Drawing.Size(179, 25);
            this.tbKeyID.TabIndex = 20;
            this.tbKeyID.TextChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // tbNAC
            // 
            this.tbNAC.Location = new System.Drawing.Point(191, 70);
            this.tbNAC.Name = "tbNAC";
            this.tbNAC.Size = new System.Drawing.Size(179, 25);
            this.tbNAC.TabIndex = 19;
            this.tbNAC.TextChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbForceMute
            // 
            this.cbForceMute.AutoSize = true;
            this.cbForceMute.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbForceMute.Location = new System.Drawing.Point(191, 42);
            this.cbForceMute.Name = "cbForceMute";
            this.cbForceMute.Size = new System.Drawing.Size(96, 21);
            this.cbForceMute.TabIndex = 18;
            this.cbForceMute.Text = "Force Mute";
            this.cbForceMute.UseVisualStyleBackColor = true;
            this.cbForceMute.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // tbGroupID
            // 
            this.tbGroupID.Location = new System.Drawing.Point(191, 166);
            this.tbGroupID.Name = "tbGroupID";
            this.tbGroupID.Size = new System.Drawing.Size(179, 25);
            this.tbGroupID.TabIndex = 13;
            this.tbGroupID.TextChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbGroupID
            // 
            this.cbGroupID.AutoSize = true;
            this.cbGroupID.Location = new System.Drawing.Point(31, 168);
            this.cbGroupID.Name = "cbGroupID";
            this.cbGroupID.Size = new System.Drawing.Size(116, 21);
            this.cbGroupID.TabIndex = 12;
            this.cbGroupID.Text = "Group ID (DEC)";
            this.cbGroupID.UseVisualStyleBackColor = true;
            this.cbGroupID.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbSourceID
            // 
            this.cbSourceID.AutoSize = true;
            this.cbSourceID.Location = new System.Drawing.Point(31, 137);
            this.cbSourceID.Name = "cbSourceID";
            this.cbSourceID.Size = new System.Drawing.Size(119, 21);
            this.cbSourceID.TabIndex = 10;
            this.cbSourceID.Text = "Source ID (DEC)";
            this.cbSourceID.UseVisualStyleBackColor = true;
            this.cbSourceID.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbKeyID
            // 
            this.cbKeyID.AutoSize = true;
            this.cbKeyID.Location = new System.Drawing.Point(31, 105);
            this.cbKeyID.Name = "cbKeyID";
            this.cbKeyID.Size = new System.Drawing.Size(100, 21);
            this.cbKeyID.TabIndex = 6;
            this.cbKeyID.Text = "Key ID (HEX)";
            this.cbKeyID.UseVisualStyleBackColor = true;
            this.cbKeyID.CheckedChanged += new System.EventHandler(this.eventOptionChanged);
            // 
            // cbNAC
            // 
            this.cbNAC.AutoSize = true;
            this.cbNAC.Location = new System.Drawing.Point(31, 74);
            this.cbNAC.Name = "cbNAC";
            this.cbNAC.Size = new System.Drawing.Size(89, 21);
            this.cbNAC.TabIndex = 4;
            this.cbNAC.Text = "NAC (HEX)";
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
        private System.Windows.Forms.CheckBox cbForceMute;
        private System.Windows.Forms.TextBox tbKeyID;
        private System.Windows.Forms.TextBox tbNAC;
        private System.Windows.Forms.TextBox tbSourceID;
        private System.Windows.Forms.CheckBox cbFrequency;
    }
}
