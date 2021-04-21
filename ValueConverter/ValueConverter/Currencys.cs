using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueConverter
{
    static class Currencies
    {
        public static Dictionary<string, decimal> Values = new Dictionary<string, decimal>();
        public static event Action<KeyValuePair<string, decimal>> AddedCurrency;
        public static event Action<KeyValuePair<string, decimal>> RemovedCurrency;

        static Currencies()
        {

        }

        public static void AddCurrency(KeyValuePair<string, decimal> a)
        {
            Values.Add(a.Key, a.Value);
            AddedCurrency?.Invoke(a);
        }

        public static void RemoveCurrency(KeyValuePair<string, decimal> a)
        {
            Values.Remove(a.Key);
            RemovedCurrency(a);
        }
    }
}
