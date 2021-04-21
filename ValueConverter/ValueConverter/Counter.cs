using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueConverter
{
    class Counter
    {
        FrontIneraction Front;
        decimal coarse1 = 1;
        decimal coarse2 = 1;
        public event Action<decimal> ResultCounted;

        public Counter(FrontIneraction front)
        {
            Front = front;
            ResultCounted += front.WriteResult;
            front.SubscribeToButtonClick(Count);
            front.SubscribeToFirstCurrencyChange(Currency1_SelectedIndexChanged);
            front.SubscribeToSecondCurrencyChange(Currency2_SelectedIndexChanged);
        }

        private void Currency2_SelectedIndexChanged(object sender, EventArgs e)
        {
            coarse2 = Currencies.Values[Front.GetSecondCurrency()];
        }

        private void Currency1_SelectedIndexChanged(object sender, EventArgs e)
        {
            coarse1 = Currencies.Values[Front.GetFirstCurrency()];
        }

        private void Count(object sender, EventArgs e)
        {
            decimal value = Front.GetStartValue();
            decimal result = value/coarse1*coarse2;
            ResultCounted(result);
        }
    }
}
