using System;
using System.Globalization;
using System.Windows.Forms;

namespace CFT
{
    public partial class P25ActivateOptionsControl : UserControl
    {
        public P25ActivateOptions Options { get; set; }
        public bool HasErrors { get; private set; }

        private bool _changedByUser = true;

        public P25ActivateOptionsControl()
        {
            InitializeComponent();
        }

        private void ControlsEnabled()
        {
            tbNAC.Enabled = cbNAC.Checked;
            tbKeyID.Enabled = cbKeyID.Checked;
            tbSourceID.Enabled = cbSourceID.Checked;
            tbGroupID.Enabled = cbGroupID.Checked;
        }

        public void SetOptions(P25ActivateOptions options)
        {
            if (options == null)
                Options = new P25ActivateOptions();
            else
                Options = Utils.DeepClone(options);

            _changedByUser = false;

            cbNAC.Checked = Options.IsActivated(P25SelectedActivateOptionsEnum.NAC);
            cbKeyID.Checked = Options.IsActivated(P25SelectedActivateOptionsEnum.KeyID);
            cbSourceID.Checked = Options.IsActivated(P25SelectedActivateOptionsEnum.SourceID);
            cbGroupID.Checked = Options.IsActivated(P25SelectedActivateOptionsEnum.GroupID);
            cbSilence.Checked = Options.IsActivated(P25SelectedActivateOptionsEnum.Silence);

            tbNAC.Text = Options.NAC.ToString();
            tbGroupID.Text = Options.GroupID.ToString();
            tbKeyID.Text = Options.KeyID.ToString();
            tbSourceID.Text = Options.SourceID.ToString();

            ControlsEnabled();

            _changedByUser = true;
        }
        private void eventOptionChanged(object sender, EventArgs e)
        {
            if (Options == null || !_changedByUser) return;

            var options = 0;
            if (cbNAC.Checked)
                options |= (int)P25SelectedActivateOptionsEnum.NAC;
            if (cbKeyID.Checked)
                options |= (int)P25SelectedActivateOptionsEnum.KeyID;
            if (cbSourceID.Checked)
                options |= (int)P25SelectedActivateOptionsEnum.SourceID;
            if (cbGroupID.Checked)
                options |= (int)P25SelectedActivateOptionsEnum.GroupID;
            if (cbSilence.Checked)
                options |= (int)DmrSelectedActivateOptionsEnum.Silence;

            Options.Options = (P25SelectedActivateOptionsEnum)options;

            if (cbGroupID.Checked && uint.TryParse(tbGroupID.Text.Trim(), NumberStyles.Number, null, out uint tgid))
                Options.GroupID = tgid;

            if (cbSourceID.Checked && uint.TryParse(tbSourceID.Text.Trim(), NumberStyles.Number, null, out uint sourceID))
                Options.SourceID = sourceID;

            if (cbNAC.Checked && ushort.TryParse(tbNAC.Text.Trim(), NumberStyles.Number, null, out ushort nac))
                Options.NAC = nac;

            if (cbKeyID.Checked && ushort.TryParse(tbKeyID.Text.Trim(), NumberStyles.Number, null, out ushort keyID))
                Options.KeyID = keyID;

            ControlsEnabled();
        }

        public bool IsExistErrors(out string errorStr)
        {
            errorStr = string.Empty;
            
            uint groupID = 0;
            if (cbGroupID.Checked && !uint.TryParse(tbGroupID.Text.Trim(), NumberStyles.Number, null, out groupID))
            {
                tbGroupID.Focus();
                errorStr = "Wrong GroupID value!";
                return true;
            }

            if (groupID > 16777215)
            {
                tbGroupID.Focus();
                errorStr = $"Wrong GroupID value (0-16777215): {groupID}!";
                return true;
            }

            uint sourceID = 0;
            if (cbSourceID.Checked && !uint.TryParse(tbSourceID.Text.Trim(), NumberStyles.Number, null, out sourceID))
            {
                tbSourceID.Focus();
                errorStr = "Wrong SourceID value!";
                return true;
            }

            if (sourceID > 16777215)
            {
                tbSourceID.Focus();
                errorStr = $"Wrong SourceID value (0-16777215): {sourceID}!";
                return true;
            }

            if (cbKeyID.Checked && !ushort.TryParse(tbKeyID.Text.Trim(), NumberStyles.Number, null, out ushort keyID))
            {
                tbKeyID.Focus();
                errorStr = "Wrong KeyID value!";
                return true;
            }

            ushort nac = 0;
            if (cbNAC.Checked && !ushort.TryParse(tbNAC.Text.Trim(), NumberStyles.Number, null, out nac))
            {
                tbNAC.Focus();
                errorStr = "Wrong NAC value!";
                return true;
            }

            if (nac > 4095)
            {
                tbNAC.Focus();
                errorStr = $"Wrong NAC value (0-4096): {nac}!";
                return true;
            }


            return false;
        }
    }
}
