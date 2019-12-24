using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CH0505
    {
        static void Main(string[] args)
        {
            int a = 0;

                while(a<10)
            {
                a++;
                Console.WriteLine(a);
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j < 5 - i)
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine("");
            }
            for(int b=2;b<10;b++)
            {
                for(int c=1;c<10;c++)
                {
                    Console.WriteLine($"{b}*{c}={b*c}");
                }
                Console.WriteLine("");
            }

            //
            int[] d = new int[] { 1, 2, 3 };
            int[] d2 = new int[4] { 1, 2, 3, 4 };
            int[] d3 = new int[5];

            d3[0] = 1;
            foreach(int score in d)
            {
                Console.WriteLine(d);
            }

            int k = 10;
            for(int o=0;o<10;o++)
            {
                
                if(o==5)
                {
                    continue;
                }
                else if(o==7)
                {
                    break;
                }
                Console.WriteLine(o);
            }

            goto A;

            A:
            Console.WriteLine(k);
        }
    }
}
