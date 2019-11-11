using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_04
{
    class Person
    {
        string name;
        int age;

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
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.SetAge(33);
            p1.SetName("홍길동");
        }
    }
}
