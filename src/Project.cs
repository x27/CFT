using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CFT
{
    [Serializable]
    public class Project
    {
        [JsonIgnore]
        public string Path { get; set; }
        public List<Scanner> Scanners { get; set; }
        public List<IEncryptionRow> EcryptionRows { get; set; }

        public static Project Load(string fileName)
        {
            var p = JsonConvert.DeserializeObject<Project>(SuperComplexDeobfuscator(File.ReadAllBytes(fileName)), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            p.Path = fileName;
            return p;
        }

        public void Save()
        {
            File.WriteAllBytes(Path, SuperComplexObfuscator(JsonConvert.SerializeObject(this, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto } )));
        }

        private static byte[] SuperComplexObfuscator(string str)
        {
            var bs = Encoding.UTF8.GetBytes(str);
            for(var i=0; i<bs.Length; i++)
                bs[i] ^= (byte)(0xff ^ i);
            return bs;
        }

        private static string SuperComplexDeobfuscator(byte[] bytes)
        {
            for (var i = 0; i < bytes.Length; i++)
                bytes[i] ^= (byte)(0xff ^ i);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
