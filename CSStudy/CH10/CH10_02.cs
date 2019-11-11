using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.CH10
{
    class Person
    {
        // 자동 완성 프로퍼티
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = "000-000-0000";
    }

    class CH10_02
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "홍길동";
            p1.Age = 34;

            Console.WriteLine(p1.PhoneNumber);
        }
    }
}
