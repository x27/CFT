﻿using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class DmrAesEncryptionMethodForm : Form
    {
        public DmrAesEncryptionRow EncryptionRow { get; private set; }
        public bool IsBatchMode { get; private set; }

        public DmrAesEncryptionMethodForm(DmrAesEncryptionRow row = null, bool batchMode = false)
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

            Utils.FillComboBoxData(cbKeyLength, typeof(DmrAesKeyLengthEnum));
            cbKeyLength.SelectedIndex = 0;

            if (row == null)
            {
                EncryptionRow = new DmrAesEncryptionRow();
                EncryptionRow.Key = new byte[DmrAesEncryptionRow.KEY_SIZE];
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

                cbKeyID.Checked = row.ActivateOptions.IsActivated(DmrSelectedActivateOptionsEnum.KeyId);
                if (cbKeyID.Checked)
                    tbKeyID.Text = row.ActivateOptions.KeyId.ToString();

                if (row.KeyLength == 128)
                    Utils.SetComboBoxData(cbKeyLength, DmrAesKeyLengthEnum.L128);
                else if (row.KeyLength == 192)
                    Utils.SetComboBoxData(cbKeyLength, DmrAesKeyLengthEnum.L192);
                else if (row.KeyLength == 256)
                    Utils.SetComboBoxData(cbKeyLength, DmrAesKeyLengthEnum.L256);
                else
                {
                    cbKeyLength.Enabled = false;
                }

                if (Utils.IsArrayEmpty(row.Key))
                    tbKey.Text = string.Empty;
                else
                    tbKey.Text = Utils.BytesToHexString(row.Key).Substring(0, (int)(row.KeyLength / 4 + (row.KeyLength % 4 != 0 ? 1 : 0)));

                tbNotes.Text = row.Notes;
            }

            cbKeyID_CheckedChanged(this, null);
            OptionsControl_OptionChanged(this, null);
        }

        private void OptionsControl_OptionChanged(object sender, EventArgs e)
        {
            tbFrequency.Enabled = optionsControl.Options.IsActivated(DmrSelectedActivateOptionsEnum.Frequency);
            cbKeyLength.Enabled = !optionsControl.Options.IsActivated(DmrSelectedActivateOptionsEnum.ForceMute);
            tbKey.Enabled = !optionsControl.Options.IsActivated(DmrSelectedActivateOptionsEnum.ForceMute);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string errorStr;

            if (optionsControl.IsExistErrors(out errorStr))
            {
                if (!errorStr.Contains("no Frequency") || !cbKeyID.Checked)
                {
                    MessageBox.Show(errorStr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            uint freq = 0;
            if (!IsBatchMode && !Utils.ParseFrequency(tbFrequency.Text, out freq, out errorStr))
            {
                tbFrequency.Focus();
                MessageBox.Show(errorStr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte keyID = 0;
            if (cbKeyID.Checked)
            {
                try
                {
                    keyID = byte.Parse(tbKeyID.Text);
                }
                catch
                {
                    MessageBox.Show("Wrong KeyID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbKeyID.Focus();
                    return;
                }
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

            EncryptionRow.KeyLength = (ushort)(DmrAesKeyLengthEnum)(cbKeyLength.SelectedItem as DisplayTagObject).Tag;
            Buffer.BlockCopy(key, 0, EncryptionRow.Key, 0, key.Length > DmrAesEncryptionRow.KEY_SIZE ? DmrAesEncryptionRow.KEY_SIZE : key.Length);

            if (cbKeyID.Checked)
            {
                EncryptionRow.ActivateOptions.Activate(DmrSelectedActivateOptionsEnum.KeyId);
                EncryptionRow.ActivateOptions.KeyId = keyID;
            }
            else
            {
                EncryptionRow.ActivateOptions.Deactivate(DmrSelectedActivateOptionsEnum.KeyId);
            }


            EncryptionRow.Notes = tbNotes.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cbKeyID_CheckedChanged(object sender, EventArgs e)
        {
            tbKeyID.Enabled = cbKeyID.Checked;
        }
    }
}