using System.Windows.Forms;

namespace CFT
{
    public partial class MacAddressForm : Form
    {
        public byte [] MacAddress {  get; set; }

        public MacAddressForm(byte[] macAddress)
        {
            InitializeComponent();

            MacAddress = macAddress;

            if(macAddress == null || macAddress.Length != 6)
                btnOk.Enabled = false;
            else
            {
                tbMAC3.Text = macAddress[3].ToString("X2");
                tbMAC4.Text = macAddress[4].ToString("X2");
                tbMAC5.Text = macAddress[5].ToString("X2");
            }
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            try
            {
                MacAddress[3] = byte.Parse(tbMAC3.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                MessageBox.Show("Wrong MAC Address [3]");
                tbMAC3.Focus();
                return;
            }
            try
            {
                MacAddress[4] = byte.Parse(tbMAC4.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                MessageBox.Show("Wrong MAC Address [4]");
                tbMAC4.Focus();
                return;
            }
            try
            {
                MacAddress[5] = byte.Parse(tbMAC5.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                MessageBox.Show("Wrong MAC Address [5]");
                tbMAC5.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
