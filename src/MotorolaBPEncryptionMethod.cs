namespace CFT
{
    public class MotorolaBPEncryptionMethod : IEncryptionMethod
    {
        public string Name => "Motorola BP";
        public byte Key { get; set; }
    }
}
