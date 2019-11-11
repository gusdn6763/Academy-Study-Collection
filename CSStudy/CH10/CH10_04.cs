using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.CH10
{
    class CH10_04
    {
        static void Main(string[] args)
        {
            var person = new { Name = "홍길동", Age = 30 };
            Console.WriteLine(person.Name);
        }
    }
}
