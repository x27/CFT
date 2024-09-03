using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("TYT EP")]
    [Serializable]
    public class TyteraEPEncryptionRow : DmrEncryptionRow
    {
        public const int KEY_SIZE = 16;

        public byte[] Key { get; set; }

        [JsonIgnore]
        public override string Description
        {
            get
            {
                if (!string.IsNullOrEmpty($"{ActivateOptions}"))
                    return $"Tytera EP: {ActivateOptions}";
                else
                    return $"Tytera EP";
            }
        }
    }
}
