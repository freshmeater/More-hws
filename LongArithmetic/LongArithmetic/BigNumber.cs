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
        public int[] Number ;


        public BigNumber()
        {
            Number = new int[NumberOfCells];
        }

        //To initialize numbers that bigger than default int, every 8th sign from the end needs to be separated by ','
        //Example: "BigNumber a = new BigNumber(123456789, 152653849);" - a will contain 123456789152653849
        //But "BigNumber a = new BigNumber(123, 456)" - 123000000456
        public BigNumber(params int[] number)
        {
            Number = FillBigNumberWithArray(number);
        }

        private int[] FillBigNumberWithArray(int[] numberToPut)
        {
            int[] Number = new int[NumberOfCells];

            int lastNumberToPutIndex = numberToPut.Length - 1;
            for (int i = lastNumberToPutIndex, j = 0; i >= 0 && j < NumberOfCells; i--, j++)
            {
                Number[j] = numberToPut[i] % (MaxCellValue + 1);
            }

            return Number;
        }

        public static BigNumber operator +(int a, BigNumber b)
        {
            return b + a;
        }

        public static BigNumber operator +(BigNumber a, int b)
        {
            int c = b % (MaxCellValue + 1);
            int d = b / (MaxCellValue + 1);
            return a + new BigNumber(d,c);
        }

        public static BigNumber operator + (BigNumber a, BigNumber b)
        {
            int NextCellAddition = 0;
            BigNumber result = new BigNumber();
            for (int i = 0; i < NumberOfCells; i++)
            {
                result.Number[i] = a.Number[i] + b.Number[i] + NextCellAddition;
                NextCellAddition = result.Number[i] / (MaxCellValue + 1);
                a.Number[i] %= (MaxCellValue + 1);
            }
            return result;
        }

        public override string ToString()
        {
            string resultNumber = string.Empty;
            string temp = CreateTemp();
            for(int i = NumberOfCells - 1; i >= 0; i--)
            {
                string tempClone = temp;
                int tempNumber = Number[i];
                for (int j = CellSize-1; j >= 0; j--)
                {
                    int k = 10;
                    tempClone += tempNumber % k;
                    tempNumber /= k;
                }
                resultNumber += tempClone;
            }
            return resultNumber.TrimZeros();
        }

        private string CreateTemp()
        {
            string result = string.Empty;
            for(int i = 0; i < CellSize; i++)
            {
                result += 0;
            }
            return result;
        }
    }
}
