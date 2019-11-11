using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CH11_05
{
    class CH11_05
    {
        static void Main(string[] args)
        {
            ArrayList names = new ArrayList();
            names.Add("홍길동");
            names.Add("김길동");
            names.Add("최길동");

            foreach (string name in names)
                Console.WriteLine(name);
            Console.WriteLine();

            names.RemoveAt(1);

            foreach (string name in names)
                Console.WriteLine(name);
            Console.WriteLine();

            names.Insert(0, "마길동");

            foreach (string name in names)
                Console.WriteLine(name);
            Console.WriteLine();
        }
    }
}
