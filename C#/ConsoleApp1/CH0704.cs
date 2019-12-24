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

        //객체 내부의 자신을 가리키는 의미
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAge(int age)
        {
            this.age = age;
        }

    }


    class CH07_04
    {
        static void main()
        {
            Person p1 = new Person();
            p1.SetName("장현우");
            p1.SetAge(33);
        }
    }
}
