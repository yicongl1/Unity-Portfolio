using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace _202292
{
    class Program
    {
        static void PrintList (List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();

        }

        static void EvenPlus1 (List<int> list)
        {
            for (int i = 0; i < list.Count; i+=2)
            {
                list[i]++;
            }
        }

        static List<int> KeepEven (List<int> list)
        {
            List<int> list1 = new List<int>();
            for (int i = 0; i < list.Count; i ++)
            {
                if (list[i] % 2 == 0)
                {
                    list1.Add(list[i]);
                }
            }
            return list1;
        }

        static List<int> KeepOdd(List<int> list)
        {
            List<int> list1 = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 1)
                {
                    list1.Add(list[i]);
                }
            }
            return list1;
        }

        static void RemoveEven(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>{ 2, 3, 5, 7, 9, 8, 5, 4, 2 };

            EvenPlus1(list);
            List<int> list1 = KeepEven(list);
            List<int> list2 = KeepOdd(list);


            PrintList(list);
            PrintList(list1);
            PrintList(list2);


            RemoveEven(list);
            RemoveEven(list1);
            RemoveEven(list2);

            PrintList(list);
            PrintList(list1);
            PrintList(list2);

        }
    }
}
