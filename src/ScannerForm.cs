﻿using System.Windows.Forms;

namespace CFT
{
    public partial class ScannerForm : Form
    {
        public Scanner Scanner { get; private set; }
        private KeyMapping _keyMapping = new KeyMapping();

        public ScannerForm(Scanner scanner)
        {
            InitializeComponent();

            Scanner = scanner == null ? new Scanner() : Utils.DeepClone(scanner);
            _keyMapping = Scanner.KeyMapping;

            Utils.FillComboBoxData(cbModel, typeof(ScannerModelEnum));
            if (!Utils.SetComboBoxData(cbModel, Scanner.Model))
                cbModel.SelectedIndex = 0;

            cbMute.Checked = Scanner.MuteEncryptedVoiceTraffic;

            tbName.Text = Scanner.Name;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Scanner.Model = (ScannerModelEnum)Utils.GetComboBoxData(cbModel.SelectedItem);
            Scanner.Name = tbName.Text.Trim();
            Scanner.KeyMapping = _keyMapping;
            Scanner.MuteEncryptedVoiceTraffic = cbMute.Checked;
        }

        private void btnLicenses_Click(object sender, System.EventArgs e)
        {
            var frm = new LicensingForm(Scanner.Licensing);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Scanner.Licensing = frm.Licensing;
            }
        }

        private void btnKeyMappings_Click(object sender, System.EventArgs e)
        {
            var model = (ScannerModelEnum)Utils.GetComboBoxData(cbModel.SelectedItem);
            var frm = new KeyMappingForm(model, _keyMapping);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _keyMapping = frm.KeyMapping;
            }
        }
    }
}
