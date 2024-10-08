using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("Hytera EP")]
    [Serializable]
    public class HyteraEPEncryptionRow : DmrEncryptionRow
    {
        public const int KEY_SIZE = 5;

        public byte[] Key { get; set; }

        [JsonIgnore]
        public override string Description
        {
            get
            {
                if (ActivateOptions.IsActivated(DmrSelectedActivateOptionsEnum.ForceMute))
                    return $"Hytera EP: {ActivateOptions}";
                else
                    return $"Hytera EP: Key({Utils.BytesToHexString(Key)}) {ActivateOptions}";
            }
        }
    }
}
