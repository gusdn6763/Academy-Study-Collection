using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_12
{
    partial class Person
    {
        string name;
    }

    partial class Person
    {
        public void Walk()
        {
            Console.WriteLine("걷는 중...");
        }
    }

    class CH07_12
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Walk();
        }
    }
}
