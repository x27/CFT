namespace CFT
{
    partial class KeyMappingForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbKey2Map = new System.Windows.Forms.ComboBox();
            this.lblKey2 = new System.Windows.Forms.Label();
            this.cbKey1Map = new System.Windows.Forms.ComboBox();
            this.lblKey1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbKey3Map = new System.Windows.Forms.ComboBox();
            this.lblKey3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblKey3);
            this.groupBox1.Controls.Add(this.cbKey3Map);
            this.groupBox1.Controls.Add(this.cbKey2Map);
            this.groupBox1.Controls.Add(this.lblKey2);
            this.groupBox1.Controls.Add(this.cbKey1Map);
            this.groupBox1.Controls.Add(this.lblKey1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keys";
            // 
            // cbKey2Map
            // 
            this.cbKey2Map.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKey2Map.FormattingEnabled = true;
            this.cbKey2Map.Location = new System.Drawing.Point(109, 70);
            this.cbKey2Map.Name = "cbKey2Map";
            this.cbKey2Map.Size = new System.Drawing.Size(316, 25);
            this.cbKey2Map.TabIndex = 3;
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.Location = new System.Drawing.Point(24, 73);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(67, 17);
            this.lblKey2.TabIndex = 2;
            this.lblKey2.Text = "FUNC+ZIP";
            // 
            // cbKey1Map
            // 
            this.cbKey1Map.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKey1Map.FormattingEnabled = true;
            this.cbKey1Map.Location = new System.Drawing.Point(109, 36);
            this.cbKey1Map.Name = "cbKey1Map";
            this.cbKey1Map.Size = new System.Drawing.Size(316, 25);
            this.cbKey1Map.TabIndex = 1;
            // 
            // lblKey1
            // 
            this.lblKey1.AutoSize = true;
            this.lblKey1.Location = new System.Drawing.Point(24, 39);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(25, 17);
            this.lblKey1.TabIndex = 0;
            this.lblKey1.Text = "ZIP";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(367, 180);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(102, 32);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbKey3Map
            // 
            this.cbKey3Map.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKey3Map.FormattingEnabled = true;
            this.cbKey3Map.Location = new System.Drawing.Point(109, 104);
            this.cbKey3Map.Name = "cbKey3Map";
            this.cbKey3Map.Size = new System.Drawing.Size(316, 25);
            this.cbKey3Map.TabIndex = 4;
            // 
            // lblKey3
            // 
            this.lblKey3.AutoSize = true;
            this.lblKey3.Location = new System.Drawing.Point(24, 107);
            this.lblKey3.Name = "lblKey3";
            this.lblKey3.Size = new System.Drawing.Size(50, 17);
            this.lblKey3.TabIndex = 5;
            this.lblKey3.Text = "RANGE";
            // 
            // KeyMappingForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(484, 224);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyMappingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Key Mapping";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbKey2Map;
        private System.Windows.Forms.Label lblKey2;
        private System.Windows.Forms.ComboBox cbKey1Map;
        private System.Windows.Forms.Label lblKey1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblKey3;
        private System.Windows.Forms.ComboBox cbKey3Map;
    }
}