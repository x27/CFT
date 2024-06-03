namespace CFT
{
    public class ImportItem
    {
        public uint Frequency { get; set; }
        public string Notes { get; set; }
        public IEncryptionRow EncryptionRow { get; set; }
    }
}