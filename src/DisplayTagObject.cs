namespace CFT
{
    public class DisplayTagObject
    {
        public string Name { get; private set; }
        public object Tag { get; set; }

        public DisplayTagObject(object o) 
        { 
            Tag = o;
            Name = DisplayNameAttribute.GetName(o);
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? Tag.ToString() : Name;
        }
    }
}