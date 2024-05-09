using System;

namespace CFT
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ScannerAttribute : Attribute
    {
        public ScannerModelEnum Model { get; private set; }
        public ScannerAttribute(ScannerModelEnum model)
        {
            Model = model;
        }
    }
}
