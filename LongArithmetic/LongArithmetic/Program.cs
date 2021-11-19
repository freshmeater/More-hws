using System;

namespace LongArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            BigNumber a = new BigNumber(1,22222222,33333333);
            BigNumber b = new BigNumber(11111111,11111111,11111111,11111);
            BigNumber c = a + b;
        }
    }
}
