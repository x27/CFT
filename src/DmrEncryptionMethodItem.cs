using System;

namespace CFT
{
    [Serializable]
    public class DmrEncryptionMethodItem
    {
        public const int ENC_METHOD_KEY_LEN = 32;

        public DmrNeedOptionsEnum Options { get; set; }
        public DmrTrunkSystemEnum TrunkSystem { get; set; }
        public DmrMfidEnum Mfid { get; set; }
        public uint Frequency { get; set; }
        public DmrColorCodeEnum ColorCode { get; set; }
        public uint Tgid { get; set; }
        public DmrTimeSlotEnum TimeSlot { get; set; }
        public DmrEncyptionValueEnum EncryptionValue { get; set; }
        public DmrEncryptionMethodEnum EncryptionMethod { get; set; }
        public uint KeyLength { get; set; }
        public byte[] Key { get; private set; } = new byte[ENC_METHOD_KEY_LEN];


        public bool IsActiveOption(DmrNeedOptionsEnum option)
        {
            return (Options & option) == option;
        }
    }
}
