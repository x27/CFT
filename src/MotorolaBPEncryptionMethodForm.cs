using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class MotorolaBPEncryptionMethodForm : Form
    {
        public MotorolaBPEncryptionRow EncryptionRow { get; private set; }

        public bool IsBatchMode { get; private set; }

        public MotorolaBPEncryptionMethodForm(MotorolaBPEncryptionRow row = null, bool batchMode = false)
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
                EncryptionRow = new MotorolaBPEncryptionRow();
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
                nudKey.Value = row.Key;
                tbNotes.Text = row.Notes;
            }
            OptionsControl_OptionChanged(this, null);
        }

        private void OptionsControl_OptionChanged(object sender, EventArgs e)
        {
            tbFrequency.Enabled = optionsControl.Options.IsActivated(DmrSelectedActivateOptionsEnum.Frequency);
            nudKey.Enabled = !optionsControl.Options.IsActivated(DmrSelectedActivateOptionsEnum.ForceMute);
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
            EncryptionRow.Key = (byte)nudKey.Value;
            EncryptionRow.Notes = tbNotes.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
