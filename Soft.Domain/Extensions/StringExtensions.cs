using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExteions
    {
        public static bool NullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
