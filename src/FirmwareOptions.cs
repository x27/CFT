using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class FirmwareOptions : Form
    {
        private CftFile _cftFile;

        public FirmwareOptions(CftFile cftFile)
        {
            InitializeComponent();
            _cftFile = cftFile;

            FillComboBoxData(cbZipKeyAssigment, typeof(ZipKeyAssigmentEnum));
            FillComboBoxData(cbFZipKeyAssigment, typeof(ZipKeyAssigmentEnum));

            if (cftFile != null)
            {
                cbZipKeyAssigment.SelectedIndex = (int)cftFile.ZipKeyAssigment;
                cbFZipKeyAssigment.SelectedIndex = (int)cftFile.FZipKeyAssigment;
            }
        }
        private void FillComboBoxData(ComboBox cb, Type type)
        {
            cb.Items.Clear();
            foreach (var item in Enum.GetValues(type))
                cb.Items.Add(new DisplayTagObject(item));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_cftFile != null)
            {
                _cftFile.ZipKeyAssigment = (ZipKeyAssigmentEnum)cbZipKeyAssigment.SelectedIndex;
                _cftFile.FZipKeyAssigment = (ZipKeyAssigmentEnum)cbFZipKeyAssigment.SelectedIndex;
            }
        }
    }
}
