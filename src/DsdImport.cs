using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CFT
{
    public class DsdImport
    {
        public static List<ImportItem> Import(string filename)
        {
            var res = new List<ImportItem>();
            var count = 0;
            try
            {
                using (TextReader tr = new StreamReader(File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read)))
                {
                    count++;

                    string line;
                    while ((line = tr.ReadLine()) != null)
                    {
                        var commentIndex = line.IndexOf(";");
                        if (commentIndex != -1)
                            line = line.Substring(0, commentIndex).Trim();

                        if (string.IsNullOrEmpty(line.Trim()))
                            continue;

                        var token = line.Split(',');
                        if (token.Length != 7)
                            throw new Exception($"Wrong item count in row: {token.Length}");
                        var item = new ImportItem();
                        if (!Utils.ParseFrequency(token[4], out uint freq, out string err))
                            throw new Exception(err);
                        item.Frequency = freq;
                        item.Notes = $"{token[0]} {token[1]} {token[2]} {token[3]}";
                        res.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in the line {count}\r\n{ex.Message}\r\n{ex.StackTrace}", "Error");
                res = null;
            }

            return res;
        }
    }
}
