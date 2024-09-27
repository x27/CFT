using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("Kirisun BP")]
    [Serializable]
    public class KirisunBPEncryptionRow : DmrEncryptionRow
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
                    return $"Kirisun BP: {ActivateOptions}";
                else
                    return $"Kirisun BP: KeyLen({(int)KeyLength}) {ActivateOptions}";
            }
        }
    }
}
