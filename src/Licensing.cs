using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CFT
{
    [Serializable]
    public class Licensing
    {
        public const int UNLOCK_KEY_LEN = 32;

        public byte[] HyteraBPUnlockKey { get; set; }
        
        public byte[] MotorolaBPUnlockKey { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public byte[] MotorolaEPUnlockKey { get; set; } = new byte[UNLOCK_KEY_LEN];
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public byte[] NxdnScramblerUnlockKey { get; set; } = new byte[UNLOCK_KEY_LEN];
    }
}
