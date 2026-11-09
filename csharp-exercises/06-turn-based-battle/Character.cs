using System;
using System.Collections.Generic;

namespace _回合对战游戏
{
    class Character
    {
        public string name { private set; get; }
        public int hp { private set; get; }
        public int hpMax { private set; get; }
        public int attack { private set; get; }
        public int def { private set; get; }  //cost=attack*(1-def/(300+def)) 保证破防
        public int critChance { private set; get; }  //暴击率 万分比
        public int critRate { private set; get; }  //暴击率 万分比

        public List<Skill> skills { private set; get; }
        public List<State> states { private set; get; }

        public Character(string name, int hp, int attack, int def, int critChance)
        {
            this.name = name;
            this.hp = hp;
            hpMax = hp;
            this.attack = attack;
            this.def = def;
            this.critChance = critChance;
            this.critRate = 2;
            skills = new List<Skill>();
            states = new List<State>();
        }

        public void AddSKill(Skill skill)
        {
            skills.Add(skill);
        }

        public void CostHp(int cost)
        {
            hp -= cost;
            if (hp < 0) hp = 0;
        }

        public void AddHp(int add)
        {
            hp += add;
            if (hp > hpMax) hp = hpMax;
        }

        public int Calcdamage(int attack,int cent,int def=0)
        {
            float attackActual = attack * (cent / 10000f);
            int damage = (int)(attackActual * (1 - (float)def / (300 + def)));
            return damage;
        }

        public void Attack(Skill skill, Character other)
        {
            switch (skill.skillType)
            {
                case SkillType.NormalAttack:
                    {
                        int damage = Calcdamage(attack, skill.data1, other.def);

                        other.CostHp(damage);
                        Console.WriteLine($"{this.name}使用{skill.name}，对{other.name}造成{damage}点伤害！");
                        Console.WriteLine($"{other.name}hp:{other.hp}/{other.hpMax}");
                    }
                    break;

                case SkillType.Suckblood:
                    {
                        int damage = Calcdamage(attack, skill.data1, other.def);
                        other.CostHp(damage);
                        int suck = (int)(damage * (skill.data2 / 10000f));
                        this.AddHp(suck);
                        Console.WriteLine($"{this.name}使用{skill.name}，对{other.name}造成{damage}点伤害,吸取{suck}点生命！");
                        Console.WriteLine($"{other.name}hp:{other.hp}/{other.hpMax}");
                        Console.WriteLine($"{this.name}hp:{this.hp}/{this.hpMax}");
                    }
                    break;

                case SkillType.Heal:
                    {
                        int heal = Calcdamage(attack, skill.data1);
                        other.AddHp(heal);
                        Console.WriteLine($"{this.name}使用{skill.name}，恢复{heal}点生命！");
                        Console.WriteLine($"{other.name}hp:{other.hp}/{other.hpMax}");
                    }
                    break;

                case SkillType.HealOverTime:
                    {
                        int heal = (int)(attack * (skill.data1 / 10000f));
                        other.AddHp(heal);

                        //添加状态
                        State state = new State(skill.name, StateType.Heal, this, skill.time, skill.data2);
                        states.Add(state);
                        Console.WriteLine($"{this.name}使用{skill.name}，恢复{heal}点生命，并获得{state.name}的状态！");
                        Console.WriteLine($"{other.name}hp:{other.hp}/{other.hpMax}");
                    }
                    break;
            }
        }

        public void StatesEffect()
        {
            for (int i = 0; i < states.Count; i++)
            {
                State state = states[i];
                switch (state.stateType)
                {
                    case StateType.Heal:
                        {
                            int heal = Calcdamage(state.source.attack, state.data1);
                            AddHp(heal);
                            Console.WriteLine($"{state.name}生效，恢复{heal}点生命！");
                            state.time--;
                        }
                        break;

                    case StateType.Damage:
                        {
                            int damage = Calcdamage(state.source.attack, state.data1, def);
                            CostHp(damage);
                            Console.WriteLine($"{state.name}生效，损失{damage}点生命！");
                            state.time--;
                        }
                        break;
                }
            }

            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].time == 0)
                {
                    Console.WriteLine($"{states[i].name}失效！");
                    states.RemoveAt(i);
                    i--;
                }
            }

            //删除状态

        }

        public bool IsDead()
        {
            return hp <= 0;
        }
    }
}
