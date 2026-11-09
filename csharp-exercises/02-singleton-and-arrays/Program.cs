using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022828_1
{

    class Utils
    {
        private static Utils instance = null;
        public static Utils Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Utils();
                    //延时初始化
                }
                return instance;
            }
        }
        Random random = new Random();

        public int RandomNum(int a, int b)
        {
            return random.Next(a, b);
        }

        public void PrintArray(int[] a, int l)
        {
            for (int i = 0; i < l; i++)
            {
                Console.Write(a[i]+" ");
            }
            Console.WriteLine();
        }

        public void PrintArray(int[,] a, int li,int lj)
        {
            for (int j = 0; j < lj; j++)
            {
                for (int i = 0; i < li; i++)
                {
                    Console.Write(a[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        private static void Main()
        {
            int[] a = new int[100];
            int[,] b = new int [100,100];

            for (int i = 0; i < 10; i++)
            {
                a[i] = Utils.Instance.RandomNum(0, 10);
            }

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    b[i,j] = Utils.Instance.RandomNum(0, 10);
                }
            }

            Utils.Instance.PrintArray(a, 10);
            Console.WriteLine();
            Utils.Instance.PrintArray(b, 10, 10);
        }
    }

}

