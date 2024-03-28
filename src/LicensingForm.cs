
using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class LicensingForm : Form
    {
        public Licensing Licensing { get; set; }

        public LicensingForm(Licensing licensing)
        {
            InitializeComponent();

            tbHyteraBPUnlockKey.Text = Utils.IsArrayEmpty(licensing.HyteraBPUnlockKey) ? string.Empty : Utils.BytesToHexString(licensing.HyteraBPUnlockKey);
            tbMotoBPUnlockKey.Text = Utils.IsArrayEmpty(licensing.MotorolaBPUnlockKey) ? string.Empty : Utils.BytesToHexString(licensing.MotorolaBPUnlockKey);
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            byte[] m, h;
            try
            {
                h = Utils.HexStringToBytes(tbHyteraBPUnlockKey.Text);
            }
            catch
            {
                MessageBox.Show("Wrong Hytera BP Unlock Key format.\r\nMust be HEX!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbHyteraBPUnlockKey.Focus();
                return;
            }
            try
            {
                m = Utils.HexStringToBytes(tbMotoBPUnlockKey.Text);
            }
            catch
            {
                MessageBox.Show("Wrong Motorola BP Unlock Key format.\r\nMust be HEX!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbMotoBPUnlockKey.Focus();
                return;
            }

            Licensing = new Licensing();
            Buffer.BlockCopy(h, 0, Licensing.HyteraBPUnlockKey, 0, h.Length > Licensing.UNLOCK_KEY_LEN ? Licensing.UNLOCK_KEY_LEN : h.Length);
            Buffer.BlockCopy(m, 0, Licensing.MotorolaBPUnlockKey, 0, m.Length > Licensing.UNLOCK_KEY_LEN ? Licensing.UNLOCK_KEY_LEN : m.Length);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
