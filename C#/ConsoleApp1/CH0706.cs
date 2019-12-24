using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        protected string name;

        public Person(string name)
        {
            this.name = name;
        }
    }

    class Hero :Person
    {
        int age;

        //base로 부모의 생성자를 실행
        public Hero(string name,int age):base(name)
        {
            this.age = age;
        }
    }

    class CH07_06
    {
        void Main()
        {
            Person p1 = new Person("장현우");

            Hero hero = new Hero("",11);
        }
    }
}
