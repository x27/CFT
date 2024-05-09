namespace CFT
{
    public interface IEncryptionRow
    {
        uint Frequency { get; set; }

        string Notes { get; set; }

        ProtocolEnum Protocol { get; }

        string Description { get; }
    }

}
