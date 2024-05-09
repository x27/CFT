using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class HyteraBPEncryptionMethodForm : Form
    {
        public HyteraBPEncryptionRow EncryptionRow { get; private set; }

        public HyteraBPEncryptionMethodForm(HyteraBPEncryptionRow row = null)
        {
            InitializeComponent();

            Utils.FillComboBoxData(cbKeyLength, typeof(HyteraKeyLengthEnum));
            cbKeyLength.SelectedIndex = 0;

            if (row == null)
            {
                EncryptionRow = new HyteraBPEncryptionRow();
                EncryptionRow.Key = new byte[HyteraBPEncryptionRow.KEY_SIZE];
                tbFrequency.Text = Utils.GetFrequencyString(145500000);
                optionsControl.SetOptions(null);
            }
            else
            {
                EncryptionRow = row;
                tbFrequency.Text = Utils.GetFrequencyString(row.Frequency);
                optionsControl.SetOptions(row.ActivateOptions);

                if (!Utils.SetComboBoxData(cbKeyLength, row.KeyLength))
                    cbKeyLength.SelectedIndex = 0;

                if (Utils.IsArrayEmpty(row.Key))
                    tbKey.Text = string.Empty;
                else
                    tbKey.Text = Utils.BytesToHexString(row.Key).Substring(0, (int)row.KeyLength / 4);

                tbNotes.Text = row.Notes;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string errorStr;

            if (optionsControl.IsExistErrors(out errorStr))
            {
                MessageBox.Show(errorStr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Utils.ParseFrequency(tbFrequency.Text, out uint freq, out errorStr))
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

            EncryptionRow.KeyLength = (HyteraKeyLengthEnum)(cbKeyLength.SelectedItem as DisplayTagObject).Tag;
            Buffer.BlockCopy(key, 0, EncryptionRow.Key, 0, key.Length > HyteraBPEncryptionRow.KEY_SIZE ? HyteraBPEncryptionRow.KEY_SIZE : key.Length);

            EncryptionRow.Notes = tbNotes.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
