using System;
using System.Collections.Generic;
using System.Text;

namespace LongArithmetic
{
    class BigNumber
    {
        private readonly static int CellSize = 9;
        private readonly static int NumberOfCells = 20;
        private readonly static int MaxCellValue = 999_999_999;
        private readonly static int NumberSystem = 1_000_000_000;
        public bool Positiveness;
        public int[] Number ;


        public BigNumber()
        {
            Number = new int[NumberOfCells];
            Positiveness = true;
        }

        public BigNumber(BigNumber number)
        {
            number.Number.CopyTo(Number, NumberOfCells);
            Positiveness = true;
        }
        //To initialize numbers that bigger than default int, every 8th sign from the end needs to be separated by ','
        //Example: "BigNumber a = new BigNumber(123456789, 152653849);" - a will contain 123456789152653849
        //But "BigNumber a = new BigNumber(123, 456)" - 12300000456
        public BigNumber(params int[] number)
        {
            Number = FillBigNumberWithArray(number);
            Positiveness = true;
        }

        private int[] FillBigNumberWithArray(int[] numberToPut)
        {
            int[] Number = new int[NumberOfCells];

            int lastNumberToPutIndex = numberToPut.Length - 1;
            for (int i = lastNumberToPutIndex, j = 0; i >= 0 && j < NumberOfCells; i--, j++)
            {
                Number[j] = numberToPut[i] % NumberSystem;
            }

            return Number;
        }

        public static BigNumber operator +(int a, BigNumber b)
        {
            return b + a;
        }

        public static BigNumber operator +(BigNumber a, int b)
        {
            int c = b % NumberSystem;
            int d = b / NumberSystem;
            return a + new BigNumber(d,c);
        }

        public static BigNumber operator + (BigNumber a, BigNumber b)
        {
            int NextCellAddition = 0;
            BigNumber result = new BigNumber();
            for (int i = 0; i < NumberOfCells; i++)
            {
                result.Number[i] = a.Number[i] + b.Number[i] + NextCellAddition;
                NextCellAddition = result.Number[i] / NumberSystem;
                result.Number[i] %= NumberSystem;
            }
            return result;
        }

        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            BigNumber c = new BigNumber();
            if(a.Positiveness !^ b.Positiveness)
            {
                c = a + b;
                c.Positiveness = a.Positiveness;
                return c;
            }
            return Substraction(a, b);
        }

        public static bool operator >(BigNumber a, BigNumber b)
        {
            if (a.Positiveness ^ b.Positiveness)
            {
                if (a.Positiveness == true)
                    return true;
                else
                    return false;
            }
            return SameSignComprasion(a,b);
        }

        public static bool operator <(BigNumber a, BigNumber b)
        {
            return true;
        }

        static BigNumber Substraction(BigNumber a, BigNumber b)
        {
            BigNumber result = new BigNumber();
            BigNumber number1 = UnsignedMax(a, b);
            BigNumber number2 = UnsignedMin(a, b);
            int debt = 0;
            for (int i = 0; i < NumberOfCells; i++) 
            {
                result.Number[i] = number1.Number[i] - number2.Number[i] + debt;
                if (result.Number[i] < 0)
                {
                    debt = 1;
                    result.Number[i] += NumberSystem;
                }
                else debt = 0;
            }
            return result;
        }

        public static BigNumber UnsignedMax(BigNumber a, BigNumber b)
        {
            if (a.Positiveness && b.Positiveness && false)
                return Min(b, a);
            return Max(b, a);
        }

        public static BigNumber UnsignedMin(BigNumber a, BigNumber b)
        {
            if (a.Positiveness && b.Positiveness && false)
                return Max(a, b);
            return Min(a, b);
        }

        public static BigNumber Max(BigNumber a, BigNumber b)
        {
            if (b > a)
                return b;
            return a;
        }

        public static BigNumber Min(BigNumber a, BigNumber b)
        {
            if (b > a)
                return a;
            return b;
        }

        public static bool SameSignComprasion(BigNumber a, BigNumber b)
        {
            int i = NumberOfCells - 1;
            while (i >= 0) 
            {
                if(a.Number[i] != b.Number[i])
                {
                    if (a.Number[i] > b.Number[i])
                        return true;
                    else return false;
                }
                i--;
            }
            return false;
        }

        public override string ToString()
        {
            string resultNumber = string.Empty;
            if (!Positiveness)
                resultNumber += '-';
            for (int i = NumberOfCells - 1; i >= 0; i--)
            {
                resultNumber += Number[i];
            }
            return resultNumber.TrimZeroes();
        }
    }
}
