using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class KeyMappingForm : Form
    {
        public KeyMapping KeyMapping { get; private set; }

        public KeyMappingForm(ScannerModelEnum model, KeyMapping keyMapping)
        {
            InitializeComponent();

            KeyMapping = keyMapping;

            switch(model)
            {
                case ScannerModelEnum.UBCD3600XLT:
                case ScannerModelEnum.BCD436HP:
                    lblKey1.Text = "ZIP";
                    lblKey2.Text = "FUNC+ZIP";
                    lblKey3.Visible = false;
                    cbKey3Map.Visible = false;
                    break;
                case ScannerModelEnum.BCD536HP:
                    lblKey1.Text = "ZIP";
                    lblKey2.Text = "SERV";
                    lblKey3.Text = "RANG";
                    lblKey3.Visible = true;
                    cbKey3Map.Visible = true;
                    break;
                case ScannerModelEnum.SDS100:
                case ScannerModelEnum.SDS100E:
                    lblKey1.Text = "ZIP";
                    lblKey2.Text = "FUNC+ZIP";
                    lblKey3.Visible = false;
                    cbKey3Map.Visible = false;
                    break;
                case ScannerModelEnum.SDS200:
                    lblKey1.Text = "ZIP";
                    lblKey2.Text = "FUNC+ZIP";
                    lblKey3.Visible = false;
                    cbKey3Map.Visible = false;
                    break;
            }

            FillComboBoxData(cbKey1Map, model);
            FillComboBoxData(cbKey2Map, model);
            FillComboBoxData(cbKey3Map, model);

            if (KeyMapping != null)
            {
                if (!Utils.SetComboBoxData(cbKey1Map, KeyMapping.Key1))
                    Utils.SetComboBoxData(cbKey1Map, KeyMapFunctionEnum.Default);
                if (!Utils.SetComboBoxData(cbKey2Map, KeyMapping.Key2))
                    Utils.SetComboBoxData(cbKey2Map, KeyMapFunctionEnum.Default);
                if (!Utils.SetComboBoxData(cbKey3Map, KeyMapping.Key3))
                    Utils.SetComboBoxData(cbKey3Map, KeyMapFunctionEnum.Default);
            }
            else
            {
                Utils.SetComboBoxData(cbKey1Map, KeyMapFunctionEnum.Default);
                Utils.SetComboBoxData(cbKey2Map, KeyMapFunctionEnum.Default);
                Utils.SetComboBoxData(cbKey3Map, KeyMapFunctionEnum.Default);
            }
        }

        public void FillComboBoxData(ComboBox cb, ScannerModelEnum model)
        {
            cb.Items.Clear();
            foreach (KeyMapFunctionEnum item in Enum.GetValues(typeof(KeyMapFunctionEnum)))
            {
                var sa = Utils.GetAttributes<ScannerAttribute>(item);
                foreach (ScannerAttribute attr in sa)
                {
                    if (attr.Model == model)
                    {
                        cb.Items.Add(new DisplayTagObject(item));
                        break;
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (KeyMapping == null)
                KeyMapping = new KeyMapping();

            KeyMapping.Key1 = (KeyMapFunctionEnum)Utils.GetComboBoxData(cbKey1Map.SelectedItem);
            KeyMapping.Key2 = (KeyMapFunctionEnum)Utils.GetComboBoxData(cbKey2Map.SelectedItem);
            KeyMapping.Key3 = (KeyMapFunctionEnum)Utils.GetComboBoxData(cbKey3Map.SelectedItem);
        }
    }
}
