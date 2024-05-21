using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class MotorolaEPEncryptionMethodForm : Form
    {
        public MotorolaEPEncryptionRow EncryptionRow { get; private set; }

        public MotorolaEPEncryptionMethodForm(MotorolaEPEncryptionRow row = null)
        {
            InitializeComponent();

            if (row == null)
            {
                EncryptionRow = new MotorolaEPEncryptionRow();
                EncryptionRow.Key = new byte[MotorolaEPEncryptionRow.KEY_SIZE];
                tbFrequency.Text = Utils.GetFrequencyString(145500000);
                optionsControl.SetOptions(null);
            }
            else
            {
                EncryptionRow = row;
                tbFrequency.Text = Utils.GetFrequencyString(row.Frequency);
                optionsControl.SetOptions(row.ActivateOptions);

                if (Utils.IsArrayEmpty(row.Key))
                    tbKey.Text = string.Empty;
                else
                    tbKey.Text = Utils.BytesToHexString(row.Key);

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

            Array.Clear(EncryptionRow.Key, 0, 5);
            if (key.Length > 0 )
                Buffer.BlockCopy(key, 0, EncryptionRow.Key, 0, key.Length > MotorolaEPEncryptionRow.KEY_SIZE ? MotorolaEPEncryptionRow.KEY_SIZE : key.Length);

            EncryptionRow.Notes = tbNotes.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
