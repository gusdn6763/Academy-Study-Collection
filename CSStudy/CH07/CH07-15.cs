using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_15
{
    class CH07_15
    {
        static void Main(string[] args)
        {
            var person1 = ("홍길동", 12);
            Console.WriteLine($"{person1.Item1}, {person1.Item2}");

            var person2 = (Name: "김길동", age: 23);
            Console.WriteLine($"{person2.Name}, {person2.age}");

            var (name, age) = person1;
            Console.WriteLine($"{name}, {age}");

            person2 = person1;
            Console.WriteLine($"{person2.Name}, {person2.age}");

        }
    }
}
