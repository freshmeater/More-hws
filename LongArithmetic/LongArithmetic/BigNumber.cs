using System;
using System.Collections.Generic;
using System.Text;

namespace LongArithmetic
{
    class BigNumber
    {
        readonly static int CellSize = 9;
        readonly static int NumberOfCells = 11;
        readonly static int MaxCellValue = 999_999_999;
        public readonly static int NumberSystem = 1_0000;
        public bool Positiveness;
        public int[] Number ;


        public BigNumber(bool sign = true)
        {
            Number = new int[NumberOfCells];
            Positiveness = sign;
        }

        public BigNumber(int number)
        {
            Number = Number = MakeNumberSystemArrayFromInt(number);
            if (number > 0)
                Positiveness = true;
            else
                Positiveness = false;
        }

        public BigNumber(int number, bool sign)
        {
            Number = MakeNumberSystemArrayFromInt(number);
            
            Positiveness = sign;
        }

        public BigNumber(BigNumber number)
        {
            Number = new int[NumberOfCells];
            number.Number.CopyTo(Number, 0);
            Positiveness = number.Positiveness;
        }

        public BigNumber(BigNumber number, bool sign)
        {
            Number = new int[NumberOfCells];
            number.Number.CopyTo(Number, 0);
            Positiveness = sign;
        }
        //To initialize numbers that bigger than default int, every 8th sign from the end needs to be separated by ','
        //Example: "BigNumber a = new BigNumber(123456789, 152653849);" - a will contain 123456789152653849
        //But "BigNumber a = new BigNumber(123, 456)" - 12300000456
        public BigNumber(params int[] number)
        {
            Number = FillBigNumberWithArray(number);
            Positiveness = true;
        }

        public static int[] MakeNumberSystemArrayFromInt(int a)
        {
            int[] resultArray = new int[NumberOfCells];
            int i = 0;
            while (a > 0)
            {
                resultArray[i] = a % NumberSystem;
                a /= NumberSystem;
                i++;
            }
            return resultArray;
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
            return a + new BigNumber(b);
        }

        public static BigNumber operator +(int[] a, BigNumber b)
        {
            return b + a;
        }

        public static BigNumber operator +(BigNumber a, int[] b)
        {
            BigNumber result = new BigNumber(a);

            int limiter = Math.Min(NumberOfCells, b.Length); 

            for (int i = 0; i < limiter; i++)
            {
                result.Number[i] += b[i];
            }

            return result;
        }

        public static BigNumber operator + (BigNumber a, BigNumber b)
        {
            if (a.Positiveness != b.Positiveness)
            {

                if (a.Positiveness)
                {
                    BigNumber c = new BigNumber(b, b.Positiveness.BoolInvert());
                    return a - c;
                }
                else
                {
                    BigNumber c = new BigNumber(a, a.Positiveness.BoolInvert());
                    return b - c;
                }
            }
            return Summarise(a, b);
        }

        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            if(a.Positiveness != b.Positiveness)
            {
                BigNumber c = new BigNumber(b, b.Positiveness.BoolInvert());
                return Summarise(a, c);
            }
            return Substraction(a, b);
        }

        public static BigNumber operator *(BigNumber a, int b)
        {
            BigNumber result = new BigNumber(a.Positiveness == (b > 0));

            for(int i = 0; i < NumberOfCells; i++)
            {
                long c = ((long)a.Number[i]) * b;
                result += Helper.ArrayFromLongwithAdditionalDivisons(c, i);
            }

            return result;
        }

        public static bool operator >(BigNumber a, BigNumber b)
        {
            if (a.Positiveness != b.Positiveness)
                return a.Positiveness;

            return SameSignComprasion(a,b);
        }

        public static bool operator <(BigNumber a, BigNumber b)
        {
            if (a.Positiveness != b.Positiveness)
                return b.Positiveness;

            return SameSignComprasion(b, a);
        }

        static BigNumber Summarise(BigNumber a, BigNumber b)
        {

            BigNumber result = new BigNumber(a);
            int NextCellAddition = 0;
            for (int i = 0; i < NumberOfCells; i++)
            {
                result.Number[i] = a.Number[i] + b.Number[i] + NextCellAddition;
                NextCellAddition = result.Number[i] / NumberSystem;
                result.Number[i] %= NumberSystem;
            }
            return result;
        }

        static BigNumber Substraction(BigNumber a, BigNumber b)
        {
            BigNumber number1 = UnsignedMax(a, b);
            BigNumber number2 = UnsignedMin(a, b);
            BigNumber result = new BigNumber(a > b ? true : false);
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
            if (a.Positiveness == false && b.Positiveness == false)
                return Min(b, a);
            return Max(b, a);
        }

        public static BigNumber UnsignedMin(BigNumber a, BigNumber b)
        {
            if (a.Positiveness == false && b.Positiveness == false)
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
                        return true == a.Positiveness;
                    else return false == a.Positiveness;
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
