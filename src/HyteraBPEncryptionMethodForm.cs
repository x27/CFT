using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class HyteraBPEncryptionMethodForm : Form
    {
        public HyteraBPEncryptionRow EncryptionRow { get; private set; }
        public bool IsBatchMode { get; private set; }

        public HyteraBPEncryptionMethodForm(HyteraBPEncryptionRow row = null, bool batchMode = false)
        {
            InitializeComponent();

            IsBatchMode = batchMode;
            if (IsBatchMode)
            {
                Text += " (Batch mode)";
                tbFrequency.Enabled = false;
                tbNotes.Enabled = false;
            }

            Utils.FillComboBoxData(cbKeyLength, typeof(HyteraKeyLengthEnum));
            cbKeyLength.SelectedIndex = 0;

            if (row == null)
            {
                EncryptionRow = new HyteraBPEncryptionRow();
                EncryptionRow.Key = new byte[HyteraBPEncryptionRow.KEY_SIZE];
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
                    Utils.SetComboBoxData(cbKeyLength, HyteraKeyLengthEnum.L40);
                else if (row.KeyLength == 128)
                    Utils.SetComboBoxData(cbKeyLength, HyteraKeyLengthEnum.L128);
                else if (row.KeyLength == 256)
                    Utils.SetComboBoxData(cbKeyLength, HyteraKeyLengthEnum.L256);
                else
                {
                    nudKeyLength.Value = row.KeyLength;
                    cbNonStandard.Checked = true;
                }

                if (Utils.IsArrayEmpty(row.Key))
                    tbKey.Text = string.Empty;
                else
                    tbKey.Text = Utils.BytesToHexString(row.Key).Substring(0, (int)(row.KeyLength / 4 + (row.KeyLength % 4 != 0 ? 1 : 0)));

                tbNotes.Text = row.Notes;
            }

            cbNonStandard_CheckedChanged(this, null);
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

            if (cbNonStandard.Checked)
                EncryptionRow.KeyLength = (uint)nudKeyLength.Value;
            else
                EncryptionRow.KeyLength = (uint)((HyteraKeyLengthEnum)(cbKeyLength.SelectedItem as DisplayTagObject).Tag);
            Buffer.BlockCopy(key, 0, EncryptionRow.Key, 0, key.Length > HyteraBPEncryptionRow.KEY_SIZE ? HyteraBPEncryptionRow.KEY_SIZE : key.Length);

            EncryptionRow.Notes = tbNotes.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cbNonStandard_CheckedChanged(object sender, EventArgs e)
        {
            nudKeyLength.Visible = cbNonStandard.Checked;
            cbKeyLength.Visible = !cbNonStandard.Checked;
        }
    }
}
