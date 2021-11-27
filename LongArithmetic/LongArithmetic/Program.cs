using System;

namespace LongArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            BigNumber a = new BigNumber(333333333);
            BigNumber b = new BigNumber(111112323);
            bool aa = a > b;
            bool ab = a > b;
            Console.WriteLine(aa);
            Console.WriteLine(ab);
            Console.WriteLine(a);
            a.Positiveness = false;
            BigNumber c = a - b;
            Console.WriteLine(c);
        }
    }
}
