using Newtonsoft.Json;
using System;

namespace CFT
{
    [DisplayName("TYT BP")]
    [Serializable]
    public class TyteraBPEncryptionRow : DmrEncryptionRow
    {
        public ushort Key { get; set; }

        [JsonIgnore]
        public override string Description
        {
            get
            {
                if (!string.IsNullOrEmpty($"{ActivateOptions}"))
                    return $"Tytera BP: {ActivateOptions}";
                else
                    return $"Tytera BP";
            }
        }
    }
}
