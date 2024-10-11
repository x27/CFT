namespace CFT
{
    public enum DisplayAdditionalInfoValuesEnum
    {
        [DisplayName("Default")]
        Default = 0,
        [DisplayName("RSSI")]
        RSSI = 1,
        [DisplayName("Encryption Algo and KeyID (HEX)")]
        EncAlgoKeyIdHex = 2,
        [DisplayName("Encryption Algo and KeyID (DEC)")]
        EncAlgoKeyIdDec = 3,
        [DisplayName("MFID, Encrypton Algo and KeyID (HEX)")]
        MfidEncAlgoKeyIdHex = 4,
        [DisplayName("MFID, Encrypton Algo and KeyID (DEC)")]
        MfidEncAlgoKeyIdDec = 5

    }
}
