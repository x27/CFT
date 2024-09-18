using System;
using System.Text;

namespace CFT
{
    [Serializable]
    public class P25ActivateOptions : IActivateOptions
    {
        public P25SelectedActivateOptionsEnum Options { get; set; }
        public ushort NAC { get; set; }
        public uint GroupID { get; set; }
        public ushort KeyID { get; set; }
        public uint SourceID { get; set; }

        public P25ActivateOptions()
        {
            Options = P25SelectedActivateOptionsEnum.Frequency;
        }

        public bool IsActivated(P25SelectedActivateOptionsEnum option)
        {
            return (Options & option) == option;
        }

        public void Activate(P25SelectedActivateOptionsEnum option)
        {
            Options = option | option;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (IsActivated(P25SelectedActivateOptionsEnum.NAC))
                sb.Append($"NAC({NAC:X}) ");
            if (IsActivated(P25SelectedActivateOptionsEnum.GroupID))
                sb.Append($"GroupID({GroupID}) ");
            if (IsActivated(P25SelectedActivateOptionsEnum.KeyID))
                sb.Append($"KeyID({KeyID:X}) ");
            if (IsActivated(P25SelectedActivateOptionsEnum.SourceID))
                sb.Append($"SourceID({SourceID}) ");
            if (IsActivated(P25SelectedActivateOptionsEnum.ForceMute))
                sb.Append($"Force Mute");
            return sb.ToString();
        }

        public int CompareTo(object obj)
        {
            var o = obj as P25ActivateOptions;
            if (o == null)
                return 1;

            if (o.Options != Options)
                return 1;

            if (IsActivated(P25SelectedActivateOptionsEnum.NAC) &&
                o.NAC != NAC)
                return 1;

            if (IsActivated(P25SelectedActivateOptionsEnum.GroupID) &&
                o.GroupID != GroupID)
                return 1;

            if (IsActivated(P25SelectedActivateOptionsEnum.KeyID) &&
                o.KeyID != KeyID)
                return 1;

            if (IsActivated(P25SelectedActivateOptionsEnum.SourceID) &&
                o.SourceID != SourceID)
                return 1;

            return 0;
        }
    }
}
