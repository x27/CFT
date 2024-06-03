using System;
using System.Windows.Forms;

namespace CFT
{
    public partial class SelectEncryptionMethodForm : Form
    {
        public int Selection {  get; private set; } 

        public SelectEncryptionMethodForm()
        {
            InitializeComponent();

            foreach(var item in Enum.GetValues(typeof(EncryptionMethodEnum)))
            {
                listBox.Items.Add(DisplayNameAttribute.GetName(item));
            }
            listBox.SelectedIndex = 0;
        }

        private void btnSelect_Click(object sender, System.EventArgs e)
        {
            Selection = listBox.SelectedIndex;
        }
    }
}
