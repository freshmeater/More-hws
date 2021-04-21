using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValueConverter
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Currencies.AddCurrency(new KeyValuePair<string,decimal>("USD", 1m));
            Currencies.AddCurrency(new KeyValuePair<string, decimal>("EUR", 0.84m));
            Currencies.AddCurrency(new KeyValuePair<string, decimal>("RUB", 76));
            Currencies.AddCurrency(new KeyValuePair<string, decimal>("UAH", 28));
            FrontIneraction front = new FrontIneraction();
            Counter a = new Counter(front);
            front.Run();
        }
    }
}
