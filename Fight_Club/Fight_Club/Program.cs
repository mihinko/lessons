using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fight_Club
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
            Application.Run(new Form1());



        }

    }
    public class Person
    {
        string name;
        int hp = 100;
        public int Hp { get { return hp; } }
        int blocked;
        public string Name { get { return name; } }
        enum chastiTela
        {
            Голова,
            Корпус,
            Ноги
        }
        
        public Person(string Name1)
        {
            name = Name1;        }
        public string GetHit(int chast)
        {

            if (chast == blocked)
            {
                Block();
                return name+" заблокировал удар";
            }
            else
            {
                int damage=0;
                switch (chast)
                {
                    case 0:
                        damage = 15;
                        Wound(15);
                        break;
                    case 1:
                        damage = 10;
                        Wound(10);
                        break;
                    case 2:
                        damage = 5;
                        Wound(5);
                        break;
                }
                if (hp < 0)
                {
                    Death();
                    return name + " умер.";
                }
                else return name + " получил урон"+damage;


            }

        }
        public void SetBlock(int chast)
        {
            blocked = chast;
        }
        public delegate void Sobytia(string message);
        public event Sobytia Wounds;
        public event Sobytia Blocks;
        public event Sobytia Deaths;

        public void Wound(int damage)
        {
            hp -= damage;
            Wounds?.Invoke($"{name} получил урон: {damage}");
        }
        public void Block()
        {
            Blocks?.Invoke($"{name} сумел защититься");
        }
        public void Death()
        {
            Deaths?.Invoke($"{name} проиграл");
        }
        
    }
}
