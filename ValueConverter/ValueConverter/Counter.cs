using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueConverter
{
    class Counter
    {
        Form1 Form;
        decimal coarse1 = 1;
        decimal coarse2 = 1;
        public event Action<decimal> ResultCounted;

        public Counter(Form1 form)
        {
            Form = form;
            form.SubscribeToButtonClick(Count);
            form.Currency1.SelectedIndexChanged += Currency1_SelectedIndexChanged;
            form.Currency2.SelectedIndexChanged += Currency2_SelectedIndexChanged;
        }

        private void Currency2_SelectedIndexChanged(object sender, EventArgs e)
        {
            coarse2 = Program.Values[Form.Currency2.SelectedItem.ToString()];
        }

        private void Currency1_SelectedIndexChanged(object sender, EventArgs e)
        {
            coarse1 = Program.Values[Form.Currency1.SelectedItem.ToString()];
        }

        private void Count(object sender, EventArgs e)
        {
            decimal value = Form.GetStartValue();
            decimal result = value/coarse1*coarse2;
            ResultCounted(result);
        }
    }
}
