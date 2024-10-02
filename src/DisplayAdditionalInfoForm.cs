using System;
using System.Reflection;
using System.Windows.Forms;

namespace CFT
{
    public partial class DisplayAdditionalInfoForm : Form
    {
        public DisplayAdditionalInfo DisplayAdditionalInfo { get; private set; }
        public ScannerModelEnum Model { get; private set; }

        public DisplayAdditionalInfoForm(ScannerModelEnum model, DisplayAdditionalInfo additionalInfo)
        {
            InitializeComponent();

            Model = model;
            DisplayAdditionalInfo = additionalInfo;

            if (Scanner.GetBaseModel(model) == ScannerBaseModelEnum.BCD)
            {
                FillComboBoxData(cbLine0);
                FillComboBoxData(cbLine1);

                if (DisplayAdditionalInfo != null)
                {
                    if (!Utils.SetComboBoxData(cbLine0, DisplayAdditionalInfo.Line0))
                        Utils.SetComboBoxData(cbLine0, DisplayAdditionalInfoValuesEnum.Default);
                    if (!Utils.SetComboBoxData(cbLine1, DisplayAdditionalInfo.Line1))
                        Utils.SetComboBoxData(cbLine1, DisplayAdditionalInfoValuesEnum.Default);
                }
                else
                {
                    Utils.SetComboBoxData(cbLine0, DisplayAdditionalInfoValuesEnum.Default);
                    Utils.SetComboBoxData(cbLine1, DisplayAdditionalInfoValuesEnum.Default);
                }
            }
            else
            {
                lblLine0.Text = "ALGO";
                lblLine1.Visible = false;
                cbLine1.Visible = false;
                cbLine0.Items.Add(new DisplayTagObject(DisplayAdditionalInfoValuesEnum.EncAlgoKeyIdHex));
                cbLine0.Items.Add(new DisplayTagObject(DisplayAdditionalInfoValuesEnum.EncAlgoKeyIdDec));

                if (DisplayAdditionalInfo != null)
                {
                    if (DisplayAdditionalInfo.Line0 == DisplayAdditionalInfoValuesEnum.EncAlgoKeyIdDec)
                        Utils.SetComboBoxData(cbLine0, DisplayAdditionalInfoValuesEnum.EncAlgoKeyIdDec);
                    else
                        Utils.SetComboBoxData(cbLine0, DisplayAdditionalInfoValuesEnum.EncAlgoKeyIdHex);
                }
                else
                {
                    Utils.SetComboBoxData(cbLine0, DisplayAdditionalInfoValuesEnum.EncAlgoKeyIdHex);
                }
            }
        }

        public void FillComboBoxData(ComboBox cb)
        {
            cb.Items.Clear();
            foreach (DisplayAdditionalInfoValuesEnum item in Enum.GetValues(typeof(DisplayAdditionalInfoValuesEnum)))
            {
                cb.Items.Add(new DisplayTagObject(item));
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (DisplayAdditionalInfo == null)
                DisplayAdditionalInfo = new DisplayAdditionalInfo();

            DisplayAdditionalInfo.Line0 = (DisplayAdditionalInfoValuesEnum)Utils.GetComboBoxData(cbLine0.SelectedItem);
            if (Scanner.GetBaseModel(Model) == ScannerBaseModelEnum.BCD)
            {
                DisplayAdditionalInfo.Line1 = (DisplayAdditionalInfoValuesEnum)Utils.GetComboBoxData(cbLine1.SelectedItem);
            }
        }
    }
}
