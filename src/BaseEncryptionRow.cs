using System;

namespace CFT
{
    [Serializable]
    public abstract class BaseEncryptionRow : IEncryptionRow
    {
        public uint Frequency { get; set; }

        public string Notes { get; set; }

        public abstract ProtocolEnum Protocol { get; }

        public abstract string Description { get; }

        public abstract bool IsFrequencyNeed { get; }
    }
}
