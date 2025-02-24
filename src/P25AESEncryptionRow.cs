using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("P25 AES")]
    [Serializable]
    public class P25AESEncryptionRow : P25EncryptionRow
    {
        public const int KEY_SIZE = 32;

        public byte[] Key { get; set; }

        [JsonIgnore]
        public override string Description
        {
            get
            {
                if (!string.IsNullOrEmpty($"{ActivateOptions}"))
                    return $"P25 AES: {ActivateOptions}";
                else
                    return $"P25 AES";
            }
        }
    }
}
