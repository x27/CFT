namespace CFT
{
    public enum DisplayAdditionalInfoValuesEnum
    {
        [DisplayName("Default")]
        Default = 0,
        [DisplayName("RSSI")]
        RSSI = 1,
        [DisplayName("MFID, Encrypton Algo and KeyID (HEX)")]
        MfidEncAlgoKeyIdHex = 2,
        [DisplayName("MFID, Encrypton Algo and KeyID (DEC)")]
        MfidEncAlgoKeyIdDec = 3
    }
}
