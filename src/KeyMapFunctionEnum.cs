﻿namespace CFT
{
    public enum KeyMapFunctionEnum
    {
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [Scanner(ScannerModelEnum.UBCD3600XLT)]
        [Scanner(ScannerModelEnum.SDS100E)]
        [Scanner(ScannerModelEnum.SDS200E)]
        [Scanner(ScannerModelEnum.UBCD436PT)]
        [Scanner(ScannerModelEnum.UBCD536PT)]
        [Scanner(ScannerModelEnum.USDS100)]
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
        [Scanner(ScannerModelEnum.UBCD3600XLT)]
        [Scanner(ScannerModelEnum.SDS100E)]
        [DisplayName("Select Service")]
        SelectServiceMenu = 2,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [Scanner(ScannerModelEnum.UBCD3600XLT)]
        [Scanner(ScannerModelEnum.SDS100E)]
        [DisplayName("Search For ...")]
        SearchForMenu = 3,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [Scanner(ScannerModelEnum.UBCD3600XLT)]
        [Scanner(ScannerModelEnum.SDS100E)]
        [DisplayName("Select Lists to Monitor")]
        SelectListsToMonitorMenu = 4,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.UBCD3600XLT)]
        [DisplayName("RF Power Plot")]
        RFPowerPlotMenu = 5,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [Scanner(ScannerModelEnum.UBCD3600XLT)]
        [Scanner(ScannerModelEnum.SDS100E)]
        [DisplayName("Set Dimmer")]
        SetDimmerMenu = 6,
        [Scanner(ScannerModelEnum.BCD436HP)]
        [Scanner(ScannerModelEnum.BCD536HP)]
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [Scanner(ScannerModelEnum.UBCD3600XLT)]
        [Scanner(ScannerModelEnum.SDS100E)]
        [DisplayName("Set CC Mode")]
        SetCCModeMenu = 7,
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [Scanner(ScannerModelEnum.SDS100E)]
        [DisplayName("Waterfall")]
        WaterfallMenu = 8,
        [Scanner(ScannerModelEnum.SDS100)]
        [Scanner(ScannerModelEnum.SDS200)]
        [Scanner(ScannerModelEnum.SDS100E)]
        [DisplayName("Filter")]
        FilterMenu = 9,
        [Scanner(ScannerModelEnum.BCD536HP)]
        [DisplayName("Range")]
        SelectRange = 10,
    }
}
