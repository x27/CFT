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
        public byte KeyId { get; set; }

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
            if (IsActivated(NxdnSelectedActivateOptionsEnum.KeyId))
                sb.Append($"KeyId({KeyId}) ");
            return sb.ToString();
        }

    }
}
