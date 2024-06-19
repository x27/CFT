using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("P25 ADP")]
    [Serializable]
    public class P25ADPEncryptionRow : BaseEncryptionRow
    {
        public const int KEY_SIZE = 5;

        public byte[] Key { get; set; }

        public P25ActivateOptions ActivateOptions { get; set; }

        [JsonIgnore]
        public override ProtocolEnum Protocol => ProtocolEnum.P25;

        [JsonIgnore]
        public override string Description
        {
            get
            {
                return $"P25 ADP: {ActivateOptions}";
            }
        }
    }
}
