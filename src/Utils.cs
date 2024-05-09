using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace CFT
{
    public static class Utils
    {
        public static void FillComboBoxData(ComboBox cb, Type type)
        {
            cb.Items.Clear();
            foreach (var item in Enum.GetValues(type))
                cb.Items.Add(new DisplayTagObject(item));
        }

        public static void FillComboBoxData(ToolStripComboBox cb, Type type)
        {
            cb.Items.Clear();
            foreach (var item in Enum.GetValues(type))
                cb.Items.Add(new DisplayTagObject(item));
        }

        public static bool SetComboBoxData(ComboBox comboBox, object o)
        {
            try
            {
                foreach (var item in comboBox.Items)
                {
                    var me = item as DisplayTagObject;
                    if (me.Tag != null && me.Tag.Equals(o))
                    {
                        comboBox.SelectedItem = me;
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }

        public static bool SetComboBoxData(ToolStripComboBox comboBox, object o)
        {
            try
            {
                foreach (var item in comboBox.Items)
                {
                    var me = item as DisplayTagObject;
                    if (me.Tag != null && me.Tag.Equals(o))
                    {
                        comboBox.SelectedItem = me;
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }

        internal static object GetComboBoxData(object item)
        {
            var dto = item as DisplayTagObject;
            if (dto == null)
                return null;
            return dto.Tag;
        }


        public static string BytesToHexString(byte[] data)
        {
            if (data == null || data.Length == 0)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (byte b in data)
                sb.Append($"{b:X2}");

            return sb.ToString();
        }

        public static byte[] HexStringToBytes(string hex)
        {
            var h = hex.Trim().Replace(" ", "").Replace("-", "");
            var twos = h.Length / 2;
            var list = new List<byte>();
            for(var i=0; i<twos; i++)
                list.Add(byte.Parse(h.Substring(2*i,2), System.Globalization.NumberStyles.HexNumber));
            if (h.Length %2 != 0)
            {
                list.Add((byte)(byte.Parse(h.Substring(h.Length-1, 1), System.Globalization.NumberStyles.HexNumber)*16));
            }
            return list.ToArray();
        }

        public static bool IsArrayEmpty(byte[] data)
        {
            foreach(var b in data)
                if (b != 0)
                    return false;
            return true;
        }

        public static T DeepClone<T>(T obj)
        {
            T objResult;
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                ms.Flush();
                objResult = (T)bf.Deserialize(ms);
            }
            return objResult;
        }

        public static bool JsonCompare(object obj, object another)
        {
            if (ReferenceEquals(obj, another)) return true;
            if ((obj == null) || (another == null)) return false;
            if (obj.GetType() != another.GetType()) return false;

            var objJson = JsonConvert.SerializeObject(obj);
            var anotherJson = JsonConvert.SerializeObject(another);

            return objJson == anotherJson;
        }

        public static string GetFrequencyString(uint frequency)
        {
            int mhz = (int)(frequency / 1e6);
            var khz = (int)(frequency % 1e6 / 1e2);
            return $"{mhz:D03}.{khz:D04}";
        }

        public static bool ParseFrequency(string value, out uint uintFreq,  out string errorString)
        {
            errorString = string.Empty;
            uintFreq = 0;

            var freqStr = value.Trim();
            if (!double.TryParse(freqStr, NumberStyles.Any, CultureInfo.CurrentCulture, out double frequency) &&
                !double.TryParse(freqStr, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out frequency) &&
                !double.TryParse(freqStr, NumberStyles.Any, CultureInfo.InvariantCulture, out frequency))
            {
                errorString = "Wrong frequency value!";
                return false;
            }

            uintFreq = (uint)(frequency * 1e6);

            if (uintFreq <= 25e6 || uintFreq > 1300e6)
            {
                errorString = "Wrong frequency value (must be between 25MHz and 1300Mhz)!";
                return false;
            }
            return true;
        }

        public static T GetAttribute<T>(Enum enumValue) where T : Attribute
        {
            var m = enumValue.GetType().GetMember(enumValue.ToString());
            if (m.Length > 0)
            {
                var a = m[0].GetCustomAttributes(typeof(T), false);
                if (a.Length > 0)
                    return (T)a[0];
            }
            return null;
        }

        public static T[] GetAttributes<T>(Enum enumValue) where T : Attribute
        {
            var m = enumValue.GetType().GetMember(enumValue.ToString());
            if (m.Length > 0)
                return (T[])m[0].GetCustomAttributes(typeof(T), false);
            return null;
        }

    }
}
