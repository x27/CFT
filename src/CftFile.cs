﻿using System.Globalization;
using System;
using System.IO;
using System.Collections.Generic;

namespace CFT
{
    public class CFTFile
    {
        const uint SIGNATURE = 0x46544643; // "CFTF"
        const uint VERSION = 1;
        const int MAX_ITEMS = 1000;
        const int KEY_STORAGE_OFFSET = 0x10;
        const int AGLO_TABLE_OFFSET = 0x200;
        const int ZIPKEY_OFFSET = 0x1FC;
        const int MAC_ADDRESS_OFFSET = 0x1F0;
        const int SCANNER_MODEL_OFFSET = 0x1F8;
        const int DISPLAY_ADD_INFO_OFFSET = 0x1EE;
        const int LED_ALERT_WHILE_DIGITAL_VOICE_GO_ON_OFFSET = 0x1ED;

        const int ENC_METHOD_STRUCT_SIZE = 54;
        private enum EncryptionMethodEnum
        {
            NoEncrypt = 0,
            HyteraBP = 1,
            MotorolaBP = 2,
            NxdnScrambler = 3,
            MotorolaEP = 4,
            AnytoneEnc = 5,
            P25ADP = 6,
            P25DES = 7,
            TytEP = 8,
            DmrAes = 9,
            TytBP = 10,
            KirisunBP = 11,
            HyteraEP = 12,
            P25AES = 13
        }

