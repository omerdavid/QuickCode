using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace QKConsole
{
    public static class LINQExtension
    {
        public static void ForEach<T>(this T[] source,Action<T>action)
        {
            if (source == null||source.Length==0||action==null)
                return;
            foreach (var item in source)
            {
                action(item);
            }
        }

       
    }
}
