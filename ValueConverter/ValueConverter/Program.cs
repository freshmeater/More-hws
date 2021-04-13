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
        public static Dictionary<string, decimal> Values = new Dictionary<string, decimal>();
        [STAThread]
        static void Main()
        {
            Values.Add("USD", 1);
            Values.Add("EUR", 0.84m);
            Values.Add("RUB", 76);
            Values.Add("UAH", 28);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1(Values);
            Counter a = new Counter(form);
            a.ResultCounted += form.WriteResult;
            Application.Run(form);
        }
    }
}
