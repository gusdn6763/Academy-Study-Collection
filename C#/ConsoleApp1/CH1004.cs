using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   
    class CH1004
    {
        static void Main()
        {
            //무명형식
            //
            var person = new { Name = "장현우", Age = 30 };
            Console.WriteLine(person.Name);
        }
    }
}
