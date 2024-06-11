using System.Globalization;
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
                }

                // KEY MAPPING && MUTE
                if (scanner != null && scanner.KeyMapping != null)
                {
                    bw.BaseStream.Position = ZIPKEY_OFFSET;

                    bw.Write((byte)(scanner.MuteEncryptedVoiceTraffic?1:0));
                    bw.Write((byte)scanner.KeyMapping.Key3);
                    bw.Write((byte)scanner.KeyMapping.Key1);
                    bw.Write((byte)scanner.KeyMapping.Key2);
                }

                // ENCRYPTION ROWS
                bw.BaseStream.Position = AGLO_TABLE_OFFSET;
                bw.Write(Swap((uint)project.EcryptionRows.Count));
                foreach (var row in project.EcryptionRows)
                {
                    if (row is MotorolaBPEncryptionRow)
                    {
                        var item = row as MotorolaBPEncryptionRow;
                        bw.Write(Swap((uint)(item.ActivateOptions.Options | DmrSelectedActivateOptionsEnum.Frequency)));
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
                        bw.Write(Swap((uint)(item.ActivateOptions.Options | DmrSelectedActivateOptionsEnum.Frequency)));
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
                        bw.Write(Swap((uint)(item.ActivateOptions.Options | DmrSelectedActivateOptionsEnum.Frequency)));
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
                        bw.Write(Swap((uint)(item.ActivateOptions.Options | DmrSelectedActivateOptionsEnum.Frequency)));
                        bw.Write((byte)item.ActivateOptions.TrunkSystem);
                        bw.Write((byte)item.ActivateOptions.MFID);
                        bw.Write(Swap(UInt32ToFreq(row.Frequency)));
                        bw.Write((byte)item.ActivateOptions.ColorCode);
                        bw.Write(Swap(item.ActivateOptions.TGID));
                        bw.Write((byte)item.ActivateOptions.TimeSlot);
                        bw.Write((byte)item.ActivateOptions.EncryptionValue);
                        bw.Write((byte)EncryptionMethodEnum.HyteraBP);
                        bw.Write(Swap((uint)item.KeyLength));
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
                        bw.Write(Swap((uint)(item.ActivateOptions.Options | P25SelectedActivateOptionsEnum.Frequency)));
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

                var keyMapping = new KeyMapping();
                var rows = new List<IEncryptionRow>();

                var muteEncrypted = false;

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

                    br.BaseStream.Position = ZIPKEY_OFFSET;
                    muteEncrypted = br.ReadByte() == 1;
                    keyMapping.Key3 = (KeyMapFunctionEnum)br.ReadByte();
                    keyMapping.Key1 = (KeyMapFunctionEnum)br.ReadByte();
                    keyMapping.Key2 = (KeyMapFunctionEnum)br.ReadByte();

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
                                    row.KeyLength = (HyteraKeyLengthEnum)Swap(br.ReadUInt32());
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
                            KeyMapping = keyMapping,
                            Licensing = licensing,
                            MuteEncryptedVoiceTraffic = muteEncrypted
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
