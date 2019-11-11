using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.Data_Structure
{
    class LinkedList
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            list.AddLast("홍길동");
            list.AddLast("김길동");
            list.AddLast("최길동");

            LinkedListNode<string> node = list.Find("김길동");
            node = node.Next;

            Console.WriteLine(node.Value);

            list.ToList().ForEach(p => Console.WriteLine(p));

            foreach (var name in list)
            {
                Console.WriteLine(name);
            }


        }
    }
}
