using System;

namespace CFT
{
    [Serializable]
    public class DisplayAdditionalInfo
    {
        public DisplayAdditionalInfoValuesEnum Line0 { get; set; } = DisplayAdditionalInfoValuesEnum.Default;
        public DisplayAdditionalInfoValuesEnum Line1 { get; set; } = DisplayAdditionalInfoValuesEnum.Default;
    }
}
