using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValueConverter
{
    class FrontIneraction
    {
        private Form1 Form;

        public FrontIneraction()
        {
            Form = new Form1();
            InitializeCurrencies(Currencies.Values);
            Currencies.AddedCurrency += AddCurrency;
            Currencies.RemovedCurrency += RemoveCurrency;
        }

        public void InitializeCurrencies(IEnumerable<KeyValuePair<string,decimal>> a)
        {
            foreach(KeyValuePair<string,decimal> x in a)
            {
                AddCurrency(x);
            }
        }
        
        public void Run()
        {
            Application.Run(Form);
        }

        public void RemoveCurrency(KeyValuePair<string,decimal> a)
        {
            Form.Currency1.Items.Remove(a.Key);
            Form.Currency2.Items.Remove(a.Key);
        }

        public void AddCurrency(KeyValuePair<string, decimal> a)
        {
            Form.Currency1.Items.Add(a.Key);
            Form.Currency2.Items.Add(a.Key);
        }

        public void WriteResult(decimal a)
        {
            Form.textBox2.Text = Math.Round(a, 2).ToString();
        }

        public decimal GetStartValue()
        {
            if (decimal.TryParse(Form.textBox1.Text, out decimal a))
                return a;
            else
                return 0;
        }

        public void SubscribeToButtonClick(EventHandler a)
        {
            Form.button1.Click += a;
        }

        public void SubscribeToFirstCurrencyChange(EventHandler a)
        {
            Form.Currency1.SelectedIndexChanged += a;
        }

        public void SubscribeToSecondCurrencyChange(EventHandler a)
        {
            Form.Currency2.SelectedIndexChanged += a;
        }

        public string GetFirstCurrency() => Form.Currency1.SelectedItem.ToString();
        public string GetSecondCurrency() => Form.Currency2.SelectedItem.ToString();
    }
}
