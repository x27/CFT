using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class DmrActivateOptionsControl : UserControl
    {
        public DmrActivateOptions Options { get; set; }
        public bool HasErrors { get; private set; }

        public event EventHandler OptionChanged;

        private bool _changedByUser = true;

        public DmrActivateOptionsControl()
        {
            InitializeComponent();

            Utils.FillComboBoxData(cbbTrunkSystem, typeof(DmrTrunkSystemEnum));
            cbbTrunkSystem.SelectedIndex = 0;
            Utils.FillComboBoxData(cbbMfid, typeof(DmrMfidEnum));
            cbbMfid.SelectedIndex = 0;
            Utils.FillComboBoxData(cbbColorCode, typeof(DmrColorCodeEnum));
            cbbColorCode.SelectedIndex = 0;
            Utils.FillComboBoxData(cbbTimeSlot, typeof(DmrTimeSlotEnum));
            cbbTimeSlot.SelectedIndex = 0;
            Utils.FillComboBoxData(cbbEncryptionValue, typeof(DmrEncyptionValueEnum));
            cbbEncryptionValue.SelectedIndex = 0;
        }

        private void ControlsEnabled()
        {
            cbbTrunkSystem.Enabled = cbTrunkSystem.Checked;
            cbbMfid.Enabled = cbMFID.Checked;
            cbbColorCode.Enabled = cbColorCode.Checked;
            tbTGID.Enabled = cbTGID.Checked;
            cbbTimeSlot.Enabled = cbTimeSlot.Checked;
            cbbEncryptionValue.Enabled = cbEncryptionValue.Checked;
        }

        public void SetOptions(DmrActivateOptions options)
        {
            if (options == null)
                Options = new DmrActivateOptions();
            else
                Options = Utils.DeepClone(options);

            _changedByUser = false;

            cbTrunkSystem.Checked = Options.IsActivated(DmrSelectedActivateOptionsEnum.TrunkSystem);
            cbMFID.Checked = Options.IsActivated(DmrSelectedActivateOptionsEnum.MFID);
            cbColorCode.Checked = Options.IsActivated(DmrSelectedActivateOptionsEnum.ColorCode);
            cbTGID.Checked = Options.IsActivated(DmrSelectedActivateOptionsEnum.TGID);
            cbTimeSlot.Checked = Options.IsActivated(DmrSelectedActivateOptionsEnum.TimeSlot);
            cbEncryptionValue.Checked = Options.IsActivated(DmrSelectedActivateOptionsEnum.EncryptValue);
            cbForceMute.Checked = Options.IsActivated(DmrSelectedActivateOptionsEnum.ForceMute);
            cbFrequency.Checked = Options.IsActivated(DmrSelectedActivateOptionsEnum.Frequency);

            if (!Utils.SetComboBoxData(cbbTrunkSystem, Options.TrunkSystem))
                cbbTrunkSystem.SelectedIndex = 0;
            if (!Utils.SetComboBoxData(cbbMfid, Options.MFID))
                cbbMfid.SelectedIndex = 0;
            if (!Utils.SetComboBoxData(cbbColorCode, Options.ColorCode))
                cbbColorCode.SelectedIndex = 0;
            if (!Utils.SetComboBoxData(cbbTimeSlot, Options.TimeSlot))
                cbbTimeSlot.SelectedIndex = 0;
            if (!Utils.SetComboBoxData(cbbEncryptionValue, Options.EncryptionValue))
                cbbEncryptionValue.SelectedIndex = 0;

            tbTGID.Text = Options.TGID.ToString();

            ControlsEnabled();

            _changedByUser = true;
        }
        private void eventOptionChanged(object sender, EventArgs e)
        {
            if (Options == null || !_changedByUser) return;

            var options = 0;
            if (cbTrunkSystem.Checked)
                options |= (int)DmrSelectedActivateOptionsEnum.TrunkSystem;
            if (cbMFID.Checked)
                options |= (int)DmrSelectedActivateOptionsEnum.MFID;
            if (cbColorCode.Checked)
                options |= (int)DmrSelectedActivateOptionsEnum.ColorCode;
            if (cbTGID.Checked)
                options |= (int)DmrSelectedActivateOptionsEnum.TGID;
            if (cbTimeSlot.Checked)
                options |= (int)DmrSelectedActivateOptionsEnum.TimeSlot;
            if (cbEncryptionValue.Checked)
                options |= (int)DmrSelectedActivateOptionsEnum.EncryptValue;
            if (cbForceMute.Checked)
                options |= (int)DmrSelectedActivateOptionsEnum.ForceMute;
            if (cbFrequency.Checked)
                options |= (int)DmrSelectedActivateOptionsEnum.Frequency;

            Options.Options = (DmrSelectedActivateOptionsEnum)options;

            Options.TrunkSystem = (DmrTrunkSystemEnum)(cbbTrunkSystem.SelectedItem as DisplayTagObject).Tag;
            Options.MFID = (DmrMfidEnum)(cbbMfid.SelectedItem as DisplayTagObject).Tag;
            Options.ColorCode = (DmrColorCodeEnum)(cbbColorCode.SelectedItem as DisplayTagObject).Tag;
            Options.TimeSlot = (DmrTimeSlotEnum)(cbbTimeSlot.SelectedItem as DisplayTagObject).Tag;
            Options.EncryptionValue = (DmrEncyptionValueEnum)(cbbEncryptionValue.SelectedItem as DisplayTagObject).Tag;

            if (cbTGID.Checked && uint.TryParse(tbTGID.Text.Trim(), System.Globalization.NumberStyles.Number, null, out uint tgid))
                Options.TGID = tgid;
            
            ControlsEnabled();

            if (OptionChanged != null)
                OptionChanged(this, EventArgs.Empty);
        }

        public bool IsExistErrors(out string errorStr)
        {
            errorStr = string.Empty;
            if (cbTGID.Checked && !uint.TryParse(tbTGID.Text.Trim(), System.Globalization.NumberStyles.Number, null, out uint tgid))
            {
                tbTGID.Focus();
                errorStr = "Wrong TGID value!";
                return true;
            }

            if (!cbFrequency.Checked && !(cbTrunkSystem.Checked || cbMFID.Checked || cbColorCode.Checked || cbTGID.Checked))
            {
                errorStr = "When no Frequency is selected then Trunk System, MFID, Color Code or TGID must be selected!";
                return true;
            }

            return false;
        }
    }
}
