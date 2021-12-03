using System;

namespace LongArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            BigNumber a = new BigNumber(333333333);
            BigNumber b = new BigNumber(111112323);
            BigNumber c;
            bool aa = a > b;
            bool ab = a < b;
            Console.WriteLine(aa);
            Console.WriteLine(ab);
            Console.WriteLine(a);
            c = b - a;
            Console.WriteLine(c);
            b.Positiveness = false;
            c = a + b;
            Console.WriteLine(c);
            c = b + a;
            Console.WriteLine(c);
        }
    }
}
