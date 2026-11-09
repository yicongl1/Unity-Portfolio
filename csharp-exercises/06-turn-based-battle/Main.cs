
using System;

namespace _回合对战游戏
{


    class MainClass
    {
        static Skill ChooseSkill (Character c)
        {
            for(int i=0;i<c.skills.Count;i++)
            {
                Console.WriteLine($"{i + 1}. {c.skills[i].name}");
            }

            int index = -1;

            while (index < 0 || index >= c.skills.Count)
            {
                index = InputNum() - 1;
            }
            return c.skills[index];
        }

        static Skill RandomSkill (Character c)
        {
            int index = Utils.random.Next(0, c.skills.Count);
            return c.skills[index];
        }

        static int InputNum()
        {
            while(true)
            {

                Console.WriteLine("请输入数字来选择技能：");
                string input = Console.ReadLine();

                int num;
                bool success = int.TryParse(input, out num);

                if(!success)
                {
                    Console.WriteLine("请重新输入");
                    continue;
                }
                return num;
            }
        }

        static void StatesPrint(Character c)
        {
            for(int i=0;i<c.states.Count;i++)
            {
                Console.WriteLine(c.states[i]);
            }
        }

        static void Main(string[] args)
        {
            Character p1 = new Character("三尾狐", 875, 124, 68, 1000);
            Skill p1Skill1 = new Skill("尾袭", SkillType.NormalAttack, 10000);
            Skill p1Skill2 = new Skill("诱惑", SkillType.Suckblood, 8000, 2000);
            Skill p1Skill3 = new Skill("治愈之光", SkillType.HealOverTime, true, 5000, 2200, 3);
            p1.AddSKill(p1Skill1);
            p1.AddSKill(p1Skill2);
            p1.AddSKill(p1Skill3);
            Character p2 = new Character("雨女", 1035, 97, 73, 500);
            Skill p2Skill1 = new Skill("泪珠", SkillType.NormalAttack, 10000);
            Skill p2Skill2 = new Skill("治疗", SkillType.Heal, true, 10000);
            p2.AddSKill(p2Skill1);
            p2.AddSKill(p2Skill2);

            int round = 1;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"------------第{round}回合------------");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                //状态生效

                p1.StatesEffect();
                StatesPrint(p1);
                //使用技能
                Skill p1Skill = ChooseSkill(p1);
                if (p1Skill.self == true)
                    p1.Attack(p1Skill, p1);
                else
                    p1.Attack(p1Skill, p2);
                if (p2.IsDead())
                {
                    Console.WriteLine($"{p1.name} 击败了 {p2.name}！");
                    break;
                }

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                //状态生效

                p2.StatesEffect();
                StatesPrint(p2);
                //使用技能
                Skill p2Skill = RandomSkill(p2);
                if (p2Skill.self == true)
                    p2.Attack(p2Skill, p2);
                else
                    p2.Attack(p2Skill, p1);

                if (p1.IsDead())
                {
                    Console.WriteLine($"{p2.name} 击败了 {p1.name}！");
                    break;
                }
                round++;
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
