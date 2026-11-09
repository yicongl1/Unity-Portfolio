namespace _回合对战游戏
{
    class State
    {
        public string name { private set; get; }
        public StateType stateType { private set; get; }
        public int time; //持续时间
        public int data1 { private set; get; }  //治疗量 万分比

        public Character source { private set; get; }

        public State(string name, StateType stateType, Character source, int time, int data1)
        {
            this.name = name;
            this.stateType = stateType;
            this.source = source;
            this.time = time;
            this.data1 = data1;
        }

        public override string ToString()
        {
            return $"{name}<{time}>";
        }

    }
}
