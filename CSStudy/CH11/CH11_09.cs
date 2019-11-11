using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSStudy.CH11
{
    class CH11_09
    {
        static void Main(string[] args)
        {
            string[] names = { "홍길동", "김길동", "최길동" };

            ArrayList nameArrayList1 = new ArrayList(names);
            ArrayList nameArrayList2 = new ArrayList() { "박길동", 23, true };

            Hashtable nameHashtable = new Hashtable()
            {
                ["반장"] = "홍길동",
                ["부반장"] = "김길동"
            };
 
            Stack nameStack = new Stack(names);
            Queue nameQueue = new Queue(names);

            foreach(string name in nameArrayList1)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            foreach (object obj in nameArrayList2)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();

            foreach (string name in nameStack)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            foreach (string name in nameQueue)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            foreach (string key in nameHashtable.Keys)
            {
                Console.WriteLine($"{key}: {nameHashtable[key]}");
            }


        }
    }
}
