using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class TyteraEPEncryptionMethodForm : Form
    {
        public TyteraEPEncryptionRow EncryptionRow { get; private set; }
        public bool IsBatchMode { get; private set; }

        public TyteraEPEncryptionMethodForm(TyteraEPEncryptionRow row = null, bool batchMode = false)
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

            if (row == null)
            {
                EncryptionRow = new TyteraEPEncryptionRow();
                EncryptionRow.Key = new byte[TyteraEPEncryptionRow.KEY_SIZE];
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

                if (Utils.IsArrayEmpty(row.Key))
                    tbKey.Text = string.Empty;
                else
                    tbKey.Text = Utils.BytesToHexString(row.Key);

                tbNotes.Text = row.Notes;
            }
            OptionsControl_OptionChanged(this, null);
        }

        private void OptionsControl_OptionChanged(object sender, EventArgs e)
        {
            tbFrequency.Enabled = optionsControl.Options.IsActivated(DmrSelectedActivateOptionsEnum.Frequency);
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

            Array.Clear(EncryptionRow.Key, 0, 5);
            if (key.Length > 0)
                Buffer.BlockCopy(key, 0, EncryptionRow.Key, 0, key.Length > TyteraEPEncryptionRow.KEY_SIZE ? TyteraEPEncryptionRow.KEY_SIZE : key.Length);

            EncryptionRow.Frequency = freq;
            EncryptionRow.ActivateOptions = optionsControl.Options;

            EncryptionRow.Notes = tbNotes.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
