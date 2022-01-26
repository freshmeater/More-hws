using System;
using System.Collections.Generic;

namespace SmartFibonacci
{
    class Program
    {
        static Dictionary<int, long> CountedFibs = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            CountedFibs.Add(0, 0);
            CountedFibs.Add(1, 1);
            CountedFibs.Add(2, 1);
            Console.WriteLine(AlternativeCount(44));
        }

        static long CountFib(int n)
        {
            if (CountedFibs.ContainsKey(n))
                return CountedFibs[n];

            long Fib = CountFibByMultiplicity(n);
            CountedFibs.Add(n, Fib);

            return Fib; 
        }

        static long CountFibByMultiplicity(int n)
        {
            if (n % 5 == 0)
                return GetMultipleOfFive(n);

            if (n % 3 == 0)
                return GetMultipleOfThree(n);

            if (n % 2 == 0)
                return GetMultipleOfTwo(n);

            return GetNotMultipleOfTwo(n);
        }

        static long GetMultipleOfFive(int n)
        {
            long a = CountFib(n/5);
            long aPow2 = a*a*a;
            long aPow3 = a*a;
            long sign = n%2 == 0 ? 1 : -1;

            return 25*aPow2*aPow3 + 25*sign*aPow3 + 5*a;
        }

        static long GetMultipleOfThree(int n)
        {
            long a = CountFib(n/3 + 1);
            long b = CountFib(n/3);
            long c = CountFib(n/3 - 1);

            return a*a*a + b*b*b - c*c*c;
        }

        static long GetMultipleOfTwo(int n)
        {
            long a = CountFib(n/2 + 1);
            long b = CountFib(n/2 - 1);

            return a*a - b*b;
        }

        static long GetNotMultipleOfTwo(int n)
        {
            long a = AlternativeCount(n / 2 + 1);
            long b = AlternativeCount(n / 2);
            long res = a * a + b * b;

            return res;
        }

        static long AlternativeCount(int n)
        {
            if (CountedFibs.ContainsKey(n))
                return CountedFibs[n];

            long Fib = AlternativeCountFibByMultiplicity(n);
            CountedFibs.Add(n, Fib);

            return Fib;
        }

        static long AlternativeCountFibByMultiplicity(int n)
        {
            if (n % 2 == 0)
                return AlternativeGetMultipleOfTwo(n);

            return AlternativeGetNotMultipleOfTwo(n);
        }

        static long AlternativeGetMultipleOfTwo(int n)
        {
            long a = AlternativeCount(n/2 + 1);
            long b = AlternativeCount(n/2 - 1);
            long res = a*a - b*b;

            return res;
        }

        static long AlternativeGetNotMultipleOfTwo(int n)
        {
            long a = AlternativeCount(n/2 + 1);
            long b = AlternativeCount(n/2);
            long res = a*a + b*b;

            return res;
        }
    }
}