using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("P25 DES")]
    [Serializable]
    public class P25DESEncryptionRow : P25EncryptionRow
    {
        public const int KEY_SIZE = 8;

        public byte[] Key { get; set; }

        [JsonIgnore]
        public override string Description
        {
            get
            {
                if (!string.IsNullOrEmpty($"{ActivateOptions}"))
                    return $"P25 DES: {ActivateOptions}";
                else
                    return $"P25 DES";
            }
        }
    }
}
