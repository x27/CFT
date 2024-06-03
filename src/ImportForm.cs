using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CFT
{
    public partial class ImportForm : Form
    {
        private IEncryptionRow _batchEncryptionRow;

        public List<ImportItem> ImportItems { get; private set; }

        public ImportForm(List<ImportItem> items = null)
        {
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(EncryptionMethodEnum)))
                cbEncryptionMethod.Items.Add(new DisplayTagObject(item));
            cbEncryptionMethod.SelectedIndex = 0;

            foreach(var item in items)
            {
                var lvi = new ListViewItem();
                
                var freqItem = new ListViewItem.ListViewSubItem();
                freqItem.Text = Utils.GetFrequencyString(item.Frequency);
                lvi.SubItems.Add(freqItem);

                var notesItem = new ListViewItem.ListViewSubItem();
                notesItem.Text = item.Notes;
                lvi.SubItems.Add(notesItem);

                var optionsItem = new ListViewItem.ListViewSubItem();
                optionsItem.Text = string.Empty;
                lvi.SubItems.Add(optionsItem);

                var l = lvImport.Items.Add(lvi);
                l.Checked = true;
            }

            UpdateControls();
        }

        private void UpdateControls()
        {
            if (_batchEncryptionRow != null) 
                tbEncryptionMethodInfo.Text = _batchEncryptionRow.Description;
            else
                tbEncryptionMethodInfo.Text = string.Empty;
            btImport.Enabled = lvImport.Items != null && lvImport.Items.Count > 0;
        }


        private void cbEncryptionMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            _batchEncryptionRow = null;
            UpdateControls();
        }

        private void btnSelectEncryptionMethodOptions_Click(object sender, EventArgs e)
        {
            if (cbEncryptionMethod.SelectedIndex < 0)
                return;

            var method = cbEncryptionMethod.SelectedItem as DisplayTagObject;
            if (method == null || method.Tag == null) 
                return;

            var enumMethod = (EncryptionMethodEnum)method.Tag;    

            switch(enumMethod)
            {
                case EncryptionMethodEnum.MotorolaBP:
                    {
                        var frm = new MotorolaBPEncryptionMethodForm(_batchEncryptionRow as MotorolaBPEncryptionRow, true);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            _batchEncryptionRow = frm.EncryptionRow;
                        }
                        break;
                    }
                case EncryptionMethodEnum.HyteraBP:
                    {
                        var frm = new HyteraBPEncryptionMethodForm(_batchEncryptionRow as HyteraBPEncryptionRow, true);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            _batchEncryptionRow = frm.EncryptionRow;
                        }
                        break;
                    }
                case EncryptionMethodEnum.NxdnScrambler:
                    {
                        var frm = new NxdnScramblerEncryptionMethodForm(_batchEncryptionRow as NxdnScramblerEncryptionRow, true);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            _batchEncryptionRow = frm.EncryptionRow;
                        }
                        break;
                    }
                case EncryptionMethodEnum.MotorolaEP:
                    {
                        var frm = new MotorolaEPEncryptionMethodForm(_batchEncryptionRow as MotorolaEPEncryptionRow, true);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            _batchEncryptionRow = frm.EncryptionRow;
                        }
                        break;
                    }
            }
            UpdateControls();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lvImport.Items)
                item.Checked = true;
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvImport.Items)
                item.Checked = false;
        }

        private void btBatchSet_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lvImport.Items)
            {
                if (item.Selected)
                {
                    item.SubItems[3].Text = _batchEncryptionRow == null ? string.Empty : _batchEncryptionRow.Description;
                    item.Tag = _batchEncryptionRow; 
                }
            }
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            ImportItems = new List<ImportItem>();

            foreach(ListViewItem item in lvImport.Items)
            {
                if (item.Checked && item.Tag  != null)
                {
                    var importItem = new ImportItem();

                    if (!Utils.ParseFrequency(item.SubItems[1].Text, out uint freq, out string err))
                        continue;

                    importItem.Frequency = freq;
                    importItem.EncryptionRow = item.Tag as IEncryptionRow;
                    importItem.Notes = item.SubItems[2].Text;   

                    ImportItems.Add(importItem);
                }
            }

            if (ImportItems.Count == 0)
            {
                MessageBox.Show("No rows for import\r\nNeed set checkbox and Option for required rows", "Error");
                return;
            }

            if (MessageBox.Show($"Founded {ImportItems.Count} row(s) for import. Continue?", "Info", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
