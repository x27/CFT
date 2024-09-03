using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class NxdnScramblerEncryptionMethodForm : Form
    {
        public NxdnScramblerEncryptionRow EncryptionRow { get; private set; }
        public bool IsBatchMode { get; private set; }

        public NxdnScramblerEncryptionMethodForm(NxdnScramblerEncryptionRow row = null, bool batchMode = false)
        {
            InitializeComponent();

            IsBatchMode = batchMode;
            if (IsBatchMode)
            {
                Text += " (Batch mode)";
                tbFrequency.Enabled = false;
                tbNotes.Enabled = false;
            }

            if (row == null)
            {
                EncryptionRow = new NxdnScramblerEncryptionRow();
                EncryptionRow.ActivateOptions = new NxdnActivateOptions();
                if (!IsBatchMode)
                    tbFrequency.Text = Utils.GetFrequencyString(145500000);
                cbFrequency.Checked = EncryptionRow.ActivateOptions.IsActivated(NxdnSelectedActivateOptionsEnum.Frequency);
            }
            else
            {
                EncryptionRow = row;
                if (!IsBatchMode)
                    tbFrequency.Text = Utils.GetFrequencyString(row.Frequency);

                cbRAN.Checked = row.ActivateOptions.IsActivated(NxdnSelectedActivateOptionsEnum.RAN);
                cbGroupID.Checked = row.ActivateOptions.IsActivated(NxdnSelectedActivateOptionsEnum.GroupID);
                cbKeyId.Checked = row.ActivateOptions.IsActivated(NxdnSelectedActivateOptionsEnum.KeyID);
                cbSourceID.Checked = row.ActivateOptions.IsActivated(NxdnSelectedActivateOptionsEnum.SourceID);
                cbForceMute.Checked = row.ActivateOptions.IsActivated(NxdnSelectedActivateOptionsEnum.ForceMute);
                cbFrequency.Checked = row.ActivateOptions.IsActivated(NxdnSelectedActivateOptionsEnum.Frequency);

                if (cbRAN.Checked) 
                    tbRAN.Text = row.ActivateOptions.RAN.ToString();
                if (cbGroupID.Checked)
                    tbGroupID.Text = row.ActivateOptions.GroupID.ToString();
                if (cbKeyId.Checked)
                    tbKeyId.Text = row.ActivateOptions.KeyID.ToString();
                if (cbSourceID.Checked)
                    tbSourceID.Text = row.ActivateOptions.SourceID.ToString();
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
            byte keyID = 0;
            ushort sourceID = 0;

            uint freq = 0;
            if (!IsBatchMode && !Utils.ParseFrequency(tbFrequency.Text, out freq, out errorStr))
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

            if (cbKeyId.Checked && !byte.TryParse(tbKeyId.Text.Trim(), System.Globalization.NumberStyles.Number, null, out keyID))
            {
                tbKeyId.Focus();
                MessageBox.Show("Wrong Key ID value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (keyID > 63)
            {
                tbKeyId.Focus();
                MessageBox.Show("Key Id value must be less 64!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbSourceID.Checked && !ushort.TryParse(tbSourceID.Text.Trim(), System.Globalization.NumberStyles.Number, null, out sourceID))
            {
                tbSourceID.Focus();
                MessageBox.Show("Wrong Source ID value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!cbFrequency.Checked && !(cbRAN.Checked || cbGroupID.Checked || cbSourceID.Checked || cbKeyId.Checked))
            {
                MessageBox.Show("When no Frequency is selected then RAN, Group ID, Source ID or Key ID must be selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EncryptionRow.ActivateOptions.Options = 0;
            if (cbGroupID.Checked)
                EncryptionRow.ActivateOptions.Options |= NxdnSelectedActivateOptionsEnum.GroupID;
            if (cbRAN.Checked)
                EncryptionRow.ActivateOptions.Options |= NxdnSelectedActivateOptionsEnum.RAN;
            if (cbKeyId.Checked)
                EncryptionRow.ActivateOptions.Options |= NxdnSelectedActivateOptionsEnum.KeyID;
            if (cbSourceID.Checked)
                EncryptionRow.ActivateOptions.Options |= NxdnSelectedActivateOptionsEnum.SourceID;
            if (cbForceMute.Checked)
                EncryptionRow.ActivateOptions.Options |= NxdnSelectedActivateOptionsEnum.ForceMute;
            if (cbFrequency.Checked)
                EncryptionRow.ActivateOptions.Options |= NxdnSelectedActivateOptionsEnum.Frequency;

            EncryptionRow.Frequency = freq;
            EncryptionRow.ActivateOptions.RAN = ran;
            EncryptionRow.ActivateOptions.GroupID = groupID;
            EncryptionRow.ActivateOptions.SourceID = sourceID;
            EncryptionRow.ActivateOptions.KeyID = keyID;
            EncryptionRow.Key = (ushort)nudKey.Value;
            EncryptionRow.Notes = tbNotes.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            tbRAN.Enabled = cbRAN.Checked;
            tbGroupID.Enabled = cbGroupID.Checked;
            tbKeyId.Enabled = cbKeyId.Checked;
            tbSourceID.Enabled = cbSourceID.Checked;
            nudKey.Enabled = !cbForceMute.Checked;
            tbFrequency.Enabled = cbFrequency.Checked;
        }
    }
}