        public static void Export(Project project, Scanner scanner, string filename)
        {
            if (project.EcryptionRows.Count > MAX_ITEMS)
                throw new Exception($"Too Many Encryption Rows.");

            using (BinaryWriter bw = new BinaryWriter(new FileStream(filename, FileMode.Create, FileAccess.Write)))
            {
                bw.Write(SIGNATURE);
                bw.Write(Swap(VERSION));

                // KEY STORAGE
                if (scanner != null && scanner.Licensing != null)
                {
                    bw.BaseStream.Position = KEY_STORAGE_OFFSET;
                    bw.Write(scanner.Licensing.HyteraBPUnlockKey);
                    bw.Write(scanner.Licensing.MotorolaBPUnlockKey);
                    bw.Write(scanner.Licensing.NxdnScramblerUnlockKey);
                    bw.Write(scanner.Licensing.MotorolaEPUnlockKey);
                    bw.Write(scanner.Licensing.P25ADPUnlockKey);
                    bw.Write(scanner.Licensing.P25DESUnlockKey);
                    bw.Write(scanner.Licensing.DMRAESUnlockKey);
                    bw.Write(scanner.Licensing.HyteraEPUnlockKey);
                    bw.Write(scanner.Licensing.P25AESUnlockKey);
                }

                if (scanner != null)
                {
                    bw.BaseStream.Position = LED_ALERT_WHILE_DIGITAL_VOICE_GO_ON_OFFSET;
                    bw.Write((byte)(scanner.LEDAlertWhileDigitalVoiceGoesOn ? 1 : 0));
                }

                // DISPLAY ADDITIONAL INFO
                if (scanner != null && scanner.DisplayAdditionalInfo != null)
                {
                    bw.BaseStream.Position = DISPLAY_ADD_INFO_OFFSET;

                    bw.Write((byte)scanner.DisplayAdditionalInfo.Line1);
                    bw.Write((byte)scanner.DisplayAdditionalInfo.Line0);
                }

                // KEY MAPPING && MUTE
                bw.BaseStream.Position = ZIPKEY_OFFSET;
                if (scanner != null)
                    bw.Write((byte)(scanner.MuteEncryptedVoiceTraffic ? 1 : 0));

                if (scanner != null && scanner.KeyMapping != null)
                {
                    bw.Write((byte)scanner.KeyMapping.Key3);
                    bw.Write((byte)scanner.KeyMapping.Key1);
                    bw.Write((byte)scanner.KeyMapping.Key2);
                }

                // MAC ADDRESS
                if (scanner != null && scanner.MacAddress != null && scanner.MacAddress.Length == 6)
                {
                    bw.BaseStream.Position = MAC_ADDRESS_OFFSET;

                    bw.Write(scanner.MacAddress);
                }

                // SCANNER MODEL
                if (scanner != null)
                {
                    bw.BaseStream.Position = SCANNER_MODEL_OFFSET;

                    bw.Write((byte)scanner.Model);
                }

                // ENCRYPTION ROWS
                bw.BaseStream.Position = AGLO_TABLE_OFFSET;
                bw.Write(Swap((uint)project.EcryptionRows.Count));
                foreach (var row in project.EcryptionRows)
                {
                    if (row is MotorolaBPEncryptionRow)
                    {
                        var item = row as MotorolaBPEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write((byte)item.ActivateOptions.TrunkSystem);
                        bw.Write((byte)item.ActivateOptions.MFID);
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write((byte)item.ActivateOptions.ColorCode);
                        bw.Write(Swap(item.ActivateOptions.TGID));
                        bw.Write((byte)item.ActivateOptions.TimeSlot);
                        bw.Write((byte)item.ActivateOptions.EncryptionValue);
                        bw.Write((byte)EncryptionMethodEnum.MotorolaBP);
                        bw.Write((uint)0); // fake key length
                        bw.Write(item.Key); // key 1 byte
                        bw.Write(new byte[31]); // key remaining part
                    }
                    else if (row is MotorolaEPEncryptionRow)
                    {
                        var item = row as MotorolaEPEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write((byte)item.ActivateOptions.TrunkSystem);
                        bw.Write((byte)item.ActivateOptions.MFID);
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write((byte)item.ActivateOptions.ColorCode);
                        bw.Write(Swap(item.ActivateOptions.TGID));
                        bw.Write((byte)item.ActivateOptions.TimeSlot);
                        bw.Write((byte)item.ActivateOptions.EncryptionValue);
                        bw.Write((byte)EncryptionMethodEnum.MotorolaEP);
                        bw.Write((uint)0); // fake key length
                        bw.Write(item.Key); // key 5 byte
                        bw.Write(item.ActivateOptions.KeyId);
                        bw.Write(new byte[26]); // key remaining part
                    }
                    else if (row is AnytoneEncEncryptionRow)
                    {
                        var item = row as AnytoneEncEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write((byte)item.ActivateOptions.TrunkSystem);
                        bw.Write((byte)item.ActivateOptions.MFID);
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write((byte)item.ActivateOptions.ColorCode);
                        bw.Write(Swap(item.ActivateOptions.TGID));
                        bw.Write((byte)item.ActivateOptions.TimeSlot);
                        bw.Write((byte)item.ActivateOptions.EncryptionValue);
                        bw.Write((byte)EncryptionMethodEnum.AnytoneEnc);
                        bw.Write((uint)0); // fake key length
                        bw.Write(Swap(item.Key)); // key 2 byte
                        bw.Write(item.ActivateOptions.KeyId);
                        bw.Write(new byte[25]); // key remaining part
                    }
                    else if (row is HyteraBPEncryptionRow)
                    {
                        var item = row as HyteraBPEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write((byte)item.ActivateOptions.TrunkSystem);
                        bw.Write((byte)item.ActivateOptions.MFID);
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write((byte)item.ActivateOptions.ColorCode);
                        bw.Write(Swap(item.ActivateOptions.TGID));
                        bw.Write((byte)item.ActivateOptions.TimeSlot);
                        bw.Write((byte)item.ActivateOptions.EncryptionValue);
                        bw.Write((byte)EncryptionMethodEnum.HyteraBP);
                        bw.Write(Swap(item.KeyLength));
                        bw.Write(item.Key);
                    }
                    else if (row is NxdnScramblerEncryptionRow)
                    {
                        var item = row as NxdnScramblerEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write(item.ActivateOptions.KeyID);
                        bw.Write((byte)0);
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write(item.ActivateOptions.RAN);
                        bw.Write(Swap(item.ActivateOptions.GroupID));
                        bw.Write(Swap(item.ActivateOptions.SourceID));
                        bw.Write((byte)0);
                        bw.Write((byte)0);
                        bw.Write((byte)EncryptionMethodEnum.NxdnScrambler);
                        bw.Write((uint)0); // fake keylen
                        bw.Write(Swap(item.Key));
                        bw.Write(new byte[30]); // key remaining part
                    }
                    else if (row is P25ADPEncryptionRow)
                    {
                        var item = row as P25ADPEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write(Swap(item.ActivateOptions.NAC));
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write(Swap(item.ActivateOptions.SourceID));
                        bw.Write((byte)0);
                        bw.Write((byte)0);
                        bw.Write((byte)0);
                        bw.Write((byte)EncryptionMethodEnum.P25ADP);
                        bw.Write(Swap(item.ActivateOptions.GroupID));
                        bw.Write(item.Key); // key 5 byte
                        bw.Write(Swap(item.ActivateOptions.KeyID));
                        bw.Write(new byte[25]); // key remaining part
                    }
                    else if (row is P25DESEncryptionRow)
                    {
                        var item = row as P25DESEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write(Swap(item.ActivateOptions.NAC));
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write(Swap(item.ActivateOptions.SourceID));
                        bw.Write((byte)0);
                        bw.Write((byte)0);
                        bw.Write((byte)0);
                        bw.Write((byte)EncryptionMethodEnum.P25DES);
                        bw.Write(Swap(item.ActivateOptions.GroupID));
                        bw.Write(item.Key); // key 8 byte
                        bw.Write(Swap(item.ActivateOptions.KeyID));
                        bw.Write(new byte[22]); // key remaining part
                    }
                    else if (row is TyteraEPEncryptionRow)
                    {
                        var item = row as TyteraEPEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write((byte)item.ActivateOptions.TrunkSystem);
                        bw.Write((byte)item.ActivateOptions.MFID);
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write((byte)item.ActivateOptions.ColorCode);
                        bw.Write(Swap(item.ActivateOptions.TGID));
                        bw.Write((byte)item.ActivateOptions.TimeSlot);
                        bw.Write((byte)item.ActivateOptions.EncryptionValue);
                        bw.Write((byte)EncryptionMethodEnum.TytEP);
                        bw.Write(new byte[20]); 
                        bw.Write(Swap(item.Key)); 
                    }
                    else if (row is DmrAesEncryptionRow)
                    {
                        var item = row as DmrAesEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write((byte)item.ActivateOptions.TrunkSystem);
                        bw.Write((byte)item.ActivateOptions.MFID);
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write((byte)item.ActivateOptions.ColorCode);
                        bw.Write(Swap(item.ActivateOptions.TGID));
                        bw.Write((byte)item.ActivateOptions.TimeSlot);
                        bw.Write((byte)item.ActivateOptions.EncryptionValue);
                        bw.Write((byte)EncryptionMethodEnum.DmrAes);
                        bw.Write(Swap(item.KeyLength));
                        bw.Write(item.ActivateOptions.KeyId);
                        bw.Write((byte)0);
                        bw.Write(item.Key);
                    }
                    else if (row is TyteraBPEncryptionRow)
                    {
                        var item = row as TyteraBPEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write((byte)item.ActivateOptions.TrunkSystem);
                        bw.Write((byte)item.ActivateOptions.MFID);
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write((byte)item.ActivateOptions.ColorCode);
                        bw.Write(Swap(item.ActivateOptions.TGID));
                        bw.Write((byte)item.ActivateOptions.TimeSlot);
                        bw.Write((byte)item.ActivateOptions.EncryptionValue);
                        bw.Write((byte)EncryptionMethodEnum.TytBP);
                        bw.Write((uint)0); // fake key length
                        bw.Write(item.Key); // key 2 bytes
                        bw.Write(new byte[30]); // key remaining part
                    }
                    else if (row is KirisunBPEncryptionRow)
                    {
                        var item = row as KirisunBPEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write((byte)item.ActivateOptions.TrunkSystem);
                        bw.Write((byte)item.ActivateOptions.MFID);
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write((byte)item.ActivateOptions.ColorCode);
                        bw.Write(Swap(item.ActivateOptions.TGID));
                        bw.Write((byte)item.ActivateOptions.TimeSlot);
                        bw.Write((byte)item.ActivateOptions.EncryptionValue);
                        bw.Write((byte)EncryptionMethodEnum.KirisunBP);
                        bw.Write(Swap(item.KeyLength));
                        bw.Write(item.Key);
                    }
                    else if (row is HyteraEPEncryptionRow)
                    {
                        var item = row as HyteraEPEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write((byte)item.ActivateOptions.TrunkSystem);
                        bw.Write((byte)item.ActivateOptions.MFID);
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write((byte)item.ActivateOptions.ColorCode);
                        bw.Write(Swap(item.ActivateOptions.TGID));
                        bw.Write((byte)item.ActivateOptions.TimeSlot);
                        bw.Write((byte)item.ActivateOptions.EncryptionValue);
                        bw.Write((byte)EncryptionMethodEnum.HyteraEP);
                        bw.Write((uint)0); // fake key length
                        bw.Write(item.Key); // key 5 byte
                        bw.Write(item.ActivateOptions.KeyId);
                        bw.Write(new byte[26]); // key remaining part
                    }
                    else if (row is P25AESEncryptionRow)
                    {
                        var item = row as P25AESEncryptionRow;
                        bw.Write(Swap((uint)item.ActivateOptions.Options));
                        bw.Write(Swap(item.ActivateOptions.NAC));
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write(Swap(item.ActivateOptions.SourceID));
                        bw.Write(Swap(item.ActivateOptions.KeyID));
                        bw.Write((byte)0);
                        bw.Write((byte)EncryptionMethodEnum.P25AES);
                        bw.Write(Swap(item.ActivateOptions.GroupID));
                        bw.Write(item.Key); // key 32 byte
                    }

                    else
                        bw.BaseStream.Position += ENC_METHOD_STRUCT_SIZE; // enc method struct size
                }

                // write notes
                foreach (var item in project.EcryptionRows)
                {
                    bw.Write(item.Notes);
                }
            }
        }

