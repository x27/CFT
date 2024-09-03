using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("Motorola EP")]
    [Serializable]
    public class MotorolaEPEncryptionRow : DmrEncryptionRow
    {
        public const int KEY_SIZE = 5;

        public byte[] Key { get; set; }

        [JsonIgnore]
        public override string Description
        {
            get
            {
                if (ActivateOptions.IsActivated(DmrSelectedActivateOptionsEnum.ForceMute))
                    return $"Motorola EP: {ActivateOptions}";
                else
                    return $"Motorola EP: Key({Utils.BytesToHexString(Key)}) {ActivateOptions}";
            }
        }
    }
}
