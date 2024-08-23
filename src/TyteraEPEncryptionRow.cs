using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("TYT EP")]
    [Serializable]
    public class TyteraEPEncryptionRow : BaseEncryptionRow
    {
        public const int KEY_SIZE = 16;

        public byte[] Key { get; set; }

        public DmrActivateOptions ActivateOptions { get; set; }

        [JsonIgnore]
        public override ProtocolEnum Protocol => ProtocolEnum.DMR;

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
