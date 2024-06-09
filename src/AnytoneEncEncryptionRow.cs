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
        public override string Description => $"Anytone Enc: Key({Key:X04}) {ActivateOptions}";
    }
}
