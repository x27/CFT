using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class DisplayAdditionalInfoForm : Form
    {
        public DisplayAdditionalInfo DisplayAdditionalInfo { get; private set; }

        public DisplayAdditionalInfoForm(DisplayAdditionalInfo additionalInfo)
        {
            InitializeComponent();

            DisplayAdditionalInfo = additionalInfo;

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
            DisplayAdditionalInfo.Line1 = (DisplayAdditionalInfoValuesEnum)Utils.GetComboBoxData(cbLine1.SelectedItem);
        }
    }
}
