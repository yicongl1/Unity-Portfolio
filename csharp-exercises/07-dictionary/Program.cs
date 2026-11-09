using System;
using System.Collections.Generic;

namespace _字典
{
    class MainClass
    {
        static void PrintDict(Dictionary<string,int> dict)
        {
            //foreach(KeyValuePair<string,int> pair in dict)
            //{
            //    Console.WriteLine($"{pair.Key}的分数为{pair.Value}");
            //}
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key}的分数为{pair.Value}");
            }
        }


        static void RemoveKey(Dictionary<string, int> dict)
        {
            //foreach (var pair in dict)
            //{
            //    if (pair.Value <= 80) dict.Remove(pair.Key);
            //}
            //使用foreach时禁止删除，C#旧版本会报错

            List<string> list = new List<string>();
            foreach (var pair in dict)
            {
                if (pair.Value <= 80) list.Add(pair.Key);
            }
            foreach(string name in list)
            {
                dict.Remove(name);
            }

        }

        static void PrintValue(Dictionary<string, int> dict, string str)
        {
            if (dict.ContainsKey(str))
            {
                Console.WriteLine(dict[str]);
            }
            else
            {
                Console.WriteLine(str + "不存在");
            }
        }

        public static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            dict.Add("小明", 80);//Key Value 键值对
            dict.Add("小红", 90);
            dict.Add("小军", 85);
            PrintValue(dict,"小红");
            PrintDict(dict);

            dict["小红"] = 95;
            dict["小憨"] = 20;   //set时，若不存在，则添加
            PrintValue(dict, "小红");
            PrintDict(dict);

            dict.Remove("小红");
            RemoveKey(dict);
            PrintDict(dict);
            PrintValue(dict, "小红");
        }
    }
}