        public static Project Import(string filename)
        {
            try
            {
                var licensing = new Licensing();
                licensing.MotorolaBPUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];
                licensing.MotorolaEPUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];
                licensing.HyteraBPUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];
                licensing.NxdnScramblerUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];
                licensing.P25ADPUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];
                licensing.P25DESUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];
                licensing.DMRAESUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];
                licensing.HyteraEPUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];
                licensing.P25AESUnlockKey = new byte[Licensing.UNLOCK_KEY_LEN];

                var keyMapping = new KeyMapping();
                var rows = new List<IEncryptionRow>();
                byte [] macAddress = null;
                ScannerModelEnum scannerModel;
                DisplayAdditionalInfo displayAdditionalInfo = new DisplayAdditionalInfo();

                var muteEncrypted = false;
                var ledAlertWhile = false;

                using (BinaryReader br = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read)))
                {
                    var sig = br.ReadUInt32();
                    if (SIGNATURE != sig)
                        throw new Exception($"Wrong Signature. File: {filename}");
                    var version = Swap(br.ReadUInt32());
                    if (VERSION < version)
                        throw new Exception($"Not Supported Version({version}) File.");

                    br.BaseStream.Position = KEY_STORAGE_OFFSET;
                    var bs = br.ReadBytes(Licensing.UNLOCK_KEY_LEN);
                    Buffer.BlockCopy(bs, 0, licensing.HyteraBPUnlockKey, 0, Licensing.UNLOCK_KEY_LEN);
                    bs = br.ReadBytes(Licensing.UNLOCK_KEY_LEN);
                    Buffer.BlockCopy(bs, 0, licensing.MotorolaBPUnlockKey, 0, Licensing.UNLOCK_KEY_LEN);
                    bs = br.ReadBytes(Licensing.UNLOCK_KEY_LEN);
                    Buffer.BlockCopy(bs, 0, licensing.NxdnScramblerUnlockKey, 0, Licensing.UNLOCK_KEY_LEN);
                    bs = br.ReadBytes(Licensing.UNLOCK_KEY_LEN);
                    Buffer.BlockCopy(bs, 0, licensing.MotorolaEPUnlockKey, 0, Licensing.UNLOCK_KEY_LEN);
                    bs = br.ReadBytes(Licensing.UNLOCK_KEY_LEN);
                    Buffer.BlockCopy(bs, 0, licensing.P25ADPUnlockKey, 0, Licensing.UNLOCK_KEY_LEN);
                    bs = br.ReadBytes(Licensing.UNLOCK_KEY_LEN);
                    Buffer.BlockCopy(bs, 0, licensing.P25DESUnlockKey, 0, Licensing.UNLOCK_KEY_LEN);
                    bs = br.ReadBytes(Licensing.UNLOCK_KEY_LEN);
                    Buffer.BlockCopy(bs, 0, licensing.DMRAESUnlockKey, 0, Licensing.UNLOCK_KEY_LEN);
                    bs = br.ReadBytes(Licensing.UNLOCK_KEY_LEN);
                    Buffer.BlockCopy(bs, 0, licensing.HyteraEPUnlockKey, 0, Licensing.UNLOCK_KEY_LEN);
                    bs = br.ReadBytes(Licensing.UNLOCK_KEY_LEN);
                    Buffer.BlockCopy(bs, 0, licensing.P25AESUnlockKey, 0, Licensing.UNLOCK_KEY_LEN);

                    br.BaseStream.Position = LED_ALERT_WHILE_DIGITAL_VOICE_GO_ON_OFFSET;
                    ledAlertWhile = br.ReadByte() == 1;

                    br.BaseStream.Position = DISPLAY_ADD_INFO_OFFSET;
                    displayAdditionalInfo.Line1 = (DisplayAdditionalInfoValuesEnum)br.ReadByte();
                    displayAdditionalInfo.Line0 = (DisplayAdditionalInfoValuesEnum)br.ReadByte();

                    br.BaseStream.Position = ZIPKEY_OFFSET;
                    muteEncrypted = br.ReadByte() == 1;
                    keyMapping.Key3 = (KeyMapFunctionEnum)br.ReadByte();
                    keyMapping.Key1 = (KeyMapFunctionEnum)br.ReadByte();
                    keyMapping.Key2 = (KeyMapFunctionEnum)br.ReadByte();

                    br.BaseStream.Position = MAC_ADDRESS_OFFSET;
                    macAddress = br.ReadBytes(6);

                    br.BaseStream.Position = SCANNER_MODEL_OFFSET;
                    scannerModel = (ScannerModelEnum)br.ReadByte();
                    if (scannerModel == 0)
                        scannerModel = ScannerModelEnum.BCD436HP;

                    br.BaseStream.Position = AGLO_TABLE_OFFSET;
                    var rowCount = Swap(br.ReadUInt32());
                    if (MAX_ITEMS < rowCount)
                        throw new Exception($"Too Many Encryption Rows.");

                    var notesSkipList = new List<bool>();
                    for (var i = 0; i < rowCount; i++)
                    {
                        var pos = br.BaseStream.Position;
                        br.BaseStream.Position += 17; // Encryption Method Position
                        var encMethod = (EncryptionMethodEnum)br.ReadByte();
                        br.BaseStream.Position = pos;
                        switch(encMethod)
                        {
                            case EncryptionMethodEnum.MotorolaBP:
                                {
                                    var row = new MotorolaBPEncryptionRow();
                                    row.ActivateOptions = new DmrActivateOptions();
                                    row.ActivateOptions.Options = (DmrSelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.TrunkSystem = (DmrTrunkSystemEnum)br.ReadByte();
                                    row.ActivateOptions.MFID = (DmrMfidEnum)br.ReadByte();
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.ColorCode = (DmrColorCodeEnum)br.ReadByte();
                                    row.ActivateOptions.TGID = Swap(br.ReadUInt32());
                                    row.ActivateOptions.TimeSlot = (DmrTimeSlotEnum)br.ReadByte();
                                    row.ActivateOptions.EncryptionValue = (DmrEncyptionValueEnum)br.ReadByte();
                                    br.ReadByte(); // skip enc method
                                    br.ReadUInt32(); // skip key len
                                    row.Key = br.ReadByte();
                                    br.ReadBytes(31); // key remaining part
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }

                            case EncryptionMethodEnum.MotorolaEP:
                                {
                                    var row = new MotorolaEPEncryptionRow();
                                    row.ActivateOptions = new DmrActivateOptions();
                                    row.ActivateOptions.Options = (DmrSelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.TrunkSystem = (DmrTrunkSystemEnum)br.ReadByte();
                                    row.ActivateOptions.MFID = (DmrMfidEnum)br.ReadByte();
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.ColorCode = (DmrColorCodeEnum)br.ReadByte();
                                    row.ActivateOptions.TGID = Swap(br.ReadUInt32());
                                    row.ActivateOptions.TimeSlot = (DmrTimeSlotEnum)br.ReadByte();
                                    row.ActivateOptions.EncryptionValue = (DmrEncyptionValueEnum)br.ReadByte();
                                    br.ReadByte(); // skip enc method
                                    br.ReadUInt32(); // skip key len
                                    row.Key = br.ReadBytes(5);
                                    row.ActivateOptions.KeyId = br.ReadByte();
                                    br.ReadBytes(26); // key remaining part
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }

                            case EncryptionMethodEnum.AnytoneEnc:
                                {
                                    var row = new AnytoneEncEncryptionRow();
                                    row.ActivateOptions = new DmrActivateOptions();
                                    row.ActivateOptions.Options = (DmrSelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.TrunkSystem = (DmrTrunkSystemEnum)br.ReadByte();
                                    row.ActivateOptions.MFID = (DmrMfidEnum)br.ReadByte();
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.ColorCode = (DmrColorCodeEnum)br.ReadByte();
                                    row.ActivateOptions.TGID = Swap(br.ReadUInt32());
                                    row.ActivateOptions.TimeSlot = (DmrTimeSlotEnum)br.ReadByte();
                                    row.ActivateOptions.EncryptionValue = (DmrEncyptionValueEnum)br.ReadByte();
                                    br.ReadByte(); // skip enc method
                                    br.ReadUInt32(); // skip key len
                                    row.Key = Swap(br.ReadUInt16());
                                    row.ActivateOptions.KeyId = br.ReadByte();
                                    br.ReadBytes(25); // key remaining part
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }


                            case EncryptionMethodEnum.HyteraBP:
                                {
                                    var row = new HyteraBPEncryptionRow();
                                    row.ActivateOptions = new DmrActivateOptions();
                                    row.ActivateOptions.Options = (DmrSelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.TrunkSystem = (DmrTrunkSystemEnum)br.ReadByte();
                                    row.ActivateOptions.MFID = (DmrMfidEnum)br.ReadByte();
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.ColorCode = (DmrColorCodeEnum)br.ReadByte();
                                    row.ActivateOptions.TGID = Swap(br.ReadUInt32());
                                    row.ActivateOptions.TimeSlot = (DmrTimeSlotEnum)br.ReadByte();
                                    row.ActivateOptions.EncryptionValue = (DmrEncyptionValueEnum)br.ReadByte();
                                    br.ReadByte(); // skip enc method
                                    row.KeyLength = Swap(br.ReadUInt32());
                                    row.Key = br.ReadBytes(32);
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }

                            case EncryptionMethodEnum.NxdnScrambler:
                                {
                                    var row = new NxdnScramblerEncryptionRow();
                                    row.ActivateOptions = new NxdnActivateOptions();
                                    row.ActivateOptions.Options = (NxdnSelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.KeyID = br.ReadByte();
                                    br.ReadByte();
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.RAN = br.ReadByte();
                                    row.ActivateOptions.GroupID = Swap(br.ReadUInt16());
                                    row.ActivateOptions.SourceID = Swap(br.ReadUInt16());
                                    br.ReadByte();
                                    br.ReadByte();
                                    br.ReadByte();
                                    br.ReadUInt32();
                                    row.Key = Swap(br.ReadUInt16());
                                    br.ReadBytes(30); // key remaining part
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }
                            case EncryptionMethodEnum.P25ADP:
                                {
                                    var row = new P25ADPEncryptionRow();
                                    row.ActivateOptions = new P25ActivateOptions();
                                    row.ActivateOptions.Options = (P25SelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.NAC = Swap(br.ReadUInt16());
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.SourceID = Swap(br.ReadUInt32());
                                    br.ReadByte(); // skip 
                                    br.ReadByte(); // skip 
                                    br.ReadByte(); // skip 
                                    br.ReadByte(); // skip enc method
                                    row.ActivateOptions.GroupID = Swap(br.ReadUInt32());
                                    row.Key = br.ReadBytes(5);
                                    row.ActivateOptions.KeyID = Swap(br.ReadUInt16());
                                    br.ReadBytes(25); // key remaining part
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }
                            case EncryptionMethodEnum.P25DES:
                                {
                                    var row = new P25DESEncryptionRow();
                                    row.ActivateOptions = new P25ActivateOptions();
                                    row.ActivateOptions.Options = (P25SelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.NAC = Swap(br.ReadUInt16());
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.SourceID = Swap(br.ReadUInt32());
                                    br.ReadByte(); // skip 
                                    br.ReadByte(); // skip 
                                    br.ReadByte(); // skip 
                                    br.ReadByte(); // skip enc method
                                    row.ActivateOptions.GroupID = Swap(br.ReadUInt32());
                                    row.Key = br.ReadBytes(8);
                                    row.ActivateOptions.KeyID = Swap(br.ReadUInt16());
                                    br.ReadBytes(22); // key remaining part
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }
                            case EncryptionMethodEnum.TytEP:
                                {
                                    var row = new TyteraEPEncryptionRow();
                                    row.ActivateOptions = new DmrActivateOptions();
                                    row.ActivateOptions.Options = (DmrSelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.TrunkSystem = (DmrTrunkSystemEnum)br.ReadByte();
                                    row.ActivateOptions.MFID = (DmrMfidEnum)br.ReadByte();
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.ColorCode = (DmrColorCodeEnum)br.ReadByte();
                                    row.ActivateOptions.TGID = Swap(br.ReadUInt32());
                                    row.ActivateOptions.TimeSlot = (DmrTimeSlotEnum)br.ReadByte();
                                    row.ActivateOptions.EncryptionValue = (DmrEncyptionValueEnum)br.ReadByte();
                                    br.ReadByte(); // skip enc method
                                    br.ReadBytes(20);
                                    row.Key = Swap(br.ReadBytes(16));
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }
                            case EncryptionMethodEnum.DmrAes:
                                {
                                    var row = new DmrAesEncryptionRow();
                                    row.ActivateOptions = new DmrActivateOptions();
                                    row.ActivateOptions.Options = (DmrSelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.TrunkSystem = (DmrTrunkSystemEnum)br.ReadByte();
                                    row.ActivateOptions.MFID = (DmrMfidEnum)br.ReadByte();
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.ColorCode = (DmrColorCodeEnum)br.ReadByte();
                                    row.ActivateOptions.TGID = Swap(br.ReadUInt32());
                                    row.ActivateOptions.TimeSlot = (DmrTimeSlotEnum)br.ReadByte();
                                    row.ActivateOptions.EncryptionValue = (DmrEncyptionValueEnum)br.ReadByte();
                                    br.ReadByte(); // skip enc method
                                    row.KeyLength = Swap(br.ReadUInt16());
                                    row.ActivateOptions.KeyId = br.ReadByte();
                                    br.ReadByte(); // skip 
                                    row.Key = br.ReadBytes(32);
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }

                            case EncryptionMethodEnum.TytBP:
                                {
                                    var row = new TyteraBPEncryptionRow();
                                    row.ActivateOptions = new DmrActivateOptions();
                                    row.ActivateOptions.Options = (DmrSelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.TrunkSystem = (DmrTrunkSystemEnum)br.ReadByte();
                                    row.ActivateOptions.MFID = (DmrMfidEnum)br.ReadByte();
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.ColorCode = (DmrColorCodeEnum)br.ReadByte();
                                    row.ActivateOptions.TGID = Swap(br.ReadUInt32());
                                    row.ActivateOptions.TimeSlot = (DmrTimeSlotEnum)br.ReadByte();
                                    row.ActivateOptions.EncryptionValue = (DmrEncyptionValueEnum)br.ReadByte();
                                    br.ReadByte(); // skip enc method
                                    br.ReadUInt32(); // skip key len
                                    row.Key = br.ReadUInt16();
                                    br.ReadBytes(30); // key remaining part
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }
                            case EncryptionMethodEnum.KirisunBP:
                                {
                                    var row = new KirisunBPEncryptionRow();
                                    row.ActivateOptions = new DmrActivateOptions();
                                    row.ActivateOptions.Options = (DmrSelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.TrunkSystem = (DmrTrunkSystemEnum)br.ReadByte();
                                    row.ActivateOptions.MFID = (DmrMfidEnum)br.ReadByte();
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.ColorCode = (DmrColorCodeEnum)br.ReadByte();
                                    row.ActivateOptions.TGID = Swap(br.ReadUInt32());
                                    row.ActivateOptions.TimeSlot = (DmrTimeSlotEnum)br.ReadByte();
                                    row.ActivateOptions.EncryptionValue = (DmrEncyptionValueEnum)br.ReadByte();
                                    br.ReadByte(); // skip enc method
                                    row.KeyLength = Swap(br.ReadUInt32());
                                    row.Key = br.ReadBytes(32);
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }

                            case EncryptionMethodEnum.HyteraEP:
                                {
                                    var row = new HyteraEPEncryptionRow();
                                    row.ActivateOptions = new DmrActivateOptions();
                                    row.ActivateOptions.Options = (DmrSelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.TrunkSystem = (DmrTrunkSystemEnum)br.ReadByte();
                                    row.ActivateOptions.MFID = (DmrMfidEnum)br.ReadByte();
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.ColorCode = (DmrColorCodeEnum)br.ReadByte();
                                    row.ActivateOptions.TGID = Swap(br.ReadUInt32());
                                    row.ActivateOptions.TimeSlot = (DmrTimeSlotEnum)br.ReadByte();
                                    row.ActivateOptions.EncryptionValue = (DmrEncyptionValueEnum)br.ReadByte();
                                    br.ReadByte(); // skip enc method
                                    br.ReadUInt32(); // skip key len
                                    row.Key = br.ReadBytes(5);
                                    row.ActivateOptions.KeyId = br.ReadByte();
                                    br.ReadBytes(26); // key remaining part
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }
                            case EncryptionMethodEnum.P25AES:
                                {
                                    var row = new P25AESEncryptionRow();
                                    row.ActivateOptions = new P25ActivateOptions();
                                    row.ActivateOptions.Options = (P25SelectedActivateOptionsEnum)Swap(br.ReadUInt32());
                                    row.ActivateOptions.NAC = Swap(br.ReadUInt16());
                                    row.Frequency = FreqToUint32(Swap(br.ReadUInt32()));
                                    row.ActivateOptions.SourceID = Swap(br.ReadUInt32());
                                    row.ActivateOptions.KeyID = Swap(br.ReadUInt16());
                                    br.ReadByte(); // skip 
                                    br.ReadByte(); // skip enc method
                                    row.ActivateOptions.GroupID = Swap(br.ReadUInt32());
                                    row.Key = br.ReadBytes(32);
                                    rows.Add(row);
                                    notesSkipList.Add(false);
                                    break;
                                }

                            default:
                                br.BaseStream.Position += ENC_METHOD_STRUCT_SIZE;
                                notesSkipList.Add(true);
                                break;
                        }
                    }

                    try
                    {
                        var countRows = 0;
                        for(var i=0; i<notesSkipList.Count; i++)
                        {
                            if (!notesSkipList[i])
                                rows[countRows++].Notes = br.ReadString();
                        }
                    }
                    catch { }
                }

                return new Project
                {
                    Scanners = new List<Scanner> 
                    {
                        new Scanner
                        {
                            Model = scannerModel,
                            KeyMapping = keyMapping,
                            Licensing = licensing,
                            MuteEncryptedVoiceTraffic = muteEncrypted,
                            MacAddress = macAddress,
                            DisplayAdditionalInfo = displayAdditionalInfo,
                            LEDAlertWhileDigitalVoiceGoesOn = ledAlertWhile
                        }

                    },
                    EcryptionRows = rows
                };
            }
            catch
            {
                return null;
            }
        }

        private static UInt32 FreqToUint32(UInt32 value)
        {
            return uint.Parse($"{value:X8}00");
        }

        private static UInt32 UInt32ToFreq(UInt32 value)
        {
            return uint.Parse((value / 100).ToString(), NumberStyles.HexNumber);
        }

        private static byte[] Swap(byte[] data)
        {
            var res = new byte[data.Length];

            for(var i=0; i<data.Length; i++)
                res[data.Length - i - 1] = data[i];

            return res;
        }

        private static uint Swap(uint value)
        {
            value = (value >> 16) | (value << 16);
            return ((value & 0xFF00FF00) >> 8) | ((value & 0x00FF00FF) << 8);

        }

        private static ushort Swap(ushort value)
        {
            return (ushort)((value >> 8) | (value << 8));
        }
    }
}
