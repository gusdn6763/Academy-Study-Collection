using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = "010-0000-0000";

        public int Speed;
    }

    class CH1003
    {
        static void Main()
        {
            Person person = new Person()
            {
                Name = "장현우",
                PhoneNumber="----",
                Speed = 11
            };

            Console.WriteLine(person.Speed);
        }
    }
}
