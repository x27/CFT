using System;
using System.Text;

namespace CFT
{
    [Serializable]
    public class DmrActivateOptions : IActivateOptions
    {
        public DmrSelectedActivateOptionsEnum Options { get; set; }
        public DmrTrunkSystemEnum TrunkSystem { get; set; }
        public DmrMfidEnum MFID { get; set; }
        public DmrColorCodeEnum ColorCode { get; set; }
        public uint TGID { get; set; }
        public DmrTimeSlotEnum TimeSlot { get; set; }
        public DmrEncyptionValueEnum EncryptionValue { get; set; }

        public byte KeyId { get; set; }

        public DmrActivateOptions()
        {
            Activate(DmrSelectedActivateOptionsEnum.Frequency);
        }

        public bool IsActivated(DmrSelectedActivateOptionsEnum option)
        {
            return (Options & option) == option;
        }

        public void Activate(DmrSelectedActivateOptionsEnum option)
        {
            Options |= option;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (IsActivated(DmrSelectedActivateOptionsEnum.TrunkSystem))
                sb.Append($"Trunk({DisplayNameAttribute.GetName(TrunkSystem)}) ");
            if (IsActivated(DmrSelectedActivateOptionsEnum.TGID))
                sb.Append($"TGID({TGID}) ");
            if (IsActivated(DmrSelectedActivateOptionsEnum.MFID))
                sb.Append($"MFID({DisplayNameAttribute.GetName(MFID)}) ");
            if (IsActivated(DmrSelectedActivateOptionsEnum.ColorCode))
                sb.Append($"CC({(int)ColorCode}) ");
            if (IsActivated(DmrSelectedActivateOptionsEnum.KeyId))
                sb.Append($"KeyID({KeyId}) ");
            if (IsActivated(DmrSelectedActivateOptionsEnum.ForceMute))
                sb.Append($"Force Mute");
            return sb.ToString();
        }

        internal void Deactivate(DmrSelectedActivateOptionsEnum option)
        {
            Options &= ~option;
        }

        public int CompareTo(object obj)
        {
            var o = obj as DmrActivateOptions;
            if (o == null) 
                return 1;

            if (o.Options != Options) 
                return 1;

            if (IsActivated(DmrSelectedActivateOptionsEnum.TrunkSystem) && 
                o.TrunkSystem != TrunkSystem)
                return 1;

            if (IsActivated(DmrSelectedActivateOptionsEnum.MFID) &&
                o.MFID != MFID)
                return 1;

            if (IsActivated(DmrSelectedActivateOptionsEnum.ColorCode) &&
                o.ColorCode != ColorCode)
                return 1;

            if (IsActivated(DmrSelectedActivateOptionsEnum.TGID) &&
                o.TGID != TGID)
                return 1;

            if (IsActivated(DmrSelectedActivateOptionsEnum.TimeSlot) &&
                o.TimeSlot != TimeSlot)
                return 1;

            if (IsActivated(DmrSelectedActivateOptionsEnum.EncryptValue) &&
                o.EncryptionValue != EncryptionValue)
                return 1;

            if (IsActivated(DmrSelectedActivateOptionsEnum.KeyId) &&
                o.KeyId != KeyId)
                return 1;

            return 0;
        }
    }
}
