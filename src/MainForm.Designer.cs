namespace CFT
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miSaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAsProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miExportCFTFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miImportCFTFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddEncryptionMethodRow = new System.Windows.Forms.ToolStripMenuItem();
            this.miMotorolaBPEncryptionMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.miHyteraBPEncryptionMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.miNxdnScramblerMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.miScanners = new System.Windows.Forms.ToolStripMenuItem();
            this.miTools = new System.Windows.Forms.ToolStripMenuItem();
            this.debugLogsFilteringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatusL = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusR = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainToolbar = new System.Windows.Forms.ToolStrip();
            this.tsbNewProject = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenProject = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddEncryptionRow = new System.Windows.Forms.ToolStripDropDownButton();
            this.motorolaBPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hyteraBPBasicPrivacyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nXDNScramblerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDuplicateItem = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUp = new System.Windows.Forms.ToolStripButton();
            this.tsbDown = new System.Windows.Forms.ToolStripButton();
            this.tslScanner = new System.Windows.Forms.ToolStripLabel();
            this.cbScanners = new System.Windows.Forms.ToolStripComboBox();
            this.tslFilter = new System.Windows.Forms.ToolStripLabel();
            this.cbListViewFilter = new System.Windows.Forms.ToolStripComboBox();
            this.listView = new System.Windows.Forms.ListView();
            this.miMotorolaEPEncryptionMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.motorolaEPEnhancedPrivacyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.mainStatus.SuspendLayout();
            this.mainToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miEdit,
            this.miTools,
            this.miHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.mainMenu.Size = new System.Drawing.Size(761, 25);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewProject,
            this.miOpenProject,
            this.toolStripSeparator1,
            this.miSaveProject,
            this.miSaveAsProject,
            this.toolStripSeparator3,
            this.miExportCFTFile,
            this.miImportCFTFile,
            this.toolStripSeparator2,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 19);
            this.miFile.Text = "File";
            // 
            // miNewProject
            // 
            this.miNewProject.Image = global::CFT.Properties.Resources._new;
            this.miNewProject.Name = "miNewProject";
            this.miNewProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.miNewProject.Size = new System.Drawing.Size(166, 22);
            this.miNewProject.Text = "New";
            this.miNewProject.Click += new System.EventHandler(this.miNewProject_Click);
            // 
            // miOpenProject
            // 
            this.miOpenProject.Image = global::CFT.Properties.Resources.open;
            this.miOpenProject.Name = "miOpenProject";
            this.miOpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpenProject.Size = new System.Drawing.Size(166, 22);
            this.miOpenProject.Text = "Open ...";
            this.miOpenProject.Click += new System.EventHandler(this.miOpenProject_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // miSaveProject
            // 
            this.miSaveProject.Image = global::CFT.Properties.Resources.save;
            this.miSaveProject.Name = "miSaveProject";
            this.miSaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miSaveProject.Size = new System.Drawing.Size(166, 22);
            this.miSaveProject.Text = "Save";
            this.miSaveProject.Click += new System.EventHandler(this.miSaveProject_Click);
            // 
            // miSaveAsProject
            // 
            this.miSaveAsProject.Name = "miSaveAsProject";
            this.miSaveAsProject.Size = new System.Drawing.Size(166, 22);
            this.miSaveAsProject.Text = "Save as ...";
            this.miSaveAsProject.Click += new System.EventHandler(this.miSaveAsProject_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(163, 6);
            // 
            // miExportCFTFile
            // 
            this.miExportCFTFile.Name = "miExportCFTFile";
            this.miExportCFTFile.Size = new System.Drawing.Size(166, 22);
            this.miExportCFTFile.Text = "Export CFT file ...";
            this.miExportCFTFile.Click += new System.EventHandler(this.miExportCFTFile_Click);
            // 
            // miImportCFTFile
            // 
            this.miImportCFTFile.Name = "miImportCFTFile";
            this.miImportCFTFile.Size = new System.Drawing.Size(166, 22);
            this.miImportCFTFile.Text = "Import CFT file ...";
            this.miImportCFTFile.Click += new System.EventHandler(this.miImportCFTFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(166, 22);
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miEdit
            // 
            this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddEncryptionMethodRow,
            this.toolStripSeparator6,
            this.miScanners});
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(39, 19);
            this.miEdit.Text = "Edit";
            // 
            // miAddEncryptionMethodRow
            // 
            this.miAddEncryptionMethodRow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMotorolaBPEncryptionMethod,
            this.miMotorolaEPEncryptionMethod,
            this.miHyteraBPEncryptionMethod,
            this.miNxdnScramblerMethod});
            this.miAddEncryptionMethodRow.Name = "miAddEncryptionMethodRow";
            this.miAddEncryptionMethodRow.Size = new System.Drawing.Size(243, 22);
            this.miAddEncryptionMethodRow.Text = "Add Encryption Row";
            // 
            // miMotorolaBPEncryptionMethod
            // 
            this.miMotorolaBPEncryptionMethod.Name = "miMotorolaBPEncryptionMethod";
            this.miMotorolaBPEncryptionMethod.Size = new System.Drawing.Size(255, 22);
            this.miMotorolaBPEncryptionMethod.Text = "Motorola BP (Basic Privacy) ...";
            this.miMotorolaBPEncryptionMethod.Click += new System.EventHandler(this.miMotorolaBPEncryptionMethod_Click);
            // 
            // miHyteraBPEncryptionMethod
            // 
            this.miHyteraBPEncryptionMethod.Name = "miHyteraBPEncryptionMethod";
            this.miHyteraBPEncryptionMethod.Size = new System.Drawing.Size(255, 22);
            this.miHyteraBPEncryptionMethod.Text = "Hytera BP (Basic Privacy) ...";
            this.miHyteraBPEncryptionMethod.Click += new System.EventHandler(this.miHyteraBPEncryptionMethod_Click);
            // 
            // miNxdnScramblerMethod
            // 
            this.miNxdnScramblerMethod.Name = "miNxdnScramblerMethod";
            this.miNxdnScramblerMethod.Size = new System.Drawing.Size(255, 22);
            this.miNxdnScramblerMethod.Text = "NXDN Scrambler ...";
            this.miNxdnScramblerMethod.Click += new System.EventHandler(this.miNxdnScramblerMethod_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(240, 6);
            // 
            // miScanners
            // 
            this.miScanners.Name = "miScanners";
            this.miScanners.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.miScanners.Size = new System.Drawing.Size(243, 22);
            this.miScanners.Text = "Scanners and Licenses ...";
            this.miScanners.Click += new System.EventHandler(this.miScanners_Click);
            // 
            // miTools
            // 
            this.miTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugLogsFilteringToolStripMenuItem});
            this.miTools.Name = "miTools";
            this.miTools.Size = new System.Drawing.Size(46, 19);
            this.miTools.Text = "Tools";
            // 
            // debugLogsFilteringToolStripMenuItem
            // 
            this.debugLogsFilteringToolStripMenuItem.Name = "debugLogsFilteringToolStripMenuItem";
            this.debugLogsFilteringToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.debugLogsFilteringToolStripMenuItem.Text = "Debug Logs Filtering ...";
            this.debugLogsFilteringToolStripMenuItem.Click += new System.EventHandler(this.miDebugLogsFiltering_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(44, 19);
            this.miHelp.Text = "Help";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(119, 22);
            this.miAbout.Text = "About ...";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // mainStatus
            // 
            this.mainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusL,
            this.lblStatusM,
            this.lblStatusR});
            this.mainStatus.Location = new System.Drawing.Point(0, 343);
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Size = new System.Drawing.Size(761, 22);
            this.mainStatus.TabIndex = 1;
            this.mainStatus.Text = "statusStrip1";
            // 
            // lblStatusL
            // 
            this.lblStatusL.Name = "lblStatusL";
            this.lblStatusL.Size = new System.Drawing.Size(0, 17);
            // 
            // lblStatusM
            // 
            this.lblStatusM.Name = "lblStatusM";
            this.lblStatusM.Size = new System.Drawing.Size(746, 17);
            this.lblStatusM.Spring = true;
            // 
            // lblStatusR
            // 
            this.lblStatusR.Name = "lblStatusR";
            this.lblStatusR.Size = new System.Drawing.Size(0, 17);
            // 
            // mainToolbar
            // 
            this.mainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewProject,
            this.tsbOpenProject,
            this.tsbSaveProject,
            this.toolStripSeparator4,
            this.tsbAddEncryptionRow,
            this.tsbDuplicateItem,
            this.tsbDeleteItem,
            this.toolStripSeparator5,
            this.tsbUp,
            this.tsbDown,
            this.tslScanner,
            this.cbScanners,
            this.tslFilter,
            this.cbListViewFilter});
            this.mainToolbar.Location = new System.Drawing.Point(0, 25);
            this.mainToolbar.Name = "mainToolbar";
            this.mainToolbar.Size = new System.Drawing.Size(761, 25);
            this.mainToolbar.TabIndex = 2;
            this.mainToolbar.Text = "toolStrip1";
            // 
            // tsbNewProject
            // 
            this.tsbNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewProject.Image = global::CFT.Properties.Resources._new;
            this.tsbNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewProject.Name = "tsbNewProject";
            this.tsbNewProject.Size = new System.Drawing.Size(23, 22);
            this.tsbNewProject.Text = "New Project";
            this.tsbNewProject.Click += new System.EventHandler(this.miNewProject_Click);
            // 
            // tsbOpenProject
            // 
            this.tsbOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenProject.Image = global::CFT.Properties.Resources.open;
            this.tsbOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenProject.Name = "tsbOpenProject";
            this.tsbOpenProject.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenProject.Text = "Open Project ...";
            this.tsbOpenProject.Click += new System.EventHandler(this.miOpenProject_Click);
            // 
            // tsbSaveProject
            // 
            this.tsbSaveProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveProject.Image = global::CFT.Properties.Resources.save;
            this.tsbSaveProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveProject.Name = "tsbSaveProject";
            this.tsbSaveProject.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveProject.Text = "Save Project";
            this.tsbSaveProject.Click += new System.EventHandler(this.miSaveProject_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAddEncryptionRow
            // 
            this.tsbAddEncryptionRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddEncryptionRow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.motorolaBPToolStripMenuItem,
            this.motorolaEPEnhancedPrivacyToolStripMenuItem,
            this.hyteraBPBasicPrivacyToolStripMenuItem,
            this.nXDNScramblerToolStripMenuItem});
            this.tsbAddEncryptionRow.Image = global::CFT.Properties.Resources.add;
            this.tsbAddEncryptionRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddEncryptionRow.Name = "tsbAddEncryptionRow";
            this.tsbAddEncryptionRow.Size = new System.Drawing.Size(29, 22);
            this.tsbAddEncryptionRow.Text = "Add Encryption Method Row";
            // 
            // motorolaBPToolStripMenuItem
            // 
            this.motorolaBPToolStripMenuItem.Name = "motorolaBPToolStripMenuItem";
            this.motorolaBPToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.motorolaBPToolStripMenuItem.Text = "Motorola BP (Basic Privacy) ...";
            this.motorolaBPToolStripMenuItem.Click += new System.EventHandler(this.miMotorolaBPEncryptionMethod_Click);
            // 
            // hyteraBPBasicPrivacyToolStripMenuItem
            // 
            this.hyteraBPBasicPrivacyToolStripMenuItem.Name = "hyteraBPBasicPrivacyToolStripMenuItem";
            this.hyteraBPBasicPrivacyToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.hyteraBPBasicPrivacyToolStripMenuItem.Text = "Hytera BP (Basic Privacy) ...";
            this.hyteraBPBasicPrivacyToolStripMenuItem.Click += new System.EventHandler(this.miHyteraBPEncryptionMethod_Click);
            // 
            // nXDNScramblerToolStripMenuItem
            // 
            this.nXDNScramblerToolStripMenuItem.Name = "nXDNScramblerToolStripMenuItem";
            this.nXDNScramblerToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.nXDNScramblerToolStripMenuItem.Text = "NXDN Scrambler ...";
            this.nXDNScramblerToolStripMenuItem.Click += new System.EventHandler(this.miNxdnScramblerMethod_Click);
            // 
            // tsbDuplicateItem
            // 
            this.tsbDuplicateItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDuplicateItem.Image = global::CFT.Properties.Resources.duplicate;
            this.tsbDuplicateItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDuplicateItem.Name = "tsbDuplicateItem";
            this.tsbDuplicateItem.Size = new System.Drawing.Size(23, 22);
            this.tsbDuplicateItem.Text = "Duplicate Row";
            this.tsbDuplicateItem.Click += new System.EventHandler(this.tsbDuplicateItem_Click);
            // 
            // tsbDeleteItem
            // 
            this.tsbDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteItem.Image = global::CFT.Properties.Resources.delete;
            this.tsbDeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteItem.Name = "tsbDeleteItem";
            this.tsbDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteItem.Text = "Delete Row";
            this.tsbDeleteItem.Click += new System.EventHandler(this.tsbDeleteItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbUp
            // 
            this.tsbUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUp.Image = global::CFT.Properties.Resources.up;
            this.tsbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUp.Name = "tsbUp";
            this.tsbUp.Size = new System.Drawing.Size(23, 22);
            this.tsbUp.Text = "Move Row Up";
            this.tsbUp.Click += new System.EventHandler(this.tsbUp_Click);
            // 
            // tsbDown
            // 
            this.tsbDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDown.Image = global::CFT.Properties.Resources.down;
            this.tsbDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDown.Name = "tsbDown";
            this.tsbDown.Size = new System.Drawing.Size(23, 22);
            this.tsbDown.Text = "Move Row Down";
            this.tsbDown.Click += new System.EventHandler(this.tsbDown_Click);
            // 
            // tslScanner
            // 
            this.tslScanner.Name = "tslScanner";
            this.tslScanner.Size = new System.Drawing.Size(52, 22);
            this.tslScanner.Text = "Scanner:";
            // 
            // cbScanners
            // 
            this.cbScanners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScanners.Name = "cbScanners";
            this.cbScanners.Size = new System.Drawing.Size(200, 25);
            // 
            // tslFilter
            // 
            this.tslFilter.Name = "tslFilter";
            this.tslFilter.Size = new System.Drawing.Size(36, 22);
            this.tslFilter.Text = "Filter:";
            // 
            // cbListViewFilter
            // 
            this.cbListViewFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListViewFilter.Name = "cbListViewFilter";
            this.cbListViewFilter.Size = new System.Drawing.Size(121, 25);
            this.cbListViewFilter.SelectedIndexChanged += new System.EventHandler(this.cbListViewFilter_SelectedIndexChanged);
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 50);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(761, 293);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.listView.Enter += new System.EventHandler(this.listView_Enter);
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // miMotorolaEPEncryptionMethod
            // 
            this.miMotorolaEPEncryptionMethod.Name = "miMotorolaEPEncryptionMethod";
            this.miMotorolaEPEncryptionMethod.Size = new System.Drawing.Size(255, 22);
            this.miMotorolaEPEncryptionMethod.Text = "Motorola EP (Enhanced Privacy) ...";
            this.miMotorolaEPEncryptionMethod.Click += new System.EventHandler(this.miMotorolaEPEncryptionMethod_Click);
            // 
            // motorolaEPEnhancedPrivacyToolStripMenuItem
            // 
            this.motorolaEPEnhancedPrivacyToolStripMenuItem.Name = "motorolaEPEnhancedPrivacyToolStripMenuItem";
            this.motorolaEPEnhancedPrivacyToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.motorolaEPEnhancedPrivacyToolStripMenuItem.Text = "Motorola EP (Enhanced Privacy) ...";
            this.motorolaEPEnhancedPrivacyToolStripMenuItem.Click += new System.EventHandler(this.miMotorolaEPEncryptionMethod_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 365);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.mainToolbar);
            this.Controls.Add(this.mainStatus);
            this.Controls.Add(this.mainMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.mainStatus.ResumeLayout(false);
            this.mainStatus.PerformLayout();
            this.mainToolbar.ResumeLayout(false);
            this.mainToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNewProject;
        private System.Windows.Forms.ToolStripMenuItem miOpenProject;
        private System.Windows.Forms.ToolStripMenuItem miSaveProject;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miScanners;
        private System.Windows.Forms.StatusStrip mainStatus;
        private System.Windows.Forms.ToolStrip mainToolbar;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ToolStripMenuItem miSaveAsProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miExportCFTFile;
        private System.Windows.Forms.ToolStripMenuItem miImportCFTFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripButton tsbNewProject;
        private System.Windows.Forms.ToolStripButton tsbOpenProject;
        private System.Windows.Forms.ToolStripButton tsbSaveProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbDuplicateItem;
        private System.Windows.Forms.ToolStripButton tsbDeleteItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbUp;
        private System.Windows.Forms.ToolStripButton tsbDown;
        private System.Windows.Forms.ToolStripLabel tslScanner;
        private System.Windows.Forms.ToolStripComboBox cbScanners;
        private System.Windows.Forms.ToolStripLabel tslFilter;
        private System.Windows.Forms.ToolStripComboBox cbListViewFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem miAddEncryptionMethodRow;
        private System.Windows.Forms.ToolStripMenuItem miMotorolaBPEncryptionMethod;
        private System.Windows.Forms.ToolStripMenuItem miHyteraBPEncryptionMethod;
        private System.Windows.Forms.ToolStripMenuItem miNxdnScramblerMethod;
        private System.Windows.Forms.ToolStripMenuItem miTools;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripDropDownButton tsbAddEncryptionRow;
        private System.Windows.Forms.ToolStripMenuItem motorolaBPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hyteraBPBasicPrivacyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nXDNScramblerToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusL;
        private System.Windows.Forms.ToolStripMenuItem debugLogsFilteringToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusM;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusR;
        private System.Windows.Forms.ToolStripMenuItem miMotorolaEPEncryptionMethod;
        private System.Windows.Forms.ToolStripMenuItem motorolaEPEnhancedPrivacyToolStripMenuItem;
    }
}

