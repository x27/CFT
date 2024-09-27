using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class KirisunBPEncryptionMethodForm : Form
    {
        public KirisunBPEncryptionRow EncryptionRow { get; private set; }
        public bool IsBatchMode { get; private set; }

        public KirisunBPEncryptionMethodForm(KirisunBPEncryptionRow row = null, bool batchMode = false)
        {
            InitializeComponent();

            optionsControl.OptionChanged += OptionsControl_OptionChanged;

            IsBatchMode = batchMode;
            if (IsBatchMode)
            {
                Text += " (Batch mode)";
                tbFrequency.Enabled = false;
                tbNotes.Enabled = false;
            }

            Utils.FillComboBoxData(cbKeyLength, typeof(KirisunKeyLengthEnum));
            cbKeyLength.SelectedIndex = 0;

            if (row == null)
            {
                EncryptionRow = new KirisunBPEncryptionRow();
                EncryptionRow.Key = new byte[KirisunBPEncryptionRow.KEY_SIZE];
                if (!IsBatchMode)
                    tbFrequency.Text = Utils.GetFrequencyString(145500000);
                optionsControl.SetOptions(null);
            }
            else
            {
                EncryptionRow = row;
                if (!IsBatchMode)
                    tbFrequency.Text = Utils.GetFrequencyString(row.Frequency);
                optionsControl.SetOptions(row.ActivateOptions);

                if (row.KeyLength == 40)
                    Utils.SetComboBoxData(cbKeyLength, KirisunKeyLengthEnum.L40);
                if (row.KeyLength == 64)
                    Utils.SetComboBoxData(cbKeyLength, KirisunKeyLengthEnum.L64);
                else if (row.KeyLength == 128)
                    Utils.SetComboBoxData(cbKeyLength, KirisunKeyLengthEnum.L128);
                else if (row.KeyLength == 192)
                    Utils.SetComboBoxData(cbKeyLength, KirisunKeyLengthEnum.L192);
                else if (row.KeyLength == 256)
                    Utils.SetComboBoxData(cbKeyLength, KirisunKeyLengthEnum.L256);

                if (Utils.IsArrayEmpty(row.Key))
                    tbKey.Text = string.Empty;
                else
                    tbKey.Text = Utils.BytesToHexString(row.Key).Substring(0, (int)(row.KeyLength / 4 + (row.KeyLength % 4 != 0 ? 1 : 0)));

                tbNotes.Text = row.Notes;
            }

            OptionsControl_OptionChanged(this, null);
        }

        private void OptionsControl_OptionChanged(object sender, EventArgs e)
        {
            tbFrequency.Enabled = optionsControl.Options.IsActivated(DmrSelectedActivateOptionsEnum.Frequency);
            cbKeyLength.Enabled = !optionsControl.Options.IsActivated(DmrSelectedActivateOptionsEnum.ForceMute);
            tbKey.Enabled = !optionsControl.Options.IsActivated(DmrSelectedActivateOptionsEnum.ForceMute);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string errorStr;

            if (optionsControl.IsExistErrors(out errorStr))
            {
                MessageBox.Show(errorStr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            uint freq = 0;
            if (!IsBatchMode && !Utils.ParseFrequency(tbFrequency.Text, out freq, out errorStr))
            {
                tbFrequency.Focus();
                MessageBox.Show(errorStr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EncryptionRow.Frequency = freq;
            EncryptionRow.ActivateOptions = optionsControl.Options;

            byte[] key;
            try
            {
                key = Utils.HexStringToBytes(tbKey.Text);
            }
            catch
            {
                MessageBox.Show("Wrong Encryption Key Format.\r\nMust be HEX!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbKey.Focus();
                return;
            }

            EncryptionRow.KeyLength = (uint)(KirisunKeyLengthEnum)(cbKeyLength.SelectedItem as DisplayTagObject).Tag;
            Buffer.BlockCopy(key, 0, EncryptionRow.Key, 0, key.Length > KirisunBPEncryptionRow.KEY_SIZE ? KirisunBPEncryptionRow.KEY_SIZE : key.Length);

            EncryptionRow.Notes = tbNotes.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
