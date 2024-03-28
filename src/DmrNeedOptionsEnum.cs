namespace CFT
{
    [System.Flags]
    public enum DmrNeedOptionsEnum : uint
    {
        TrunkSystem         = 1 << 0,
        Mfid                = 1 << 1,
        Frequency           = 1 << 2,
        ColorCode           = 1 << 3,
        Tgid                = 1 << 4,
        TimeSlot            = 1 << 5,
        EncryptValue        = 1 << 6,
    }
}
