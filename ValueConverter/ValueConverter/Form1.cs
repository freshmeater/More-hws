using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValueConverter
{
    public partial class Form1 : Form
    {
        
        public Form1(IEnumerable<KeyValuePair<string, decimal>> Values)
        {
            InitializeComponent();
            InitializeCurrencies(Values);
        }

        public void WriteResult(decimal a)
        {
            textBox2.Text = a.ToString();
        }

        public void SubscribeToButtonClick(EventHandler a)
        {
            button1.Click += a;
        }

        public decimal GetStartValue()
        {
            if (decimal.TryParse(textBox1.Text, out decimal a))
                return a;
            else return 0;
        }

        private void InitializeCurrencies(IEnumerable<KeyValuePair<string,decimal>> Values)
        {

            foreach (KeyValuePair<string,decimal> a in Values)
            {
                Currency1.Items.Add(a.Key);
                Currency2.Items.Add(a.Key);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void Currency1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}