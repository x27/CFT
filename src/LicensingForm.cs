
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
                tbMotoEPUnlockKey.Text = Utils.IsArrayEmpty(licensing.MotorolaEPUnlockKey) ? string.Empty : Utils.BytesToHexString(licensing.MotorolaEPUnlockKey);
                tbNxdnScramblerUnlockKey.Text = Utils.IsArrayEmpty(licensing.NxdnScramblerUnlockKey) ? string.Empty : Utils.BytesToHexString(licensing.NxdnScramblerUnlockKey);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            byte[] mb, me, hb, ns;
            try
            {
                hb = Utils.HexStringToBytes(tbHyteraBPUnlockKey.Text);
            }
            catch
            {
                MessageBox.Show("Wrong Hytera BP Unlock Key format.\r\nMust be HEX!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbHyteraBPUnlockKey.Focus();
                return;
            }
            try
            {
                mb = Utils.HexStringToBytes(tbMotoBPUnlockKey.Text);
            }
            catch
            {
                MessageBox.Show("Wrong Motorola BP Unlock Key format.\r\nMust be HEX!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbMotoBPUnlockKey.Focus();
                return;
            }
            try
            {
                me = Utils.HexStringToBytes(tbMotoEPUnlockKey.Text);
            }
            catch
            {
                MessageBox.Show("Wrong Motorola EP Unlock Key format.\r\nMust be HEX!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbMotoEPUnlockKey.Focus();
                return;
            }

            try
            {
                ns = Utils.HexStringToBytes(tbNxdnScramblerUnlockKey.Text);
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

            if (Licensing.MotorolaEPUnlockKey == null)
                Licensing.MotorolaEPUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];

            if (Licensing.NxdnScramblerUnlockKey == null)
                Licensing.NxdnScramblerUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];

            Buffer.BlockCopy(hb, 0, Licensing.HyteraBPUnlockKey, 0, hb.Length > Licensing.UNLOCK_KEY_LEN ? Licensing.UNLOCK_KEY_LEN : hb.Length);
            Buffer.BlockCopy(mb, 0, Licensing.MotorolaBPUnlockKey, 0, mb.Length > Licensing.UNLOCK_KEY_LEN ? Licensing.UNLOCK_KEY_LEN : mb.Length);
            Buffer.BlockCopy(me, 0, Licensing.MotorolaEPUnlockKey, 0, me.Length > Licensing.UNLOCK_KEY_LEN ? Licensing.UNLOCK_KEY_LEN : me.Length);
            Buffer.BlockCopy(ns, 0, Licensing.NxdnScramblerUnlockKey, 0, ns.Length > Licensing.UNLOCK_KEY_LEN ? Licensing.UNLOCK_KEY_LEN : ns.Length);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
