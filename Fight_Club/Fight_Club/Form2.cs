using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fight_Club
{
    public partial class Form2 : Form
    {
        bool khod;
        Person computer;
        Person player;

        public Form2(bool Khod, Person Player, Person Computer)
        {
            khod = Khod;
            computer = Computer;
            player = Player;
            Label label1 = new Label();
            Controls.Add(label1);
            InitializeComponent();
            label1.Size = new Size(350, 15);
            label1.Location = new Point(100, 25);
            //label1.Text = computer.Name;
            if (khod == true)
            {
                label1.Text ="Выберите, куда хотите атаковать";
            }
            else
            {
                label1.Text = "Выберите, какую часть тела хотите защитить";
            }
            string text = "У Вас " +player.Hp+" здоровья";
            label2.Text = text;
            
            text = "У противника "+computer.Hp+" здоровья";
            label3.Text = text;
            string[] chasti = { "Голова", "Корпус", "Ноги" };
            listBox1.Items.AddRange(chasti);
        }

        public Form2(string situation,bool Khod, Person Player, Person Computer)
        {
            khod = Khod;
            computer = Computer;
            player = Player;
            InitializeComponent();
            label4.Text = situation;
            if (khod == true)
            {
                label1.Text = "Выберите, куда хотите атаковать";
            }
            else
            {
                label1.Text = "Выберите, какую часть тела хотите защитить";
            }
            string text = "У Вас " + player.Hp + " здоровья";
            label2.Text = text;

            text = "У противника " + computer.Hp + " здоровья";
            label3.Text = text;
            string[] chasti = { "Голова", "Корпус", "Ноги" };
            listBox1.Items.AddRange(chasti);
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private static void ShowMessage(string message)
        {
            Label label4 = new Label();
            label4.Size = new Size(250, 20);
            label4.Location = new Point(300, 100);
            label4.Text = message;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (khod)
            {
                Random rand = new Random();
                computer.SetBlock(rand.Next(0, 2));
                string message = computer.GetHit(listBox1.SelectedIndex);
                Hide();
                khod = !(khod);
                computer.Wounds += ShowMessage;
                computer.Blocks += ShowMessage;
                if (computer.Hp <= 0)
                {
                    
                    Form3 form3 = new Form3("Вы выиграли!");
                    form3.ShowDialog();
                }
                Close();
                Form2 form2 = new Form2(message, khod, player, computer);
                form2.ShowDialog();
            }
            else
            {
                Random rand = new Random();
                player.SetBlock(listBox1.SelectedIndex);
                string message = player.GetHit(rand.Next(0, 2));
                Hide();
                khod = !khod;
                player.Wounds += ShowMessage;
                player.Blocks += ShowMessage;
                if (player.Hp <= 0)
                {
                    
                    Form3 form3 = new Form3("Вы проиграли");
                    form3.ShowDialog();
                }
                Form2 form2 = new Form2(message, khod, player, computer);
                form2.ShowDialog();
            }
        }
    }

    

       
}

