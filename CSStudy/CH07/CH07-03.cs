using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_03
{
    class Person
    {
        public string name;
        private int age;

        public void SetAge(int age)
        {
            this.age = age;
        }

        public Person Copy()
        {
            Person person = new Person();
            person.name = this.name;
            person.age = this.age;
            return person;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"이름: {name}, 나이: {age}");
        }
    }

    class CH07_03
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.name = "홍길동";
            p1.SetAge(33);

            Person p2 = p1.Copy();
            p2.PrintInfo();

        }
    }
}
