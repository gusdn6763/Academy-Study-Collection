using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.CH10
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = "000-000-0000";

        public int Speed;
    }

    class CH10_03
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Name = "홍길동",
                Speed = 30
            };

            Console.WriteLine($"Speed = {person.Speed}");
        }
    }
}
