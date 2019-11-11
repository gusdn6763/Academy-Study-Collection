using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH10_01
{
    class Person
    {
        string name;
        int age;
        string phoneNumber;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }
    }

    class CH10_01
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "홍길동";
            p1.Age = 34;
            p1.PhoneNumber = "010-555-5555";

            Console.WriteLine(p1.Name);
        }
    }
}
