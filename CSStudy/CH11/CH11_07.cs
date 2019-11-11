using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSStudy.CH11
{
    class CH11_07
    {

        static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int cnt = stack.Count;
            for(int i = 0; i < cnt; i++)
            {
                int val = (int)stack.Pop();
                Console.WriteLine(val);
            }

        }
    }
}
