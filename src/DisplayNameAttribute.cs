using System;

namespace CFT
{
    [AttributeUsage(AttributeTargets.All)]
    public class DisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
    {
        private readonly string _name;
        public DisplayNameAttribute(string name)
        {
            _name = name;
        }

        public string Name { get { return _name; } }

        public static string GetName(object o)
        {
            if (o == null) return string.Empty;

            var t = o.GetType();
            if (t.IsEnum)
            {
                var fi = t.GetFields();
                foreach (var fieldInfo in fi)
                {
                    if (fieldInfo.Name == o.ToString())
                    {
                        var a = (DisplayNameAttribute)GetCustomAttribute(fieldInfo, typeof(DisplayNameAttribute));
                        return a == null ? fieldInfo.Name : a.Name;
                    }
                }
            }
            else
            {
                var a = (DisplayNameAttribute)GetCustomAttribute(t, typeof(DisplayNameAttribute));
                if (a != null)
                    return a.Name;

            }
            return string.Empty;
        }

        public static string GetName(Type t)
        {
            if (t == null) return string.Empty;

            var a = (DisplayNameAttribute)GetCustomAttribute(t, typeof(DisplayNameAttribute));
            return a != null ? a.Name : string.Empty;
        }
    }

}
