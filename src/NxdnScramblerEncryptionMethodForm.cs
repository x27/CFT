using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class NxdnScramblerEncryptionMethodForm : Form
    {
        public NxdnScramblerEncryptionRow EncryptionRow { get; private set; }

        public NxdnScramblerEncryptionMethodForm(NxdnScramblerEncryptionRow row = null)
        {
            InitializeComponent();

            if (row == null)
            {
                EncryptionRow = new NxdnScramblerEncryptionRow();
                EncryptionRow.ActivateOptions = new NxdnActivateOptions();
                tbFrequency.Text = Utils.GetFrequencyString(145500000);
            }
            else
            {
                EncryptionRow = row;
                tbFrequency.Text = Utils.GetFrequencyString(row.Frequency);
                cbRAN.Checked = row.ActivateOptions.IsActivated(NxdnSelectedActivateOptionsEnum.RAN);
                cbGroupID.Checked = row.ActivateOptions.IsActivated(NxdnSelectedActivateOptionsEnum.GroupID);
                if (cbRAN.Checked) 
                    tbRAN.Text = row.ActivateOptions.RAN.ToString();
                if (cbGroupID.Checked)
                    tbGroupID.Text = row.ActivateOptions.GroupID.ToString();
                nudKey.Value = row.Key;
                tbNotes.Text = row.Notes;
            }
            cb_CheckedChanged(this, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string errorStr;
            byte ran = 0;
            ushort groupID = 0;

            if (!Utils.ParseFrequency(tbFrequency.Text, out uint freq, out errorStr))
            {
                tbFrequency.Focus();
                MessageBox.Show(errorStr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbRAN.Checked && !byte.TryParse(tbRAN.Text.Trim(), System.Globalization.NumberStyles.Number, null, out ran))
            {
                tbRAN.Focus();
                MessageBox.Show("Wrong RAN value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ran > 63)
            {
                tbRAN.Focus();
                MessageBox.Show("RAN value must be less 64!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbGroupID.Checked && !ushort.TryParse(tbGroupID.Text.Trim(), System.Globalization.NumberStyles.Number, null, out groupID))
            {
                tbGroupID.Focus();
                MessageBox.Show("Wrong Group ID value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EncryptionRow.ActivateOptions.Options = 0;
            if (cbGroupID.Checked)
                EncryptionRow.ActivateOptions.Options |= NxdnSelectedActivateOptionsEnum.GroupID;
            if (cbRAN.Checked)
                EncryptionRow.ActivateOptions.Options |= NxdnSelectedActivateOptionsEnum.RAN;

            EncryptionRow.Frequency = freq;
            EncryptionRow.ActivateOptions.RAN = ran;
            EncryptionRow.ActivateOptions.GroupID = groupID;
            EncryptionRow.Key = (ushort)nudKey.Value;
            EncryptionRow.Notes = tbNotes.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            tbRAN.Enabled = cbRAN.Checked;
            tbGroupID.Enabled = cbGroupID.Checked;  
        }
    }
}
