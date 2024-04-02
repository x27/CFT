using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class EncryptionMethodForm : Form
    {
        public DmrEncryptionMethodItem Item { get; set; }

        public EncryptionMethodForm(DmrEncryptionMethodItem item = null)
        {
            InitializeComponent();

            FillComboBoxData(cbbEncryptionMethod, typeof(DmrEncryptionMethodEnum));
            FillComboBoxData(cbbKeyLength, typeof(HyteraKeyLengthEnum));
            FillComboBoxData(cbbTrunkSystem, typeof(DmrTrunkSystemEnum));
            FillComboBoxData(cbbMfid, typeof(DmrMfidEnum));
            FillComboBoxData(cbbColorCode, typeof(DmrColorCodeEnum));
            FillComboBoxData(cbbTimeSlot, typeof(DmrTimeSlotEnum));
            FillComboBoxData(cbbEncryptionValue, typeof(DmrEncyptionValueEnum));

            if (item == null)
            {
                cbbEncryptionMethod.SelectedIndex = 0;
                cbbKeyLength.SelectedIndex = 0;
                cbbTrunkSystem.SelectedIndex = 0;
                cbbMfid.SelectedIndex = 0;
                cbbColorCode.SelectedIndex = 0;
                cbbTimeSlot.SelectedIndex = 0;
                cbbEncryptionValue.SelectedIndex = 0;
                tbTgid.Text = "1";
                tbFrequency.Text = "145500000";
                tbKey.Text = string.Empty;

                cbTrunkSystem.Checked = true;
                cbMfid.Checked = true;
                cbColorCode.Checked = true;
            }
            else
            {
                cbTrunkSystem.Checked = (item.Options & DmrNeedOptionsEnum.TrunkSystem) == DmrNeedOptionsEnum.TrunkSystem;
                cbMfid.Checked = (item.Options & DmrNeedOptionsEnum.Mfid) == DmrNeedOptionsEnum.Mfid;
                cbColorCode.Checked = (item.Options & DmrNeedOptionsEnum.ColorCode) == DmrNeedOptionsEnum.ColorCode;
                cbTgid.Checked = (item.Options & DmrNeedOptionsEnum.Tgid) == DmrNeedOptionsEnum.Tgid;
                cbTimeSlot.Checked = (item.Options & DmrNeedOptionsEnum.TimeSlot) == DmrNeedOptionsEnum.TimeSlot;
                cbEncryptionValue.Checked = (item.Options & DmrNeedOptionsEnum.EncryptValue) == DmrNeedOptionsEnum.EncryptValue;

                nudMotoKey.Value = item.Key[0];

                if (!SetComboBoxData(cbbEncryptionMethod, item.EncryptionMethod))
                    cbbEncryptionMethod.SelectedIndex = 0;
                if (!SetComboBoxData(cbbKeyLength, (HyteraKeyLengthEnum)item.KeyLength))
                    cbbKeyLength.SelectedIndex = 0;
                if (!SetComboBoxData(cbbTrunkSystem, item.TrunkSystem))
                    cbbTrunkSystem.SelectedIndex = 0;
                if (!SetComboBoxData(cbbMfid, item.Mfid))
                    cbbMfid.SelectedIndex = 0;
                if (!SetComboBoxData(cbbColorCode, item.ColorCode))
                    cbbColorCode.SelectedIndex = 0;
                if (!SetComboBoxData(cbbTimeSlot, item.TimeSlot))
                    cbbTimeSlot.SelectedIndex = 0;
                if (!SetComboBoxData(cbbEncryptionValue, item.EncryptionValue))
                    cbbEncryptionValue.SelectedIndex = 0;

                tbTgid.Text = item.Tgid.ToString();
                tbFrequency.Text = item.Frequency.ToString();
                if (Utils.IsArrayEmpty(item.Key))
                    tbKey.Text = string.Empty;
                else
                    tbKey.Text = Utils.BytesToHexString(item.Key).Substring(0, (int)item.KeyLength / 4);
            }

            ControlsUpdate();
        }

        private void ControlsUpdate()
        {
            var me = cbbEncryptionMethod.SelectedItem as DisplayTagObject;

            if (me == null)
            {
                cbbKeyLength.Visible = false;
                tbKey.Visible = false;
                lblKey.Visible = false;
                lblKeyExt.Visible = false;
                nudMotoKey.Visible = false;
                lblLen.Visible = false;
            }
            else
            {
                var method = (DmrEncryptionMethodEnum)me.Tag;
                switch(method)
                {
                    case DmrEncryptionMethodEnum.NoEncrypt:
                        cbbKeyLength.Visible = false;
                        tbKey.Visible = false;
                        lblKey.Visible = false;
                        lblKeyExt.Visible = false;
                        nudMotoKey.Visible = false;
                        lblLen.Visible = false;
                        break;
                    case DmrEncryptionMethodEnum.HyteraBP:
                        cbbKeyLength.Visible = true;
                        tbKey.Visible = true;
                        lblKey.Visible = true;
                        lblKeyExt.Text = "Key Length:";
                        lblKeyExt.Visible = true;
                        nudMotoKey.Visible = false;
                        lblLen.Visible = true;
                        break;
                    case DmrEncryptionMethodEnum.MotorolaBP:
                        cbbKeyLength.Visible = false;
                        tbKey.Visible = false;
                        lblKey.Visible = false;
                        lblKeyExt.Text = "Key (DEC):";
                        lblKeyExt.Visible = true;
                        nudMotoKey.Visible = true;
                        lblLen.Visible = false;
                        break;
                }
            }

            cbbTrunkSystem.Enabled = cbTrunkSystem.Checked;
            cbbMfid.Enabled = cbMfid.Checked;
            tbFrequency.Enabled = cbFrequency.Checked;
            cbbColorCode.Enabled = cbColorCode.Checked;
            tbTgid.Enabled = cbTgid.Checked;
            cbbTimeSlot.Enabled = cbTimeSlot.Checked;
            cbbEncryptionValue.Enabled = cbEncryptionValue.Checked;
        }

        private void FillComboBoxData(ComboBox cb, Type type)
        {
            cb.Items.Clear();
            foreach (var item in Enum.GetValues(type))
                cb.Items.Add(new DisplayTagObject(item));
        }

        private bool SetComboBoxData(ComboBox comboBox, object o)
        {
            try
            {
                foreach (var item in comboBox.Items)
                {
                    var me = item as DisplayTagObject;
                    if (me.Tag != null && me.Tag.Equals(o))
                    {
                        comboBox.SelectedItem = me;
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var options = 0;
            if (cbTrunkSystem.Checked)
                options |= (int)DmrNeedOptionsEnum.TrunkSystem;
            if (cbMfid.Checked)
                options |= (int)DmrNeedOptionsEnum.Mfid;
            if (cbFrequency.Checked)
                options |= (int)DmrNeedOptionsEnum.Frequency;
            if (cbColorCode.Checked)
                options |= (int)DmrNeedOptionsEnum.ColorCode;
            if (cbTgid.Checked)
                options |= (int)DmrNeedOptionsEnum.Tgid;
            if (cbTimeSlot.Checked)
                options |= (int)DmrNeedOptionsEnum.TimeSlot;
            if (cbEncryptionValue.Checked)
                options |= (int)DmrNeedOptionsEnum.EncryptValue;

            if (options == 0)
            {
                MessageBox.Show("Take at least one option!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!uint.TryParse(tbFrequency.Text.Trim(), out uint frequency))
            {
                tbFrequency.Focus();
                MessageBox.Show("Wrong frequency value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frequency <= 25e6 ||  frequency > 1300e6)
            {
                tbFrequency.Focus();
                MessageBox.Show("Wrong frequency value (must be between 25MHz and 1300Mhz)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!uint.TryParse(tbTgid.Text.Trim(), System.Globalization.NumberStyles.Number, null, out uint tgid))
            {
                tbTgid.Focus();
                MessageBox.Show("Wrong TGID value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            var item = new DmrEncryptionMethodItem();

            item.Frequency = frequency;

            var method = (DmrEncryptionMethodEnum)(cbbEncryptionMethod.SelectedItem as DisplayTagObject).Tag;

            item.Options = (DmrNeedOptionsEnum)options;
            item.TrunkSystem = (DmrTrunkSystemEnum)(cbbTrunkSystem.SelectedItem as DisplayTagObject).Tag;
            item.Mfid = (DmrMfidEnum)(cbbMfid.SelectedItem as DisplayTagObject).Tag;
            item.ColorCode = (DmrColorCodeEnum)(cbbColorCode.SelectedItem as DisplayTagObject).Tag;
            item.TimeSlot = (DmrTimeSlotEnum)(cbbTimeSlot.SelectedItem as DisplayTagObject).Tag;
            item.EncryptionValue = (DmrEncyptionValueEnum)(cbbEncryptionValue.SelectedItem as DisplayTagObject).Tag;
            item.EncryptionMethod = method;

            if (method == DmrEncryptionMethodEnum.HyteraBP)
                item.KeyLength = (ushort)(cbbKeyLength.SelectedItem as DisplayTagObject).Tag;
            else
                item.KeyLength = 0;
            item.Tgid = tgid;

            if (method == DmrEncryptionMethodEnum.NoEncrypt)
                Array.Clear(item.Key, 0, DmrEncryptionMethodItem.ENC_METHOD_KEY_LEN);
            else if (method == DmrEncryptionMethodEnum.MotorolaBP)
                item.Key[0] = (byte)nudMotoKey.Value;
            else
            {
                var bs = Utils.HexStringToBytes(tbKey.Text);
                Buffer.BlockCopy(bs, 0, item.Key, 0, key.Length > DmrEncryptionMethodItem.ENC_METHOD_KEY_LEN ? DmrEncryptionMethodItem.ENC_METHOD_KEY_LEN : key.Length);
            }

            Item = item;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            ControlsUpdate();
        }

        private void tbKey_TextChanged(object sender, EventArgs e)
        {
            var len = tbKey.Text.Length;
            lblLen.Visible = len > 0;
            lblLen.Text = len.ToString();
        }
    }
}
