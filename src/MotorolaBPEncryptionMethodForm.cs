using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class MotorolaBPEncryptionMethodForm : Form
    {
        public MotorolaBPEncryptionRow EncryptionRow { get; private set; }

        public MotorolaBPEncryptionMethodForm(MotorolaBPEncryptionRow row = null)
        {
            InitializeComponent();

            if (row == null)
            {
                EncryptionRow = new MotorolaBPEncryptionRow();
                tbFrequency.Text = Utils.GetFrequencyString(145500000);
                optionsControl.SetOptions(null);
            }
            else
            {
                EncryptionRow = row;
                tbFrequency.Text = Utils.GetFrequencyString(row.Frequency);
                optionsControl.SetOptions(row.ActivateOptions);
                nudKey.Value = row.Key;
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
            EncryptionRow.Key = (byte)nudKey.Value;
            EncryptionRow.Notes = tbNotes.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
