using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace CFT
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            var fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            lblVersion.Text = $"v{fvi.FileVersion}";
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var target = (sender as LinkLabel).Text;
            if (target.IndexOf("@") != -1)
                target = "email:" + target;
            Process.Start(target);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
