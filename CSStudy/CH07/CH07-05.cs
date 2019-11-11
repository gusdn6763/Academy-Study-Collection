using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy
{
    class Person
    {
        string name;
        int age;
        string phoneNumber;

        public Person()
        {
            this.name = "이름없음";
            this.age = 0;
            this.phoneNumber = "000-0000-0000";
        }

        public Person(string name, int age, string phoneNumber) : this(name, age)
        {
            this.phoneNumber = phoneNumber;
        }

        public Person(string name, int age) : this(name)
        {
            this.age = age;
        }

        public Person(string name)
        {
            this.name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {name}, 나이: {age}, 전화번호: {phoneNumber}");
        }


    }

    class CH07_05
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.ShowInfo();
            Person p2 = new Person("홍길동", 33, "010-555-5555");
            p2.ShowInfo();
        }
    }
}
