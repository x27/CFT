namespace CFT
{
    partial class MacAddressForm
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
            this.tbMAC0 = new System.Windows.Forms.TextBox();
            this.tbMAC1 = new System.Windows.Forms.TextBox();
            this.tbMAC2 = new System.Windows.Forms.TextBox();
            this.tbMAC3 = new System.Windows.Forms.TextBox();
            this.tbMAC4 = new System.Windows.Forms.TextBox();
            this.tbMAC5 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMAC0
            // 
            this.tbMAC0.Location = new System.Drawing.Point(17, 37);
            this.tbMAC0.Name = "tbMAC0";
            this.tbMAC0.ReadOnly = true;
            this.tbMAC0.Size = new System.Drawing.Size(41, 25);
            this.tbMAC0.TabIndex = 2;
            this.tbMAC0.Text = "00";
            this.tbMAC0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMAC1
            // 
            this.tbMAC1.Location = new System.Drawing.Point(64, 37);
            this.tbMAC1.Name = "tbMAC1";
            this.tbMAC1.ReadOnly = true;
            this.tbMAC1.Size = new System.Drawing.Size(41, 25);
            this.tbMAC1.TabIndex = 3;
            this.tbMAC1.Text = "E0";
            this.tbMAC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMAC2
            // 
            this.tbMAC2.Location = new System.Drawing.Point(111, 37);
            this.tbMAC2.Name = "tbMAC2";
            this.tbMAC2.ReadOnly = true;
            this.tbMAC2.Size = new System.Drawing.Size(41, 25);
            this.tbMAC2.TabIndex = 4;
            this.tbMAC2.Text = "11";
            this.tbMAC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMAC3
            // 
            this.tbMAC3.Location = new System.Drawing.Point(158, 37);
            this.tbMAC3.MaxLength = 2;
            this.tbMAC3.Name = "tbMAC3";
            this.tbMAC3.Size = new System.Drawing.Size(41, 25);
            this.tbMAC3.TabIndex = 0;
            this.tbMAC3.Text = "00";
            this.tbMAC3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMAC4
            // 
            this.tbMAC4.Location = new System.Drawing.Point(205, 37);
            this.tbMAC4.MaxLength = 2;
            this.tbMAC4.Name = "tbMAC4";
            this.tbMAC4.Size = new System.Drawing.Size(41, 25);
            this.tbMAC4.TabIndex = 1;
            this.tbMAC4.Text = "00";
            this.tbMAC4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMAC5
            // 
            this.tbMAC5.Location = new System.Drawing.Point(252, 37);
            this.tbMAC5.MaxLength = 2;
            this.tbMAC5.Name = "tbMAC5";
            this.tbMAC5.Size = new System.Drawing.Size(41, 25);
            this.tbMAC5.TabIndex = 2;
            this.tbMAC5.Text = "00";
            this.tbMAC5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMAC5);
            this.groupBox1.Controls.Add(this.tbMAC4);
            this.groupBox1.Controls.Add(this.tbMAC3);
            this.groupBox1.Controls.Add(this.tbMAC2);
            this.groupBox1.Controls.Add(this.tbMAC1);
            this.groupBox1.Controls.Add(this.tbMAC0);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MAC Address";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(221, 109);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(102, 32);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Set";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // MacAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(337, 153);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MacAddressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set MAC Address";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbMAC0;
        private System.Windows.Forms.TextBox tbMAC1;
        private System.Windows.Forms.TextBox tbMAC2;
        private System.Windows.Forms.TextBox tbMAC3;
        private System.Windows.Forms.TextBox tbMAC4;
        private System.Windows.Forms.TextBox tbMAC5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}