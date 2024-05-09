using System;

namespace CFT
{
    [Serializable]
    public class Licensing
    {
        public const int UNLOCK_KEY_LEN = 32;

        public byte[] HyteraBPUnlockKey { get; set; }
        public byte[] MotorolaBPUnlockKey { get; set; }
        public byte[] NxdnScramblerUnlockKey { get; set; }
    }
}
