namespace CFT
{
    [System.Flags]
    public enum NxdnSelectedActivateOptionsEnum : uint
    {
        RAN                 = 1 << 0,
        GroupID             = 1 << 1,
        Frequency           = 1 << 2,
        KeyId               = 1 << 3,
    }
}
