using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("Hytera BP")]
    [Serializable]
    public class HyteraBPEncryptionRow : DmrEncryptionRow
    {
        public const int KEY_SIZE = 32;
        public uint KeyLength { get; set; }

        public byte[] Key { get; set; }

        [JsonIgnore]
        public override string Description
        {
            get
            {
                if (ActivateOptions.IsActivated(DmrSelectedActivateOptionsEnum.ForceMute))
                    return $"Hytera BP: {ActivateOptions}";
                else
                    return $"Hytera BP: KeyLen({(int)KeyLength}) {ActivateOptions}";
            }
        }
    }
}
