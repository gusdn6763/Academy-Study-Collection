using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        string name;
        int age;
        string phoneNumber;

        public Person()
        {
            this.name = "";
            this.age = 0;
            this.phoneNumber = "000-0000-0000";
        }


        //this는 생성자를 호출하는 구문
        public Person(string name,int age, string phoneNnumber) :this(name,age)
        {
            //같음
            //this.name = name;
            //this.age = age;
            this.phoneNumber = phoneNumber;
        }

        //this(name,age)가 2개의 매개변수를 호출하니 실행
        public Person(string name,int age): this(name)
        {
            this.age = age;
        }

        public Person(string name)
        {
            this.name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름{name},나이{age.ToString()},전화번호:{phoneNumber}");
        }
    }


    class CH07_05
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.ShowInfo();

            Person p2 = new Person("장현우",33,"010-0000-000");
            p2.ShowInfo();
        }
    }
}
