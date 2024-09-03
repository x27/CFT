using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("P25 DES")]
    [Serializable]
    public class P25DESEncryptionRow : BaseEncryptionRow
    {
        public const int KEY_SIZE = 8;

        public byte[] Key { get; set; }

        public P25ActivateOptions ActivateOptions { get; set; }

        [JsonIgnore]
        public override ProtocolEnum Protocol => ProtocolEnum.P25;

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
        public override bool IsFrequencyNeed => ActivateOptions == null ? true : ActivateOptions.IsActivated(P25SelectedActivateOptionsEnum.Frequency);
    }
}
