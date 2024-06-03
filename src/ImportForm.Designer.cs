namespace CFT
{
    partial class ImportForm
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
            this.lvImport = new System.Windows.Forms.ListView();
            this.colCheck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFreq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOptions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpBatch = new System.Windows.Forms.GroupBox();
            this.btBatchSet = new System.Windows.Forms.Button();
            this.tbEncryptionMethodInfo = new System.Windows.Forms.TextBox();
            this.btnSelectEncryptionMethodOptions = new System.Windows.Forms.Button();
            this.cbEncryptionMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btImport = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.gpBatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvImport
            // 
            this.lvImport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvImport.CheckBoxes = true;
            this.lvImport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCheck,
            this.colFreq,
            this.coNote,
            this.colOptions});
            this.lvImport.FullRowSelect = true;
            this.lvImport.HideSelection = false;
            this.lvImport.Location = new System.Drawing.Point(12, 162);
            this.lvImport.Name = "lvImport";
            this.lvImport.ShowGroups = false;
            this.lvImport.Size = new System.Drawing.Size(591, 215);
            this.lvImport.TabIndex = 0;
            this.lvImport.UseCompatibleStateImageBehavior = false;
            this.lvImport.View = System.Windows.Forms.View.Details;
            // 
            // colCheck
            // 
            this.colCheck.Text = "";
            this.colCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCheck.Width = 37;
            // 
            // colFreq
            // 
            this.colFreq.Text = "Frequency";
            this.colFreq.Width = 140;
            // 
            // coNote
            // 
            this.coNote.Text = "Note";
            this.coNote.Width = 204;
            // 
            // colOptions
            // 
            this.colOptions.Text = "Options";
            this.colOptions.Width = 301;
            // 
            // gpBatch
            // 
            this.gpBatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpBatch.Controls.Add(this.btBatchSet);
            this.gpBatch.Controls.Add(this.tbEncryptionMethodInfo);
            this.gpBatch.Controls.Add(this.btnSelectEncryptionMethodOptions);
            this.gpBatch.Controls.Add(this.cbEncryptionMethod);
            this.gpBatch.Controls.Add(this.label1);
            this.gpBatch.Location = new System.Drawing.Point(12, 12);
            this.gpBatch.Name = "gpBatch";
            this.gpBatch.Size = new System.Drawing.Size(706, 134);
            this.gpBatch.TabIndex = 1;
            this.gpBatch.TabStop = false;
            this.gpBatch.Text = "Batch Properties";
            // 
            // btBatchSet
            // 
            this.btBatchSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btBatchSet.Location = new System.Drawing.Point(558, 88);
            this.btBatchSet.Name = "btBatchSet";
            this.btBatchSet.Size = new System.Drawing.Size(129, 33);
            this.btBatchSet.TabIndex = 4;
            this.btBatchSet.Text = "Batch Set";
            this.btBatchSet.UseVisualStyleBackColor = true;
            this.btBatchSet.Click += new System.EventHandler(this.btBatchSet_Click);
            // 
            // tbEncryptionMethodInfo
            // 
            this.tbEncryptionMethodInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEncryptionMethodInfo.Location = new System.Drawing.Point(21, 93);
            this.tbEncryptionMethodInfo.Name = "tbEncryptionMethodInfo";
            this.tbEncryptionMethodInfo.ReadOnly = true;
            this.tbEncryptionMethodInfo.Size = new System.Drawing.Size(524, 25);
            this.tbEncryptionMethodInfo.TabIndex = 3;
            // 
            // btnSelectEncryptionMethodOptions
            // 
            this.btnSelectEncryptionMethodOptions.Location = new System.Drawing.Point(383, 56);
            this.btnSelectEncryptionMethodOptions.Name = "btnSelectEncryptionMethodOptions";
            this.btnSelectEncryptionMethodOptions.Size = new System.Drawing.Size(41, 27);
            this.btnSelectEncryptionMethodOptions.TabIndex = 2;
            this.btnSelectEncryptionMethodOptions.Text = "...";
            this.btnSelectEncryptionMethodOptions.UseVisualStyleBackColor = true;
            this.btnSelectEncryptionMethodOptions.Click += new System.EventHandler(this.btnSelectEncryptionMethodOptions_Click);
            // 
            // cbEncryptionMethod
            // 
            this.cbEncryptionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEncryptionMethod.FormattingEnabled = true;
            this.cbEncryptionMethod.Location = new System.Drawing.Point(21, 56);
            this.cbEncryptionMethod.Name = "cbEncryptionMethod";
            this.cbEncryptionMethod.Size = new System.Drawing.Size(350, 25);
            this.cbEncryptionMethod.TabIndex = 1;
            this.cbEncryptionMethod.SelectedIndexChanged += new System.EventHandler(this.cbEncryptionMethod_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encryption method:";
            // 
            // btImport
            // 
            this.btImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btImport.Location = new System.Drawing.Point(589, 399);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(129, 33);
            this.btImport.TabIndex = 5;
            this.btImport.Text = "Import";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(12, 399);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(129, 33);
            this.btClose.TabIndex = 6;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Location = new System.Drawing.Point(621, 162);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(97, 33);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeselectAll.Location = new System.Drawing.Point(621, 201);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(97, 33);
            this.btnDeselectAll.TabIndex = 7;
            this.btnDeselectAll.Text = "Deselect All";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(735, 452);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.gpBatch);
            this.Controls.Add(this.lvImport);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(632, 338);
            this.Name = "ImportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Frequencies";
            this.gpBatch.ResumeLayout(false);
            this.gpBatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvImport;
        private System.Windows.Forms.ColumnHeader colFreq;
        private System.Windows.Forms.ColumnHeader coNote;
        private System.Windows.Forms.ColumnHeader colOptions;
        private System.Windows.Forms.GroupBox gpBatch;
        private System.Windows.Forms.Button btnSelectEncryptionMethodOptions;
        private System.Windows.Forms.ComboBox cbEncryptionMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBatchSet;
        private System.Windows.Forms.TextBox tbEncryptionMethodInfo;
        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ColumnHeader colCheck;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnDeselectAll;
    }
}