﻿using Newtonsoft.Json;
using System;


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
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public byte[] P25ADPUnlockKey { get; set; } = new byte[UNLOCK_KEY_LEN];
        public byte[] P25DESUnlockKey { get; set; } = new byte[UNLOCK_KEY_LEN];
        public byte[] DMRAESUnlockKey { get; set; } = new byte[UNLOCK_KEY_LEN];
        public byte[] HyteraEPUnlockKey { get; set; } = new byte[UNLOCK_KEY_LEN];
        public byte[] P25AESUnlockKey { get; set; } = new byte[UNLOCK_KEY_LEN];
    }
}
