namespace ValueConverter
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Currency1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Currency2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Currency1
            // 
            this.Currency1.FormattingEnabled = true;
            this.Currency1.Location = new System.Drawing.Point(115, 126);
            this.Currency1.Name = "Currency1";
            this.Currency1.Size = new System.Drawing.Size(121, 21);
            this.Currency1.TabIndex = 6;
            this.Currency1.Text = "USD";
            this.Currency1.SelectedIndexChanged += new System.EventHandler(this.Currency1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(513, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 8;
            // 
            // Currency2
            // 
            this.Currency2.FormattingEnabled = true;
            this.Currency2.Location = new System.Drawing.Point(513, 126);
            this.Currency2.Name = "Currency2";
            this.Currency2.Size = new System.Drawing.Size(121, 21);
            this.Currency2.TabIndex = 9;
            this.Currency2.Text = "USD";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Currency2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Currency1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "ц";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.ComboBox Currency2;
        public System.Windows.Forms.ComboBox Currency1;
        public System.Windows.Forms.Button button1;
    }
}

