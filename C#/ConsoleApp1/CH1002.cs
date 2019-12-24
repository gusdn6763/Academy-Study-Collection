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
    }

    class CH1002
    {
        static void Main()
        {
            Person person = new Person();
            person.Name = "장현우";
            person.Age = 11;

            Console.WriteLine(person.PhoneNumber);
        }
    }
}
