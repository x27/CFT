using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("TYT BP")]
    [Serializable]
    public class TyteraBPEncryptionRow : BaseEncryptionRow
    {
        public ushort Key { get; set; }

        public DmrActivateOptions ActivateOptions { get; set; }

        [JsonIgnore]
        public override ProtocolEnum Protocol => ProtocolEnum.DMR;

        [JsonIgnore]
        public override string Description
        {
            get
            {
                if (!string.IsNullOrEmpty($"{ActivateOptions}"))
                    return $"Tytera BP: {ActivateOptions}";
                else
                    return $"Tytera BP";
            }
        }
    }
}
