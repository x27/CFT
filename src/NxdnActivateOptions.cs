using System;
using System.Text;

namespace CFT
{
    [Serializable]
    public class NxdnActivateOptions : IActivateOptions
    {
        public NxdnSelectedActivateOptionsEnum Options { get; set; }
        public byte RAN { get; set; }
        public ushort GroupID { get; set; }
        public byte KeyID { get; set; }
        public ushort SourceID { get; set; }

        public NxdnActivateOptions()
        {
            Options = NxdnSelectedActivateOptionsEnum.Frequency;
        }

        public bool IsActivated(NxdnSelectedActivateOptionsEnum option)
        {
            return (Options & option) == option;
        }

        public void Activate(NxdnSelectedActivateOptionsEnum option)
        {
            Options = option | option;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (IsActivated(NxdnSelectedActivateOptionsEnum.RAN))
                sb.Append($"RAN({RAN}) ");
            if (IsActivated(NxdnSelectedActivateOptionsEnum.GroupID))
                sb.Append($"GroupID({GroupID}) ");
            if (IsActivated(NxdnSelectedActivateOptionsEnum.KeyID))
                sb.Append($"KeyID({KeyID}) ");
            if (IsActivated(NxdnSelectedActivateOptionsEnum.SourceID))
                sb.Append($"SourceID({SourceID}) ");
            if (IsActivated(NxdnSelectedActivateOptionsEnum.ForceMute))
                sb.Append($"Force Mute");
            return sb.ToString();
        }

        public int CompareTo(object obj)
        {
            var o = obj as NxdnActivateOptions;
            if (o == null)
                return 1;

            if (o.Options != Options)
                return 1;

            if (IsActivated(NxdnSelectedActivateOptionsEnum.RAN) &&
                o.RAN != RAN)
                return 1;

            if (IsActivated(NxdnSelectedActivateOptionsEnum.GroupID) &&
                o.GroupID != GroupID)
                return 1;

            if (IsActivated(NxdnSelectedActivateOptionsEnum.KeyID) &&
                o.KeyID != KeyID)
                return 1;

            if (IsActivated(NxdnSelectedActivateOptionsEnum.SourceID) &&
                o.SourceID != SourceID)
                return 1;

            return 0;
        }
    }
}
