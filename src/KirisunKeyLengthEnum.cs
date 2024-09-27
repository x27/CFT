namespace CFT
{
    public enum KirisunKeyLengthEnum : ushort
    {
        [DisplayName("10 symbols (40 bits)")]
        L40 = 40,
        [DisplayName("16 symbols (64 bits)")]
        L64 = 64,
        [DisplayName("32 symbols (128 bits)")]
        L128 = 128,
        [DisplayName("48 symbols (192 bits)")]
        L192 = 192,
        [DisplayName("64 symbols (256 bits)")]
        L256 = 256
    }
}
