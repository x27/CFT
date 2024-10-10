using System;
using System.IO;
using System.Windows.Forms;

namespace CFT
{
    public partial class DebugLogsFilteringForm : Form
    {
        static readonly string [] DEBUG_LINE_SIGNATURES = { ":D", ":B", ":N", ":R", ":P", ":C", ":A", ":M" };

        public DebugLogsFilteringForm()
        {
            InitializeComponent();
            UpdateControls();
        }

        private void UpdateControls()
        {
            nudTime.Enabled = cbInsertSpaceLine.Checked;
            btnOk.Enabled = !string.IsNullOrEmpty(tbDebugLogFilename.Text);
        }

        private void cbInsertSpaceLine_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var count = 0;
            try
            {
                uint previousTick = 0;

                var outputFileName = Path.ChangeExtension(tbDebugLogFilename.Text, "filtered.txt");

                using (TextReader tr = new StreamReader(File.Open(tbDebugLogFilename.Text, FileMode.Open, FileAccess.Read, FileShare.Read)))
                using (TextWriter tw = new StreamWriter(File.Open(outputFileName, FileMode.Create, FileAccess.Write, FileShare.Write)))
                {
                    string line;
                    while ((line = tr.ReadLine()) != null)
                    {
                        count++;

                        var foundSignature = false;
                        foreach (var sig in DEBUG_LINE_SIGNATURES)
                        {
                            if (line.Contains(sig))
                            {
                                foundSignature = true;
                                break;
                            }
                        }
                        if (!foundSignature)
                            continue;

                        if (cbInsertSpaceLine.Checked)
                        {
                            var token = line.Split(' ');

                            if (uint.TryParse(token[0], out uint res))
                            {
                                if (res - previousTick > nudTime.Value)
                                    tw.WriteLine();
                                previousTick = res;
                            }
                        }
                        tw.WriteLine(line);
                    }
                }
                MessageBox.Show("Done.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error in the line {count}\r\n{ex.Message}\r\n{ex.StackTrace}", "Error");
            }
        }

        private void btnDebugLogFileSelect_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Debug Log Files (*.txt)|*.txt|All Files|*.*";
                dlg.Multiselect = false;
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    tbDebugLogFilename.Text = dlg.FileName;
                    UpdateControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
