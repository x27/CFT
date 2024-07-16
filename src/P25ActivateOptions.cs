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
                sb.Append($"KeyID({KeyID}) ");
            if (IsActivated(P25SelectedActivateOptionsEnum.SourceID))
                sb.Append($"SourceID({SourceID}) ");
            if (IsActivated(P25SelectedActivateOptionsEnum.Silence))
                sb.Append($"Silence");
            return sb.ToString();
        }

    }
}
