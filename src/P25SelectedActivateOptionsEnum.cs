namespace CFT
{
    [System.Flags]
    public enum P25SelectedActivateOptionsEnum : uint
    {
        NAC                 = 1 << 0,
        GroupID             = 1 << 1,
        Frequency           = 1 << 2,
        KeyID               = 1 << 3,
        SourceID            = 1 << 4,

        Silence             = 1 << 15
    }
}
