using System.Windows.Forms;

namespace CFT
{
    public partial class SelectEncryptionMethodForm : Form
    {
        public int Selection {  get; private set; } 

        public SelectEncryptionMethodForm()
        {
            InitializeComponent();

            listBox.Items.Add("Motorola BP");
            listBox.Items.Add("Hytera BP");
            listBox.Items.Add("NXDN Scrambler");
            listBox.SelectedIndex = 0;
        }

        private void btnSelect_Click(object sender, System.EventArgs e)
        {
            Selection = listBox.SelectedIndex;
        }
    }
}
