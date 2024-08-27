using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("DMR AES")]
    [Serializable]
    public class DmrAesEncryptionRow : DmrEncryptionRow
    {
        public const int KEY_SIZE = 32;
        public ushort KeyLength { get; set; }

        public byte[] Key { get; set; }

        [JsonIgnore]
        public override string Description =>  $"DMR AES: KeyLen({KeyLength}) {ActivateOptions}";
    }
}
