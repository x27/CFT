using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("Anytone Enc")]

    [Serializable]
    public class AnytoneEncEncryptionRow : DmrEncryptionRow
    {
        public ushort Key { get; set; }

        public AnytoneEncEncryptionRow()
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
                    return $"Anytone Enc: {ActivateOptions}";
                else
                    return $"Anytone Enc: Key({Key:X04}) {ActivateOptions}";
            }
        }
    }
}
