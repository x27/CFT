
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

            if (licensing != null)
            {
                tbHyteraBPUnlockKey.Text = Utils.IsArrayEmpty(licensing.HyteraBPUnlockKey) ? string.Empty : Utils.BytesToHexString(licensing.HyteraBPUnlockKey);
                tbMotoBPUnlockKey.Text = Utils.IsArrayEmpty(licensing.MotorolaBPUnlockKey) ? string.Empty : Utils.BytesToHexString(licensing.MotorolaBPUnlockKey);
                tbNxdnScramblerUnlockKey.Text = Utils.IsArrayEmpty(licensing.NxdnScramblerUnlockKey) ? string.Empty : Utils.BytesToHexString(licensing.NxdnScramblerUnlockKey);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            byte[] m, h, n;
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

            try
            {
                n = Utils.HexStringToBytes(tbNxdnScramblerUnlockKey.Text);
            }
            catch
            {
                MessageBox.Show("Wrong NXDN Scrambler Unlock Key format.\r\nMust be HEX!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbNxdnScramblerUnlockKey.Focus();
                return;
            }

            Licensing = new Licensing();

            if (Licensing.HyteraBPUnlockKey == null)
                Licensing.HyteraBPUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];

            if (Licensing.MotorolaBPUnlockKey == null)
                Licensing.MotorolaBPUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];

            if (Licensing.NxdnScramblerUnlockKey == null)
                Licensing.NxdnScramblerUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];

            Buffer.BlockCopy(h, 0, Licensing.HyteraBPUnlockKey, 0, h.Length > Licensing.UNLOCK_KEY_LEN ? Licensing.UNLOCK_KEY_LEN : h.Length);
            Buffer.BlockCopy(m, 0, Licensing.MotorolaBPUnlockKey, 0, m.Length > Licensing.UNLOCK_KEY_LEN ? Licensing.UNLOCK_KEY_LEN : m.Length);
            Buffer.BlockCopy(n, 0, Licensing.NxdnScramblerUnlockKey, 0, n.Length > Licensing.UNLOCK_KEY_LEN ? Licensing.UNLOCK_KEY_LEN : n.Length);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
