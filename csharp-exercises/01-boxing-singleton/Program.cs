using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022827_1
{
    class BoxerManager
    {
        private static BoxerManager instance = null;

        public static BoxerManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new BoxerManager();
                }
                return instance;
            }
        }

        Boxer[] all = new Boxer[100];
        int index = 0;

        public Boxer CreateBoxer(string name, int hpmax, int attack)
        {
            Boxer b = new Boxer(name, hpmax, attack);
            all[index] = b;
            index++;
            return b;
        }

        public void PrintAll()
        {
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine($"{i + 1}:{all[i]}");
            }
        }
    }
    class Boxer
    {
        public string name { get; private set; }
        public int attack { get; private set; }
        public int hp { get; private set; }
        //用属性实现
        private bool rebirth;
        private bool angry;
        private int hpmax;

        public Boxer(string name, int hpmax, int attack)
        {
            this.name = name;
            this.hpmax = hpmax;
            this.hp = hpmax;
            this.attack = attack;
            rebirth = true;
            angry = false;
        }

        public void CostHp(int cost)
        {
            hp -= cost;
            if (hp <= 0)
            {
                hp = 0;
                if (rebirth == true)
                {
                    Console.WriteLine($"{name}复活，剩余复活次数：0");
                    hp = hpmax;
                    rebirth = false;
                }
            }
            if (hp <= 30 && angry == false)
            {
                Console.WriteLine($"{name}血量低于30，进入愤怒状态，攻击力翻倍");
                attack *= 2;
                angry = true;
            }

            if (hp > 30 && angry == true)
            {
                Console.WriteLine($"{name}血量高于30，愤怒状态解除");
                attack /= 2;
                angry = false;
            }
        }

        public bool IsDead()
        {
            return hp <= 0;
        }

        public override string ToString()
        {
            return $"拳击手：{name}，HP：{hp}，攻击力：{attack}";
        }
    }

    class Program
    {
        static bool Miss()
        {
            Random random = new Random();
            int miss = random.Next(1, 5);
            return miss == 4;
        }

        static void Main(string[] args)
        {
            //Boxer b1 = new Boxer("泰森", 100, 20);
            //Boxer b2 = new Boxer("阿里", 150, 15);

            Boxer b1 = BoxerManager.Instance.CreateBoxer("泰森", 100, 20);
            Boxer b2 = BoxerManager.Instance.CreateBoxer("阿里", 150, 15);

            while (!b1.IsDead() && !b2.IsDead())
            {
                if (!Miss())
                {
                    b2.CostHp(b1.attack);
                    Console.WriteLine($"{b1.name}攻击了{b2.name}，{b2.name}损失了{b1.attack}血量");
                }
                else
                {
                    Console.WriteLine($"{b1.name}攻击了{b2.name}，{b2.name}闪避了这次攻击");
                }
                Console.WriteLine($"{b2.name}hp:{b2.hp}");
                if (b2.IsDead())
                {
                    Console.WriteLine($"----{b1.name}胜利！----");
                    break;
                }

                if (!Miss())
                {
                    b1.CostHp(b2.attack);
                    Console.WriteLine($"{b2.name}攻击了{b1.name}，{b1.name}损失了{b2.attack}血量");
                }
                else
                {
                    Console.WriteLine($"{b2.name}攻击了{b1.name}，{b1.name}闪避了这次攻击");
                }
                Console.WriteLine($"{b1.name}hp:{b1.hp}");
                if (b1.IsDead())
                {
                    Console.WriteLine($"----{b2.name}胜利！----");
                    break;
                }
            }

            Boxer b3 = BoxerManager.Instance.CreateBoxer("诺诺", 15000, 0);
            Boxer b4 = BoxerManager.Instance.CreateBoxer("聪聪", 15000, 0);

            BoxerManager.Instance.PrintAll();
        }
    }
}

