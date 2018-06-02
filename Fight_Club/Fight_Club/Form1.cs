using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Fight_Club
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                
                bool khod = true;
                Person player = new Person(textBox1.Text);
                Person computer = new Person("Компьютер");
                Form2 form2 = new Form2(khod, player, computer);
                Hide();
                form2.Show();
            }
            else
            {
                label1.Text = "Не было введено имя";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Hide();

                bool khod = false;
                Person player = new Person(textBox1.Text);
                Person computer = new Person("Компьютер");
                Form2 form2 = new Form2(khod, player, computer);
                form2.ShowDialog();
            }else
            {
                label1.Text = "Не было введено имя";
            }
        }

    }
    

}
