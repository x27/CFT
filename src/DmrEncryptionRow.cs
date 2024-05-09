using Newtonsoft.Json;
using System;

namespace CFT
{
    [Serializable]
    public abstract class DmrEncryptionRow : BaseEncryptionRow
    {
        [JsonIgnore]
        public override ProtocolEnum Protocol => ProtocolEnum.DMR;

        public DmrActivateOptions ActivateOptions { get; set; }

    }
}
