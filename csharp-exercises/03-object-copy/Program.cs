using System;

namespace _2022830_1
{
    class Student
    {
        private static int index = 1;
        private string name;
        private int score;
        private int rank;
        private int num;

        public Student Copy()
        {
            Student s = new Student(name, score, rank);
            return s;
        }

        public void ChangeScoreRank(int score,int rank)
        {
            this.score = score;
            this.rank = rank;
        }

        public Student(string name, int score, int rank)
        {
            this.name = name;
            this.score = score;
            this.rank = rank;
            num = index;
            index++;
        }

        public override string ToString()
        {
            return $"对象{num}：{name}分数为{score}，排名第{rank}";
        }

    }
    class MainClass
    {
        static void Main()
        {
            Student s1 = new Student("小红", 90, 2);
            Student s2 = s1.Copy();
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            s2.ChangeScoreRank(score:60,rank:10);
            Console.WriteLine("对象2改变后");
            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }
}
