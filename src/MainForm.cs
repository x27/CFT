using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;


namespace CFT
{
    public partial class MainForm : Form
    {
        const string TITLE = "Custom Firmware Tuner";

        private CftFile _cftFile;
        private CftFile _cftFileCopy;
        private SortOrder _colFreqSortOrder = SortOrder.None;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ControlsUpdate();
        }

        private void ControlsUpdate()
        {
            var mEnable = _cftFile != null;
            var needSave = IsCftFileChanged();
            var index = GetListViewCurrentItemIndex();

            tsbSave.Enabled = mEnable && needSave;
            tsbAdd.Enabled = mEnable;
            tsbDelete.Enabled = mEnable && (index != -1);
            tsbUp.Enabled = mEnable && (index > 0);
            tsbDuplicate.Enabled = tsbDelete.Enabled;
            tsbDown.Enabled = mEnable && (index >= 0 && index < _cftFile.DmrEncryptionMethodItems.Count - 1);
            listView.Enabled = mEnable;

            saveToolStripMenuItem.Enabled = mEnable && needSave;
            saveAsToolStripMenuItem.Enabled = mEnable && needSave;
            licensingToolStripMenuItem.Enabled = mEnable;

            Text = mEnable ? $"{TITLE} : {(_cftFile.Filename == null ? "New" : _cftFile.Filename)} {(IsCftFileChanged()?"*":"")}" : TITLE;
        }

        private bool IsCftFileChanged()
        {
            if (_cftFile == null && _cftFileCopy == null)
                return false;

            if (_cftFile == null && _cftFile != null || _cftFile != null && _cftFileCopy == null)
                return true;

            return !Utils.DeepCompare(_cftFile, _cftFileCopy);
        }

        private int GetListViewCurrentItemIndex()
        {
            for (var i = 0; i < listView.Items.Count; i++)
                if (listView.Items[i].Selected)
                    return i;
            return -1;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            cmdAddItem();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var index = GetListViewCurrentItemIndex();
            if (index > -1)
            {
                _cftFile.DmrEncryptionMethodItems.RemoveAt(index);
                listView.VirtualListSize = _cftFile.DmrEncryptionMethodItems.Count;

                if (index > 0 && index > _cftFile.DmrEncryptionMethodItems.Count - 1)
                {
                    listView.Items[index - 1].Selected = true;
                    listView.Items[index - 1].Focused = true;
                }
                ListViewNoSort();
                ControlsUpdate();
            }
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            var index = GetListViewCurrentItemIndex() - 1;
            var item = _cftFile.DmrEncryptionMethodItems[index];
            _cftFile.DmrEncryptionMethodItems[index] = _cftFile.DmrEncryptionMethodItems[index + 1];
            _cftFile.DmrEncryptionMethodItems[index + 1] = item;
            listView.Invalidate();
            listView.Items[index].Selected = true;
            listView.Items[index].Focused = true;
            ListViewNoSort();
        }

        private void tsbDown_Click(object sender, EventArgs e)
        {
            var index = GetListViewCurrentItemIndex() + 1;
            var item = _cftFile.DmrEncryptionMethodItems[index];
            _cftFile.DmrEncryptionMethodItems[index] = _cftFile.DmrEncryptionMethodItems[index - 1];
            _cftFile.DmrEncryptionMethodItems[index - 1] = item;
            listView.Invalidate();
            listView.Items[index].Selected = true;
            listView.Items[index].Focused = true;

            ListViewNoSort();
        }

        private void listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var item = _cftFile.DmrEncryptionMethodItems[e.ItemIndex];

            var listViewItem = new ListViewItem();
            listViewItem.Text = Utils.GetFrequencyString(item.Frequency);

            var listViewSubItem0 = new ListViewItem.ListViewSubItem();
            listViewSubItem0.Text = item.IsActiveOption(DmrNeedOptionsEnum.TrunkSystem) ? DisplayNameAttribute.GetName(item.TrunkSystem) : "-";
            listViewItem.SubItems.Add(listViewSubItem0);

            var listViewSubItem1 = new ListViewItem.ListViewSubItem();
            listViewSubItem1.Text = item.IsActiveOption(DmrNeedOptionsEnum.Mfid) ? item.Mfid.ToString() : "-";
            listViewItem.SubItems.Add(listViewSubItem1);

            var listViewSubItem2 = new ListViewItem.ListViewSubItem();
            listViewSubItem2.Text = item.IsActiveOption(DmrNeedOptionsEnum.ColorCode) ? DisplayNameAttribute.GetName(item.ColorCode) : "-";
            listViewItem.SubItems.Add(listViewSubItem2);

            var listViewSubItem3 = new ListViewItem.ListViewSubItem();
            listViewSubItem3.Text = item.IsActiveOption(DmrNeedOptionsEnum.Tgid) ? item.Tgid.ToString() : "-";
            listViewItem.SubItems.Add(listViewSubItem3);

