using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.CH11
{
    class CH11_01
    {
        static void Main(string[] args)
        {
            string[] arr = { "홍길동", "김길동", "최길동" };

            foreach (string name in arr)
                Console.WriteLine(name);
        }
    }
}
