using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("Motorola BP")]

    [Serializable]
    public class MotorolaBPEncryptionRow : DmrEncryptionRow
    {
        public byte Key { get; set; }

        public MotorolaBPEncryptionRow()
        {
            Key = 1;
            ActivateOptions = new DmrActivateOptions();
        }

        [JsonIgnore]
        public override string Description
        {
            get
            { 
                if (ActivateOptions.IsActivated(DmrSelectedActivateOptionsEnum.ForceMute))
                    return $"Motorola BP: {ActivateOptions}";
                else
                    return $"Motorola BP: Key({Key}) {ActivateOptions}";
            }
        }
    }
}
