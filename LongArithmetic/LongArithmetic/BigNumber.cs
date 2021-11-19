using System;
using System.Collections.Generic;
using System.Text;

namespace LongArithmetic
{
    class BigNumber
    {
        private readonly static int CellSize = 8;
        private readonly static int NumberOfCells = 20;
        private readonly static uint MaxCellValue = 999_999_999;
        public uint[] Number ;


        public BigNumber()
        {
            Number = new uint[NumberOfCells];
        }

        //To initialize numbers that bigger than default int, every 8th sign from the end needs to be separated by ','
        //Example: "BigNumber a = new BigNumber(12345678, 15265384);" - a will contain 1234567815265384
        //But "BigNumber a = new BigNumber(123, 456)" - 12300000456
        public BigNumber(params int[] number)
        {
            Number = FillBigNumberWithArray(number);
        }

        private uint[] FillBigNumberWithArray(int[] numberToPut)
        {
            uint[] Number = new uint[NumberOfCells];

            int lastNumberToPutIndex = numberToPut.Length - 1;
            for (int i = lastNumberToPutIndex, j = 0; i >= 0 && j < NumberOfCells; i--, j++)
            {
                Number[j] = numberToPut[i].ToUint() % (MaxCellValue + 1);
            }

            return Number;
        }

        public static BigNumber operator + (BigNumber a, BigNumber b)
        {
            uint NextCellAddition = 0;
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
