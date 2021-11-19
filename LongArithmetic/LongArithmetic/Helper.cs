using System;
using System.Collections.Generic;
using System.Text;

namespace LongArithmetic
{
    static class Helper
    {
        public static uint ToUint(this int item)
        {
            if (item < 0)
                return (uint)(item * -1);
            return (uint)item;
        }
    }
}
