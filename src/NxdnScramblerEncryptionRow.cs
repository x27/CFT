using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("NXDN Scrambler")]
    [Serializable]
    public class NxdnScramblerEncryptionRow : BaseEncryptionRow
    {
        public ushort Key { get; set; }

        public NxdnActivateOptions ActivateOptions { get; set; }

        [JsonIgnore]
        public override ProtocolEnum Protocol => ProtocolEnum.NXDN;

        [JsonIgnore]
        public override string Description
        {
            get
            {
                if (ActivateOptions.IsActivated(NxdnSelectedActivateOptionsEnum.ForceMute))
                    return $"NXDN Scrambler: {ActivateOptions}";
                else
                    return $"NXDN Scrambler: Key({Key}) {ActivateOptions}";
            }
        }

        public override bool IsFrequencyNeed => ActivateOptions == null ? true : ActivateOptions.IsActivated(NxdnSelectedActivateOptionsEnum.Frequency);

    }
}
