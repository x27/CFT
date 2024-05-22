using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("Motorola EP")]
    [Serializable]
    public class MotorolaEPEncryptionRow : DmrEncryptionRow
    {
        public const int KEY_SIZE = 5;

        public byte[] Key { get; set; }

        [JsonIgnore]
        public override string Description =>  $"Motorola EP: Key({Utils.BytesToHexString(Key)}) {ActivateOptions}";
    }
}
