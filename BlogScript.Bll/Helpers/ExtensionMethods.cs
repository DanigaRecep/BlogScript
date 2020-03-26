using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Bll.Helpers
{
    public static class ExtensionMethods
    {
        public static bool StringEmptyChack(this string s)
        {
            return string.IsNullOrWhiteSpace(s) && string.IsNullOrEmpty(s);
        }
    }
}
