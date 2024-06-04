using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CFT
{
    public partial class MainForm : Form
    {
        string TITLE = "Custom Firmware Tuner";
        private FileVersionInfo _versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

        private Project _project;
        private Project _projectCopy;

        private SortOrder _colFreqSortOrder = SortOrder.None;

        private string _lateLoadFile;

        public MainForm(string lateLoadFile = null)
        {
            InitializeComponent();
            AllowDrop = true;
            _lateLoadFile = lateLoadFile;
        }

        private void ControlsUpdate()
        {
            var mEnable = _project != null;
            var needSave = IsProjectChanged();

            miSaveProject.Enabled = mEnable && needSave;
            tsbSaveProject.Enabled = mEnable && needSave;
            miSaveAsProject.Enabled = mEnable;

            tsbAddEncryptionRow.Enabled = mEnable;
            miAddEncryptionMethodRow.Enabled = mEnable;

            cbScanners.Enabled = mEnable;
            cbListViewFilter.Enabled = mEnable;

            miScanners.Enabled = mEnable;

            miExportCFTFile.Enabled = mEnable;

            listView.Enabled = mEnable;

            tsbUp.Enabled = listView.SelectedIndices.Count > 0 && listView.SelectedIndices[0] > 0;
            tsbDown.Enabled = listView.SelectedIndices.Count > 0 && listView.SelectedIndices[0] < listView.Items.Count-1;
            tsbDeleteItem.Enabled = listView.SelectedIndices.Count > 0;
            tsbDuplicateItem.Enabled = listView.SelectedIndices.Count > 0;

            if (mEnable && _project.EcryptionRows != null && _project.EcryptionRows.Count > 5) 
            {
                var show = true;
                try
                {
                    var licensing = ((cbScanners.Items[cbScanners.SelectedIndex] as DisplayTagObject).Tag as Scanner).Licensing;
                    if (!Utils.IsArrayEmpty(licensing.MotorolaBPUnlockKey) ||
                        !Utils.IsArrayEmpty(licensing.HyteraBPUnlockKey) ||
                        !Utils.IsArrayEmpty(licensing.NxdnScramblerUnlockKey))
                    {
                        show = false;
                    }
                }
                catch {}
                finally
                {
                    if (show)
                        lblStatusL.Text = "WARNING: In DEMO mode, the firmware considers the first 5 rows only.";
                    else
                        lblStatusL.Text = string.Empty;
                }
            }
            else
                lblStatusL.Text = string.Empty;

            if (mEnable && _project.EcryptionRows != null)
                lblStatusR.Text = $"Total rows: {_project.EcryptionRows.Count}";
            else
                lblStatusR.Text = string.Empty;

                var title = $"{TITLE} v{_versionInfo.FileVersion}";
            Text = mEnable ? $"{title} : {(_project.Path == null ? "New" : _project.Path)} {(IsProjectChanged() ? "*" : "")}" : title;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Utils.FillComboBoxData(cbListViewFilter, typeof(ProtocolEnum));
            cbListViewFilter.SelectedIndex = 0;

            if (string.IsNullOrEmpty(_lateLoadFile))
                ControlsUpdate();
            else
                ProcessCftpFile(_lateLoadFile);
        }

        private bool IsProjectChanged()
        {
            if (_project == null && _projectCopy == null)
                return false;

            if (_project == null && _project != null || _project != null && _projectCopy == null)
                return true;

            return !Utils.JsonCompare(_project, _projectCopy);
        }

        private bool CheckFileChangedAndAskAboutSaving()
        {
            if (!IsProjectChanged())
                return true;

            var res = MessageBox.Show("Changes found. Save?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            switch(res)
            {
                case DialogResult.Yes:
                    cmdSave();
                    return true;
                case DialogResult.No:
                    return true;
                case DialogResult.Cancel:
                    return false;
            }
            return false;
        }

        private void miNewProject_Click(object sender, EventArgs e)
        {
            if (!CheckFileChangedAndAskAboutSaving())
                return;

            cmdNew();
            FillScannerSelector();
            UpdateListViewItems();
            ControlsUpdate();
        }

        private void miOpenProject_Click(object sender, EventArgs e)
        {
            if (!CheckFileChangedAndAskAboutSaving())
                return;

            cmdOpen();
            ControlsUpdate();
        }

        private void miSaveProject_Click(object sender, EventArgs e)
        {
            cmdSave();
            ControlsUpdate();
        }

        private void miSaveAsProject_Click(object sender, EventArgs e)
        {
            cmdSave(true);
            ControlsUpdate();
        }

        private void miExportCFTFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Custom Firmware Tuner Files (*.cft)|*.cft",
                FilterIndex = 1,
                RestoreDirectory = true,
                FileName = "alice.cft"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Scanner scanner = null;
                if (cbScanners.SelectedIndex != -1)
                    scanner = (cbScanners.SelectedItem as DisplayTagObject).Tag as Scanner;
                CFTFile.Export(_project, scanner, sfd.FileName);

                MessageBox.Show("File successfully exported.", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't export file.", "Error");
            }
        }

        private void miImportCFTFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Custom Firmware Tuner Files (*.cft)|*.cft|All Files|*.*";
                dlg.Multiselect = false;
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ProcessCftpFile(dlg.FileName);
                    MessageBox.Show("File successfully imported.", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miScanners_Click(object sender, EventArgs e)
        {
            var sl = _project.Scanners != null ? Utils.DeepClone(_project.Scanners) : null;
            var frm = new ScannerListForm(sl);
            frm.ShowDialog();
            if (!Utils.JsonCompare(frm.Scanners, _project.Scanners))
            {
                _project.Scanners = frm.Scanners;
                FillScannerSelector();
                ControlsUpdate();
            }
        }

        private void miMotorolaBPEncryptionMethod_Click(object sender, EventArgs e)
        {
            var frm = new MotorolaBPEncryptionMethodForm(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _project.EcryptionRows.Add(frm.EncryptionRow);
                UpdateListViewItems();
                ListViewNoSort();
                ControlsUpdate();
            }
        }

        private void miMotorolaEPEncryptionMethod_Click(object sender, EventArgs e)
        {
            var frm = new MotorolaEPEncryptionMethodForm(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _project.EcryptionRows.Add(frm.EncryptionRow);
                UpdateListViewItems();
                ListViewNoSort();
                ControlsUpdate();
            }
        }

        private void miHyteraBPEncryptionMethod_Click(object sender, EventArgs e)
        {
            var frm = new HyteraBPEncryptionMethodForm(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _project.EcryptionRows.Add(frm.EncryptionRow);
                UpdateListViewItems();
                ListViewNoSort();
                ControlsUpdate();
            }
        }

        private void miNxdnScramblerMethod_Click(object sender, EventArgs e)
        {
            var frm = new NxdnScramblerEncryptionMethodForm(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _project.EcryptionRows.Add(frm.EncryptionRow);
                UpdateListViewItems();
                ListViewNoSort();
                ControlsUpdate();
            }
        }

        private void tsbDuplicateItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            var row = Utils.DeepClone(listView.SelectedItems[0].Tag as IEncryptionRow);

            if (row is MotorolaBPEncryptionRow)
            {
                var frm = new MotorolaBPEncryptionMethodForm(row as MotorolaBPEncryptionRow);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _project.EcryptionRows.Add(frm.EncryptionRow);
                    UpdateListViewItems();
                    ListViewNoSort();
                    ControlsUpdate();
                }
            }
            else if (row is MotorolaEPEncryptionRow)
            {
                var frm = new MotorolaEPEncryptionMethodForm(row as MotorolaEPEncryptionRow);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _project.EcryptionRows.Add(frm.EncryptionRow);
                    UpdateListViewItems();
                    ListViewNoSort();
                    ControlsUpdate();
                }
            }
            else if (row is HyteraBPEncryptionRow)
            {
                var frm = new HyteraBPEncryptionMethodForm(row as HyteraBPEncryptionRow);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _project.EcryptionRows.Add(frm.EncryptionRow);
                    UpdateListViewItems();
                    ListViewNoSort();
                    ControlsUpdate();
                }
            }
            else if (row is NxdnScramblerEncryptionRow)
            {
                var frm = new NxdnScramblerEncryptionMethodForm(row as NxdnScramblerEncryptionRow);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _project.EcryptionRows.Add(frm.EncryptionRow);
                    UpdateListViewItems();
                    ListViewNoSort();
                    ControlsUpdate();
                }
            }
        }

        private void cmdSelectAll()
        {
            foreach(ListViewItem item in listView.Items)
            {
                item.Selected = true;
            }
        }

        private void cmdSave(bool forceSaveAs = false)
        {
            if (forceSaveAs || _project != null && string.IsNullOrEmpty(_project.Path) || _project == null)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Custom Firmware Tuner Project Files (*.cfp)|*.cfp",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    FileName = string.IsNullOrEmpty(_project.Path) ? "cft.cfp" : _project.Path,
                };

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                _project.Path = sfd.FileName;
            }

            try
            {
                _project.Save();
                _projectCopy = Utils.DeepClone(_project);
                MessageBox.Show("File successfully saved.", "Info");
            }
            catch
            {
                MessageBox.Show("Can't save file.", "Error");
            }
        }

        private void cmdOpen()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Custom Firmware Tuner Project Files (*.cfp)|*.cfp|All Files|*.*";
                dlg.Multiselect = false;
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ProcessCftpFile(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdNew()
        {
            _project = new Project();
            _project.EcryptionRows = new List<IEncryptionRow>();
        }

        private void FillScannerSelector()
        {
            cbScanners.Items.Clear();

            if (_project == null || _project.Scanners == null)
                return;

            foreach (var item in _project.Scanners)
            {
                cbScanners.Items.Add(new DisplayTagObject(item));
            }
            if (cbScanners.Items.Count > 0)
            {
                cbScanners.SelectedIndex = 0;
            }
        }

        private void BuildListViewColumns()
        {
            listView.Items.Clear();
            listView.Columns.Clear();

            var currentFilter = (ProtocolEnum)Utils.GetComboBoxData(cbListViewFilter.SelectedItem);

            listView.Columns.Add("#", 40, HorizontalAlignment.Left);
            listView.Columns.Add("Frequency, MHz", 113, HorizontalAlignment.Left);

            switch (currentFilter)
            {
                case ProtocolEnum.All:
                    {
                        listView.Columns.Add("Notes", 150, HorizontalAlignment.Left);
                        var colDesc = listView.Columns.Add("Description", 150, HorizontalAlignment.Left);
                        colDesc.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        break;
                    }
                case ProtocolEnum.DMR:
                    {
                        listView.Columns.Add("Trunk System", 94, HorizontalAlignment.Left);
                        listView.Columns.Add("MFID", 89, HorizontalAlignment.Left);
                        listView.Columns.Add("CC", 46, HorizontalAlignment.Left);
                        listView.Columns.Add("TGID", 88, HorizontalAlignment.Left);
                        listView.Columns.Add("EnV", 76, HorizontalAlignment.Left);
                        listView.Columns.Add("Encryption Method", 126, HorizontalAlignment.Left);
                        var colNotes = listView.Columns.Add("Notes", 150, HorizontalAlignment.Left);
                        colNotes.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        break;
                    }
                case ProtocolEnum.NXDN:
                    {
                        listView.Columns.Add("RAN", 100, HorizontalAlignment.Left);
                        listView.Columns.Add("Group ID", 150, HorizontalAlignment.Left);
                        listView.Columns.Add("Encryption Method", 126, HorizontalAlignment.Left);
                        var colNotes = listView.Columns.Add("Notes", 150, HorizontalAlignment.Left);
                        colNotes.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        break;
                    }
            }
        }

        private ListViewItem CreateListViewRow(ProtocolEnum filter, IEncryptionRow row)
        {
            var listViewItem = new ListViewItem();
            listViewItem.Tag = row;

            var freqItem = new ListViewItem.ListViewSubItem();
            freqItem.Text = Utils.GetFrequencyString(row.Frequency);
            listViewItem.SubItems.Add(freqItem);

            switch (filter)
            {
                case ProtocolEnum.All:
                    {
                        var notesItem = new ListViewItem.ListViewSubItem();
                        notesItem.Text = row.Notes;
                        listViewItem.SubItems.Add(notesItem);
                        var descItem = new ListViewItem.ListViewSubItem();
                        descItem.Text = row.Description;
                        listViewItem.SubItems.Add(descItem);
                        break;
                    }
                case ProtocolEnum.DMR:
                    {
                        if (row.Protocol != ProtocolEnum.DMR)
                            return null;

                        var options = ((DmrEncryptionRow)row).ActivateOptions;

                        var listViewSubItem0 = new ListViewItem.ListViewSubItem();
                        listViewSubItem0.Text = options.IsActivated(DmrSelectedActivateOptionsEnum.TrunkSystem) ? DisplayNameAttribute.GetName(options.TrunkSystem) : "-";
                        listViewItem.SubItems.Add(listViewSubItem0);

                        var listViewSubItem1 = new ListViewItem.ListViewSubItem();
                        listViewSubItem1.Text = options.IsActivated(DmrSelectedActivateOptionsEnum.MFID) ? options.MFID.ToString() : "-";
                        listViewItem.SubItems.Add(listViewSubItem1);

                        var listViewSubItem2 = new ListViewItem.ListViewSubItem();
                        listViewSubItem2.Text = options.IsActivated(DmrSelectedActivateOptionsEnum.ColorCode) ? DisplayNameAttribute.GetName(options.ColorCode) : "-";
                        listViewItem.SubItems.Add(listViewSubItem2);

                        var listViewSubItem3 = new ListViewItem.ListViewSubItem();
                        listViewSubItem3.Text = options.IsActivated(DmrSelectedActivateOptionsEnum.TGID) ? options.TGID.ToString() : "-";
                        listViewItem.SubItems.Add(listViewSubItem3);

                        var listViewSubItem4 = new ListViewItem.ListViewSubItem();
                        listViewSubItem4.Text = options.IsActivated(DmrSelectedActivateOptionsEnum.EncryptValue) ? DisplayNameAttribute.GetName(options.EncryptionValue) : "-";
                        listViewItem.SubItems.Add(listViewSubItem4);

                        var listViewSubItem5 = new ListViewItem.ListViewSubItem();
                        listViewSubItem5.Text = DisplayNameAttribute.GetName(row);
                        listViewItem.SubItems.Add(listViewSubItem5);

                        var listViewSubItem6 = new ListViewItem.ListViewSubItem();
                        listViewSubItem6.Text = row.Notes;
                        listViewItem.SubItems.Add(listViewSubItem6);

                        break;
                    }
                case ProtocolEnum.NXDN:
                    {
                        if (row.Protocol != ProtocolEnum.NXDN)
                            return null;

                        var options = ((NxdnScramblerEncryptionRow)row).ActivateOptions;

                        var listViewSubItem4 = new ListViewItem.ListViewSubItem();
                        listViewSubItem4.Text = options.IsActivated(NxdnSelectedActivateOptionsEnum.RAN) ? options.RAN.ToString() : "-";
                        listViewItem.SubItems.Add(listViewSubItem4);

                        var listViewSubItem3 = new ListViewItem.ListViewSubItem();
                        listViewSubItem3.Text = options.IsActivated(NxdnSelectedActivateOptionsEnum.GroupID) ? options.GroupID.ToString() : "-";
                        listViewItem.SubItems.Add(listViewSubItem3);

                        var listViewSubItem5 = new ListViewItem.ListViewSubItem();
                        listViewSubItem5.Text = DisplayNameAttribute.GetName(row);
                        listViewItem.SubItems.Add(listViewSubItem5);

                        var listViewSubItem6 = new ListViewItem.ListViewSubItem();
                        listViewSubItem6.Text = row.Notes;
                        listViewItem.SubItems.Add(listViewSubItem6);

                        break;
                    }
            }
            return listViewItem;
        }

        private void UpdateListViewItems()
        {
            listView.Items.Clear();
            if (_project == null)
                return;

            var currentFilter = (ProtocolEnum)Utils.GetComboBoxData(cbListViewFilter.SelectedItem);

            var count = 1;
            foreach (var row in _project.EcryptionRows)
            {
                var item = CreateListViewRow(currentFilter, row);
                if (item != null)
                {
                    item.Text = count++.ToString();
                    listView.Items.Add(item);
                }
            }
        }

        private void cbListViewFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildListViewColumns();
            UpdateListViewItems();
            ControlsUpdate();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlsUpdate();
            Message m = Message.Create(Handle, 0x127, new IntPtr(0x10001), new IntPtr(0));
            WndProc(ref m);
        }

        private void listView_Enter(object sender, EventArgs e)
        {
            base.OnEnter(e);
            Message m = Message.Create(Handle, 0x127, new IntPtr(0x10001), new IntPtr(0));
            WndProc(ref m);
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            var row = listView.SelectedItems[0].Tag;
            var filter = (ProtocolEnum)Utils.GetComboBoxData(cbListViewFilter.SelectedItem);

            if (row is MotorolaBPEncryptionRow)
            {
                var frm = new MotorolaBPEncryptionMethodForm((MotorolaBPEncryptionRow)row);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var item = CreateListViewRow(filter, frm.EncryptionRow);
                    item.Text = listView.SelectedItems[0].Text;
                    item.Selected = true;
                    listView.Items[listView.SelectedIndices[0]] = item;
                    ControlsUpdate();
                }
            }
            else if (row is MotorolaEPEncryptionRow)
            {
                var frm = new MotorolaEPEncryptionMethodForm((MotorolaEPEncryptionRow)row);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var item = CreateListViewRow(filter, frm.EncryptionRow);
                    item.Text = listView.SelectedItems[0].Text;
                    item.Selected = true;
                    listView.Items[listView.SelectedIndices[0]] = item;
                    ControlsUpdate();
                }
            }
            else if (row is HyteraBPEncryptionRow)
            {
                var frm = new HyteraBPEncryptionMethodForm((HyteraBPEncryptionRow)row);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var item = CreateListViewRow(filter, frm.EncryptionRow);
                    item.Text = listView.SelectedItems[0].Text;
                    item.Selected = true;
                    listView.Items[listView.SelectedIndices[0]] = item;
                    ControlsUpdate();
                }
            }
            else if (row is NxdnScramblerEncryptionRow)
            {
                var frm = new NxdnScramblerEncryptionMethodForm((NxdnScramblerEncryptionRow)row);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var item = CreateListViewRow(filter, frm.EncryptionRow);
                    item.Text = listView.SelectedItems[0].Text;
                    item.Selected = true;
                    listView.Items[listView.SelectedIndices[0]] = item;
                    ControlsUpdate();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckFileChangedAndAskAboutSaving())
                e.Cancel = true; 
        }

        private int GetProjectEncryptionRowIndex(IEncryptionRow row)
        {
            if (_project == null || _project.EcryptionRows == null)
                return -1;

            for(var i=0;i<_project.EcryptionRows.Count;i++)
            {
                if (row.Equals(_project.EcryptionRows[i]))
                    return i;
            }
            return -1;
        }

        private void SwapListViewItems(int indexA, int indexB)
        {
            var curItem = listView.Items[indexA];
            var nextItem = listView.Items[indexB];

            var curRowIndex = GetProjectEncryptionRowIndex(curItem.Tag as IEncryptionRow);
            var nextRowIndex = GetProjectEncryptionRowIndex(nextItem.Tag as IEncryptionRow);

            _project.EcryptionRows[nextRowIndex] = curItem.Tag as IEncryptionRow;
            _project.EcryptionRows[curRowIndex] = nextItem.Tag as IEncryptionRow;

            var filter = (ProtocolEnum)Utils.GetComboBoxData(cbListViewFilter.SelectedItem);

            listView.Items[indexA] = CreateListViewRow(filter, nextItem.Tag as IEncryptionRow);
            listView.Items[indexA].Text = curItem.Text;
            var row = CreateListViewRow(filter, curItem.Tag as IEncryptionRow);
            row.Selected = true;
            listView.Items[indexB] = row;
            listView.Items[indexB].Text = nextItem.Text;
        }

        private void tsbDown_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count == 0)
                return;

            SwapListViewItems(listView.SelectedIndices[0], listView.SelectedIndices[0] + 1);
            ListViewNoSort();
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count == 0)
                return;

            SwapListViewItems(listView.SelectedIndices[0], listView.SelectedIndices[0] - 1);
            ListViewNoSort();
        }

        private void ListViewNoSort()
        {
            _colFreqSortOrder = SortOrder.None;
            ListViewExtensions.SetSortIcon(listView, 0, _colFreqSortOrder);
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 1)
            {
                if (_colFreqSortOrder == SortOrder.None || _colFreqSortOrder == SortOrder.Ascending)
                {
                    _colFreqSortOrder = SortOrder.Descending;
                    ListViewExtensions.SetSortIcon(listView, 1, _colFreqSortOrder);
                    _project.EcryptionRows.Sort((a, b) => a.Frequency.CompareTo(b.Frequency));
                }
                else
                {
                    _colFreqSortOrder = SortOrder.Ascending;
                    ListViewExtensions.SetSortIcon(listView, 1, _colFreqSortOrder);
                    _project.EcryptionRows.Sort((a, b) => b.Frequency.CompareTo(a.Frequency));
                }
                UpdateListViewItems();
                listView.Invalidate();
                ControlsUpdate();
            }
        }

        private void CopySelectedItemsToClipboard()
        {
            var list = new List<IEncryptionRow>();
            for (var i = 0; i < listView.SelectedIndices.Count; i++)
            {
                var index = listView.SelectedIndices[listView.SelectedIndices.Count - i - 1];
                var row = listView.Items[index].Tag as IEncryptionRow;
                if (row != null)
                    list.Add(row);
            }
            if (list.Count > 0)
                Clipboard.SetData("CFT", JsonConvert.SerializeObject(list, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }));
        }

        private List<IEncryptionRow> GetEncryptionRowsFromClipboard() 
        {
            try
            {
                return JsonConvert.DeserializeObject<List<IEncryptionRow>>(Clipboard.GetData("CFT").ToString(), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            }
            catch { }
            return null;
        }

        private void InsertItemsFromClipboard()
        {
            try
            {
                var list = GetEncryptionRowsFromClipboard();
                if (list != null && list.Count > 0)
                {
                    // search insert place
                    var insertIndex = -1;
                    if (listView.SelectedIndices.Count > 0)
                        insertIndex = listView.SelectedIndices[0];

                    foreach (var row in list)
                    {
                        if (insertIndex < 0)
                            _project.EcryptionRows.Add(row);
                        else
                            _project.EcryptionRows.Insert(insertIndex++, row);
                    }
                    ListViewNoSort();
                    UpdateListViewItems();
                    listView.Items[insertIndex--].Selected = true;
                }
            }
            catch { }
        }

        private void tsbDeleteItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count == 0)
                return;

            var mkeys = Control.ModifierKeys;

            if (MessageBox.Show($"Deleting {listView.SelectedIndices.Count} row(s).\r\nAre you sure?", "Delete row(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            // copy to clip
            if (mkeys == Keys.Shift)
                CopySelectedItemsToClipboard();

            for (var i=0; i<listView.SelectedIndices.Count; i++)
            {
                var index = listView.SelectedIndices[listView.SelectedIndices.Count - i - 1];
                _project.EcryptionRows.Remove(listView.Items[index].Tag as IEncryptionRow);
            }
            ListViewNoSort();
            UpdateListViewItems();
            listView.Invalidate();
            ControlsUpdate();
        }

        private void miDebugLogsFiltering_Click(object sender, EventArgs e)
        {
            new DebugLogsFilteringForm().ShowDialog();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.C:
                    if (e.Control)
                        CopySelectedItemsToClipboard();
                    break;
                case Keys.V:
                    if (e.Control)
                        InsertItemsFromClipboard();
                    break;
                case Keys.X:
                    if (e.Control)
                        CopySelectedItemsToClipboard();
                        tsbDeleteItem_Click(this, e);
                    break;

                case Keys.Enter:
                    listView_DoubleClick(sender, e);
                    break;
                case Keys.Delete:
                    tsbDeleteItem_Click(sender, e);
                    break;
                case Keys.Insert:

                    if (e.Modifiers == Keys.None)
                    {
                        var frm = new SelectEncryptionMethodForm();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            switch (frm.Selection)
                            {
                                case 0:
                                    miMotorolaBPEncryptionMethod_Click(sender, e);
                                    break;
                                case 1:
                                    miHyteraBPEncryptionMethod_Click(sender, e);
                                    break;
                                case 2:
                                    miNxdnScramblerMethod_Click(sender, e);
                                    break;
                                case 3:
                                    miMotorolaEPEncryptionMethod_Click(sender, e);
                                    break;
                            }
                        }
                    }
                    else if(e.Control)
                    {
                        CopySelectedItemsToClipboard();
                    }
                    else if (e.Shift)
                    {
                        InsertItemsFromClipboard();
                    }
                    break;
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files == null || files.Length != 1)
                    return;

                if (!ProcessCftpFile(files[0]))
                    return;

                MessageBox.Show("File loaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
            }
        }

        private bool ProcessCftpFile(string filename)
        {
            if (!File.Exists(filename))
                return false;

            var ext = Path.GetExtension(filename).ToLower();
            switch(ext)
            {
                case ".cft":
                    var project = CFTFile.Import(filename);
                    if (_project == null)
                        _project = project;
                    else
                    {
                        foreach(var row in project.EcryptionRows)
                            _project.EcryptionRows.Add(row);
                    }

                    FillScannerSelector();
                    UpdateListViewItems();
                    ControlsUpdate();
                    return true;
                case ".cfp":
                    _project = Project.Load(filename);
                    if (_project.EcryptionRows == null)
                        _project.EcryptionRows = new List<IEncryptionRow>();
                    if (_project != null)
                        _projectCopy = Utils.DeepClone(_project);
                    FillScannerSelector();
                    BuildListViewColumns();
                    UpdateListViewItems();
                    ControlsUpdate();
                    return true;
                default:
                    MessageBox.Show("Wrong file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
            return false;
        }

        private void dSDFrequencyCSVFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "DSD Frequency File (*.csv)|*.csv|All Files|*.*";
                dlg.Multiselect = false;
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                var items = DsdImport.Import(dlg.FileName);

                if (items == null || items.Count ==0)
                {
                    MessageBox.Show("No data rows for Export", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var frm = new ImportForm(items);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (_project == null)
                        cmdNew();

                    foreach(var item in frm.ImportItems)
                    {
                        var row = Utils.DeepClone(item.EncryptionRow);
                        row.Frequency = item.Frequency;
                        row.Notes = item.Notes;
                        _project.EcryptionRows.Add(row);
                    }

                    FillScannerSelector();
                    UpdateListViewItems();
                    ControlsUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cutToolStripMenuItem.Enabled = listView.SelectedIndices.Count > 0;
            copyToolStripMenuItem.Enabled = listView.SelectedIndices.Count > 0;
            pasteToolStripMenuItem.Enabled = GetEncryptionRowsFromClipboard() != null;
            deleteToolStripMenuItem.Enabled = listView.SelectedIndices.Count > 0;
            selectAllToolStripMenuItem.Enabled = listView.Items.Count > 0;
        }

        private void miEdit_DropDownOpening(object sender, EventArgs e)
        {
            cutToolStripMenuItem1.Enabled = listView.SelectedIndices.Count > 0;
            copyToolStripMenuItem1.Enabled = listView.SelectedIndices.Count > 0;
            pasteToolStripMenuItem1.Enabled = GetEncryptionRowsFromClipboard() != null;
            deleteToolStripMenuItem1.Enabled = listView.SelectedIndices.Count > 0;
            selectAllToolStripMenuItem1.Enabled = listView.Items.Count > 0;
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cmdSelectAll();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InsertItemsFromClipboard();
            ControlsUpdate();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CopySelectedItemsToClipboard();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CopySelectedItemsToClipboard();
            tsbDeleteItem_Click(this, e);
            ControlsUpdate();
        }
    }
}
