using System;

namespace CFT
{
    [Serializable]
    public class Licensing
    {
        public const int UNLOCK_KEY_LEN = 32;

        public byte[] HyteraBPUnlockKey { get; private set; } = new byte[UNLOCK_KEY_LEN];
        public byte[] MotorolaBPUnlockKey { get; private set; } = new byte[UNLOCK_KEY_LEN];
    }
}
