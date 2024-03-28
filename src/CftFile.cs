using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CFT
{
    [Serializable]
    public class CftFile
    {
        const uint SIGNATURE = 0x46544643; // "CFTF"
        const ushort VERSION = 0x1;
        const int MAX_ITEMS = 1000;

        public string Filename { get; set; }
        public ushort Version { get; set; } = VERSION;

        public Licensing Licensing { get; set; } = new Licensing();

        public List<DmrEncryptionMethodItem> DmrEncryptionMethodItems { get; set; } = new List<DmrEncryptionMethodItem>();

        public static CftFile Load(string filename)
        {
            var f = new CftFile { Filename = filename };
            using (BinaryReader br = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read)))
            {
                var sig = br.ReadUInt32();
                if (SIGNATURE != sig)
                    throw new Exception($"Wrong Signature. File: {filename}");
                f.Version = br.ReadUInt16();
                if (VERSION < f.Version)
                    throw new Exception($"Not Supported Version({f.Version}) File.");

                br.BaseStream.Position = 0x10;

                var bs = br.ReadBytes(Licensing.UNLOCK_KEY_LEN);
                Buffer.BlockCopy(bs, 0, f.Licensing.HyteraBPUnlockKey, 0, Licensing.UNLOCK_KEY_LEN);
                bs = br.ReadBytes(Licensing.UNLOCK_KEY_LEN);
                Buffer.BlockCopy(bs, 0, f.Licensing.MotorolaBPUnlockKey, 0, Licensing.UNLOCK_KEY_LEN);

                br.BaseStream.Position = 0x110;

                var dmrItemsCount = br.ReadUInt32();
                if (MAX_ITEMS < dmrItemsCount)
                    throw new Exception($"Too Many DMR Encryption Method Items.");

                f.DmrEncryptionMethodItems = new List<DmrEncryptionMethodItem>();
                for (var i = 0; i < dmrItemsCount; i++)
                {
                    var item = new DmrEncryptionMethodItem
                    {
                        Options = (DmrNeedOptionsEnum)br.ReadUInt32(),
                        TrunkSystem = (DmrTrunkSystemEnum)br.ReadByte(),
                        Mfid = (DmrMfidEnum)br.ReadByte(),
                        Frequency = FreqToUint32(br.ReadUInt32()),
                        ColorCode = (DmrColorCodeEnum)br.ReadByte(),
                        Tgid = br.ReadUInt32(),
                        TimeSlot = (DmrTimeSlotEnum)br.ReadByte(),
                        EncryptionValue = (DmrEncyptionValueEnum)br.ReadByte(),
                        EncryptionMethod = (DmrEncryptionMethodEnum)br.ReadByte(),
                        KeyLength = br.ReadUInt16(),
                    };

                    bs = br.ReadBytes(DmrEncryptionMethodItem.ENC_METHOD_KEY_LEN);
                    Buffer.BlockCopy(bs, 0, item.Key, 0, DmrEncryptionMethodItem.ENC_METHOD_KEY_LEN);

                    f.DmrEncryptionMethodItems.Add(item);
                }
            }
            return f;
        }

        public void Write()
        {
            if (MAX_ITEMS < DmrEncryptionMethodItems.Count)
                throw new Exception($"Too Many DMR Encryption Method Items.");

            using (BinaryWriter bw = new BinaryWriter(new FileStream(Filename, FileMode.Create, FileAccess.Write)))
            {
                bw.Write(SIGNATURE);
                bw.Write(VERSION);
                bw.BaseStream.Position = 0x10;
                bw.Write(Licensing.HyteraBPUnlockKey);
                bw.Write(Licensing.MotorolaBPUnlockKey);
                bw.BaseStream.Position = 0x110;
                bw.Write(DmrEncryptionMethodItems.Count);
                foreach (var item in DmrEncryptionMethodItems)
                {
                    bw.Write((uint)item.Options);
                    bw.Write((byte)item.TrunkSystem);
                    bw.Write((byte)item.Mfid);
                    bw.Write(UInt32ToFreq(item.Frequency));
                    bw.Write((byte)item.ColorCode);
                    bw.Write(item.Tgid);
                    bw.Write((byte)item.TimeSlot);
                    bw.Write((byte)item.EncryptionValue);
                    bw.Write((byte)item.EncryptionMethod);
                    bw.Write(item.KeyLength);
                    bw.Write(item.Key);
                }
            }
        }

        private static UInt32 FreqToUint32(UInt32 value)
        {
            return uint.Parse($"{value:X8}00");
        }

        public static UInt32 UInt32ToFreq(UInt32 value)
        {
            return uint.Parse((value / 100).ToString(), NumberStyles.HexNumber);
        }

    }
}