            var listViewSubItem4 = new ListViewItem.ListViewSubItem();
            listViewSubItem4.Text = item.IsActiveOption(DmrNeedOptionsEnum.EncryptValue) ? item.EncryptionValue.ToString() : "-";
            listViewItem.SubItems.Add(listViewSubItem4);

            var listViewSubItem5 = new ListViewItem.ListViewSubItem();
            listViewSubItem5.Text = DisplayNameAttribute.GetName(item.EncryptionMethod);
            listViewItem.SubItems.Add(listViewSubItem5);

            e.Item = listViewItem;
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            var index = GetListViewCurrentItemIndex();

            var frm = new EncryptionMethodForm(_cftFile.DmrEncryptionMethodItems[index]);
            if (frm.ShowDialog() == DialogResult.OK)
                _cftFile.DmrEncryptionMethodItems[index] = frm.Item;
            ControlsUpdate();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlsUpdate();
        }

        private void licensingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new LicensingForm(_cftFile.Licensing);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                _cftFile.Licensing = frm.Licensing;
                ControlsUpdate();
            }
        }
        private void newMenuItem_Click(object sender, EventArgs e)
        {
            CheckFileChangedAndAskAboutSaving();
            cmdNew();
            ControlsUpdate();
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            CheckFileChangedAndAskAboutSaving();
            cmdOpen();
            ControlsUpdate();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            cmdSave();
            ControlsUpdate();
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            cmdSave(true);
            ControlsUpdate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            CheckFileChangedAndAskAboutSaving();
            cmdNew();
            ControlsUpdate();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            CheckFileChangedAndAskAboutSaving();
            cmdOpen();
            ControlsUpdate();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            cmdSave();
            ControlsUpdate();
        }

        private void cmdSave(bool forceSaveAs = false)
        {
            if (forceSaveAs || _cftFile != null && string.IsNullOrEmpty(_cftFile.Filename) || _cftFile == null)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Custom Firmware Tuner Files (*.cft)|*.cft",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    FileName = string.IsNullOrEmpty(_cftFile.Filename) ? "alice.cft" : _cftFile.Filename,
                };

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                _cftFile.Filename = sfd.FileName;
            }

            try
            {
                _cftFile.Write();
                _cftFileCopy = Utils.DeepClone(_cftFile);
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
                dlg.Filter = "Custom Firmware Tuner Files (*.cft)|*.cft|All Files|*.*";
                dlg.Multiselect = false;
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _cftFile = CftFile.Load(dlg.FileName);
                    _cftFileCopy = Utils.DeepClone(_cftFile);
                    listView.VirtualListSize = _cftFile.DmrEncryptionMethodItems.Count;
                    ControlsUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdNew()
        {
            _cftFile = new CftFile();
            listView.VirtualListSize = _cftFile.DmrEncryptionMethodItems.Count;
        }

        private void cmdAddItem(bool duplicate = false)
        {
            EncryptionMethodForm frm;
            if (duplicate)
            {
                var index = GetListViewCurrentItemIndex();
                frm = new EncryptionMethodForm(_cftFile.DmrEncryptionMethodItems[index]);
            }
            else
                frm = new EncryptionMethodForm();
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _cftFile.DmrEncryptionMethodItems.Add(frm.Item);
                listView.VirtualListSize = _cftFile.DmrEncryptionMethodItems.Count;
                listView.Items[_cftFile.DmrEncryptionMethodItems.Count - 1].Selected = true;
                listView.Items[_cftFile.DmrEncryptionMethodItems.Count - 1].Focused = true;
                listView.Select();

                ListViewNoSort();
                ControlsUpdate();
            }
        }

        private void CheckFileChangedAndAskAboutSaving()
        {
            if (!IsCftFileChanged())
                return;

            if (MessageBox.Show("Changes found. Save?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            cmdSave();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            MessageBox.Show($"Custom Firmware Tuner (CFT)\r\n{fvi.FileVersion}\r\nJD\r\n2024", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckFileChangedAndAskAboutSaving();
        }

        private void debugLogsFilteringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DebugLogsFilteringForm().ShowDialog();
        }

        private void tsbDuplicate_Click(object sender, EventArgs e)
        {
            cmdAddItem(true);
        }

        private void ListViewNoSort()
        {
            _colFreqSortOrder = SortOrder.None;
            ListViewExtensions.SetSortIcon(listView, 0, _colFreqSortOrder);
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                if (_colFreqSortOrder == SortOrder.None || _colFreqSortOrder == SortOrder.Ascending)
                {
                    _colFreqSortOrder = SortOrder.Descending;
                    ListViewExtensions.SetSortIcon(listView, 0, _colFreqSortOrder);
                    _cftFile.SortItemsByFrequency(false);
                }
                else
                {
                    _colFreqSortOrder = SortOrder.Ascending;
                    ListViewExtensions.SetSortIcon(listView, 0, _colFreqSortOrder);
                    _cftFile.SortItemsByFrequency(true);
                }
                listView.Invalidate();
                ControlsUpdate();
            }
        }
    }
}
