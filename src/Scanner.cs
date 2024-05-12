using System;

namespace CFT
{
    [Serializable]
    public class Scanner
    {
        public string Name { get; set; }

        public ScannerModelEnum Model { get; set; }

        public Licensing Licensing { get; set; }

        public KeyMapping KeyMapping { get; set; }

        public bool MuteEncryptedVoiceTraffic { get; set; }

        public Scanner()
        {
            Model = ScannerModelEnum.BCD436HP;
            Name = "Scanner";
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Name))
                return $"{Model}";
            return $"{Name.Trim()} ({Model})";
        }
    }
}
