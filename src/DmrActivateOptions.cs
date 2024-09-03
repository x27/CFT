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
    }
}
