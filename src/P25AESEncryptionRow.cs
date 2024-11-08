using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("P25 AES")]
    [Serializable]
    public class P25AESEncryptionRow : BaseEncryptionRow
    {
        public const int KEY_SIZE = 32;

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
                    return $"P25 AES: {ActivateOptions}";
                else
                    return $"P25 AES";
            }
        }
        public override bool IsFrequencyNeed => ActivateOptions == null ? true : ActivateOptions.IsActivated(P25SelectedActivateOptionsEnum.Frequency);
    }
}
