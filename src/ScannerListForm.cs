using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CFT
{
    public partial class ScannerListForm : Form
    {
        public List<Scanner> Scanners { get; private set; }

        public ScannerListForm(List<Scanner> scanners)
        {
            InitializeComponent();

            Scanners = scanners == null ? new List<Scanner>() : scanners;

            FillScannerListBox();
            UpdateControls();
        }

        private void FillScannerListBox()
        {
            lbScanners.Items.Clear();
            foreach (var item in Scanners)
            {
                lbScanners.Items.Add(new DisplayTagObject(item));
            }
            if (lbScanners.Items.Count > 0)
                lbScanners.SelectedIndex = 0;
        }

        private void UpdateControls()
        {
            btnEdit.Enabled = lbScanners.SelectedIndex >= 0;
            btnDelete.Enabled = lbScanners.SelectedIndex >= 0;
            btnLicenses.Enabled = lbScanners.SelectedIndex >= 0;
            lbScanners.Invalidate();
        }

        private void lbScanners_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Scanners.RemoveAt(lbScanners.SelectedIndex);
                FillScannerListBox();
                UpdateControls();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new ScannerForm(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Scanners.Add(frm.Scanner);
                FillScannerListBox();
                UpdateControls();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbScanners.SelectedIndex == -1)
                return;

            var frm = new ScannerForm(Scanners[lbScanners.SelectedIndex]);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Scanners[lbScanners.SelectedIndex] = frm.Scanner;
                FillScannerListBox();
                UpdateControls();
            }
        }

        private void lbScanners_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void lbScanners_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnEdit_Click(sender, e);
        }

        private void btnLicenses_Click(object sender, EventArgs e)
        {
            if (lbScanners.SelectedIndex == -1)
                return;

            var frm = new LicensingForm(Scanners[lbScanners.SelectedIndex].Licensing);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Scanners[lbScanners.SelectedIndex].Licensing = frm.Licensing;
            }
        }
    }
}
