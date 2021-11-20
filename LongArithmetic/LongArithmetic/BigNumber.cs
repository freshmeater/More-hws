using System;
using System.Collections.Generic;
using System.Text;

namespace LongArithmetic
{
    class BigNumber
    {
        private readonly static int CellSize = 8;
        private readonly static int NumberOfCells = 20;
        private readonly static int MaxCellValue = 999_999_999;
        public int[] Number ;


        public BigNumber()
        {
            Number = new int[NumberOfCells];
        }

        public BigNumber(BigNumber number)
        {
            number.Number.CopyTo(Number, NumberOfCells);
        }
        //To initialize numbers that bigger than default int, every 8th sign from the end needs to be separated by ','
        //Example: "BigNumber a = new BigNumber(12345678, 15265384);" - a will contain 1234567815265384
        //But "BigNumber a = new BigNumber(123, 456)" - 12300000456
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

/*        public override string ToString()
        {
            string resultNumber = string.Empty;
            for(int i = NumberOfCells - 1; i >= 0; i--)
            {
                
            }
            return resultNumber;
        }*/
    }
}
