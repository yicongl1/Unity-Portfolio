namespace _回合对战游戏
{
    class Skill
    {
        public string name { private set; get; }
        public SkillType skillType { private set; get; }
        public int data1 { private set; get; }  //普攻：攻击比例（万分比） //治疗：治疗比例  //HOT：直接治疗比例
        public int data2 { private set; get; }  //吸血：吸血比例  //HOT：持续治疗比例
        public int time { private set; get; }

        public bool self { private set; get; }

        public Skill(string name, SkillType skillType, int data1, int data2 = 0, int time = 0)
        {
            this.name = name;
            this.skillType = skillType;
            this.data1 = data1;
            this.data2 = data2;
            this.time = time;
        }

        public Skill(string name, SkillType skillType, bool self, int data1, int data2 = 0, int time = 0)
        {
            this.name = name;
            this.skillType = skillType;
            this.self = self;
            this.data1 = data1;
            this.data2 = data2;
            this.time = time;
        }
    }
}
