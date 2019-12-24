using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CH07_11
    {
        static void Main()
        {
            //튜플
            //여러타입의 값을 묶어 쓸때
            var person1 = ( "장현우", 11);
            Console.WriteLine($"{person1.Item1},{person1.Item2}");

            var person2 = (Name:"장현우", age:123);
            Console.WriteLine($"{person2.Name},{person2.age}");

            var (name, age) = person1;
            Console.WriteLine($"{name},{age}");

            person2 = person1;
            Console.WriteLine($"{person2.Name},{person2.age}");

        }
    }
}
