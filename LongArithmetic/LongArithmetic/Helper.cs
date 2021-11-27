using System;
using System.Collections.Generic;
using System.Text;

namespace LongArithmetic
{
    static class Helper
    {
        public static string TrimZeroes(this string number)
        {
            string result = string.Empty;
            bool NumberStarted = false;
            if (number[0] == '-')
                result += '-';
            foreach (char x in number)
            {
                if (x != '0' && x != '-')
                    NumberStarted = true;
                if (NumberStarted)
                {
                    result += x;
                    continue;
                }
            }
            return result;
        }
    }
}
