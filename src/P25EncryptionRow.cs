using Newtonsoft.Json;
using System;

namespace CFT
{
    [Serializable]
    public abstract class P25EncryptionRow : BaseEncryptionRow
    {
        public P25ActivateOptions ActivateOptions { get; set; }

        [JsonIgnore]
        public override ProtocolEnum Protocol => ProtocolEnum.P25;

        public override bool IsFrequencyNeed => ActivateOptions == null ? true : ActivateOptions.IsActivated(P25SelectedActivateOptionsEnum.Frequency);
    }
}
