namespace CFT
{
    [System.Flags]
    public enum DmrSelectedActivateOptionsEnum : uint
    {
        TrunkSystem         = 1 << 0,
        MFID                = 1 << 1,
        Frequency           = 1 << 2,
        ColorCode           = 1 << 3,
        TGID                = 1 << 4,
        TimeSlot            = 1 << 5,
        EncryptValue        = 1 << 6,
        KeyId               = 1 << 7,

        Silence = 1 << 15
    }
}
