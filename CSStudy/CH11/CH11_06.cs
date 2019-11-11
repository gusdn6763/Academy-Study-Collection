using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSStudy.CH11
{
    class CH11_06
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");
            queue.Enqueue("4");

            int cnt = queue.Count;
            
            // 아래 코드는 오류
            // for (int i = 0; i < queue.Count; i++)

            for (int i = 0; i < cnt; i++)
            {
                string val = queue.Dequeue().ToString();
                Console.WriteLine(val);
            }
        }
    }
}
