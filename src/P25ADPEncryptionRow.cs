using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("P25 ADP")]
    [Serializable]
    public class P25ADPEncryptionRow : P25EncryptionRow
    {
        public const int KEY_SIZE = 5;

        public byte[] Key { get; set; }

        [JsonIgnore]
        public override string Description
        {
            get
            {
                if (!string.IsNullOrEmpty($"{ActivateOptions}"))
                    return $"P25 ADP: {ActivateOptions}";
                else
                    return $"P25 ADP";
            }
        }
    }
}
