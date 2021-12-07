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
            if (result == "" || result == "-")
                return "0";
            return result;
        }

        public static bool BoolInvert(this bool boolToConvert)
        {
            if (boolToConvert)
                return false;
            return true;
        }

        public static int[] ArrayFromLongwithAdditionalDivisons(long a, int division)
        {
            int NumberSystem = BigNumber.NumberSystem;
            int[] b = new int[2 + division];
            b[division] = (int)a % NumberSystem;
            a /= NumberSystem;
            b[division + 1] = (int)a % NumberSystem;
            return b;
        }
    }
}
