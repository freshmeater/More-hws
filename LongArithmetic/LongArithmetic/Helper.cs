using System;
using System.Collections.Generic;
using System.Text;

namespace LongArithmetic
{
    static class Helper
    {
        public static string TrimZeros(this string a)
        {
            while(a.Length > 1 && a[0] == '0')
            {
                a = a.Remove(0, 1);
            }
            return a;
        }
    }
}
