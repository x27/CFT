using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CFT
{
    public static class Utils
    {
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
                objResult = (T)bf.Deserialize(ms);
            }
            return objResult;
        }

        public static bool DeepCompare<T>(T a, T b)
        {
            using (var msa = new MemoryStream())
            using (var msb = new MemoryStream())
            {
                var bfa = new BinaryFormatter();
                var bfb = new BinaryFormatter();
                bfa.Serialize(msa, a);
                bfb.Serialize(msb, b);
                msa.Flush();
                msb.Flush();
                var ba = msa.ToArray();
                var bb = msb.ToArray();
                if (ba.Length != bb.Length)
                    return false;
                for(var i=0; i<ba.Length; i++)
                    if (ba[i] != bb[i])
                        return false;
            }
            return true;
        }
        public static string GetFrequencyString(uint frequency)
        {
            int mhz = (int)(frequency / 1e6);
            var khz = (int)(frequency % 1e6 / 1e2);
            return $"{mhz:D03}.{khz:D04}";
        }

    }
}
