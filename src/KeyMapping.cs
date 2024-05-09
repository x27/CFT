using System;

namespace CFT
{
    [Serializable]
    public class KeyMapping
    {
        public KeyMapFunctionEnum Key1 { get; set; } = KeyMapFunctionEnum.Default;
        public KeyMapFunctionEnum Key2 { get; set; } = KeyMapFunctionEnum.Default;
        public KeyMapFunctionEnum Key3 { get; set; } = KeyMapFunctionEnum.Default;
    }
}
