using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH11_04
{
    class CH11_04
    {
        static void Main(string[] args)
        {
            string[][] names = new string[3][];
            names[0] = new string[3] { "홍길동", "김길동", "최길동" };
            names[1] = new string[] { "김영수", "최영수" };
            names[2] = new string[] { "김민수", "박민수", "최민수", "고민수" };

            foreach (string[] myClass in names)
            {
                foreach (string name in myClass)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
