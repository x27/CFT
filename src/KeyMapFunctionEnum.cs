namespace CFT
{
    public enum KeyMapFunctionEnum
    {
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [DisplayName("DEFAULT")]
        Default = 0,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [DisplayName("Zip Code")]
        ZipCodeMenu = 1,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [DisplayName("Select Service")]
        SelectServiceMenu = 2,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [DisplayName("Search For ...")]
        SearchForMenu = 3,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [DisplayName("Select Lists to Monitor")]
        SelectListsToMonitorMenu = 4,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [DisplayName("RF Power Plot")]
        RFPowerPlotMenu = 5,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [DisplayName("Set Dimmer")]
        SetDimmerMenu = 6,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [DisplayName("Set CC Mode")]
        SetCCModeMenu = 7,
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [DisplayName("Waterfall")]
        WaterfallMenu = 8,
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [DisplayName("Filter")]
        FilterMenu = 9,
        [Scanner(ScannerModelEnum.BCD536HP)]
        [DisplayName("Range")]
        SelectRange = 10,
    }
}
