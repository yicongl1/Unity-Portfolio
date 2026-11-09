using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1
{
    class Bottle
    {
        public int max;
        public int now;
        public int t;
        public void Pour()
        {
            Console.WriteLine("你要倒出多少毫升水？");
            this.now -= int.Parse(Console.ReadLine());
            if (this.now <= 0)
            {
                this.now = 0;
            }
        }
        public void Add()
        {
            Console.WriteLine("你要加入多少毫升水？");
            this.now += int.Parse(Console.ReadLine());
            if (this.now >= this.max)
            {
                this.now = this.max;
            }
        }

        public void Heat()
        {
            Console.WriteLine("你要加热多少摄氏度？");
            this.t += int.Parse(Console.ReadLine());
            if (this.t >= 100)
            {
                this.t = 100;
            }
        }
    }
    class Program
    {
        static void Use(Bottle b)
        {
            Console.WriteLine($"你选择的是{b.max}ml水壶，现有温度为{b.t}摄氏度的水{b.now}ml");
            Console.WriteLine("1.倒水 2.加水 3.升温");
            Console.WriteLine("请选择需要进行的操作");
            switch (Console.ReadLine())
            {
                case "1": b.Pour();
                    break;
                case "2": b.Add();
                    break;
                case "3": b.Heat();
                    break;
                default: Console.WriteLine("请重新输入"); break;
            }
            Console.WriteLine($"水壶容量：{b.max}ml；现有水：{b.now}ml；水温：{b.t}摄氏度");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Bottle b1 = new Bottle();
            b1.max = 2000;
            b1.now = 0;
            b1.t = 10;

            Bottle b2 = new Bottle();
            b2.max = 1000;
            b2.now = 10;
            b2.t = 20;

            Bottle b3 = new Bottle();
            b3.max = 300;
            b3.now = 300;
            b3.t = 30;

            while (true)
            {
                Console.WriteLine("1.2000ml 2.1000ml 3.300ml");
                Console.WriteLine("请在以上三个水壶中选择一个进行操作");
                switch (Console.ReadLine())
                {
                    case "1": Use(b1); break;
                    case "2": Use(b2); break;
                    case "3": Use(b3); break;
                    default: Console.WriteLine("请重新输入"); break;
                }
            }
        }
    }
}
