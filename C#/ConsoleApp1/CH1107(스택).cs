using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class My_Stack
    {
        int[] arr = new int[100];
        int save = 0;
        int i = 0;

        public void push(int value)
        {
            arr[i] = value;
            i++;
        }

        public int pop()
        {
            i--;
            save = arr[i];
            arr[i] = 0;
            return save;
        }
    }

    class CH1107
    {    
        static void Main()
        {
            int op;
            My_Stack stack = new My_Stack();

            for (; ; )
            {
                Console.Write("푸쉬:1, 팝:2     ");
                op = int.Parse(Console.ReadLine());
                if (op == 1)
                {
                    Console.Write($"넣을값 입력");
                    op = int.Parse(Console.ReadLine());
                    stack.push(op);
                }

                else if (op == 2)
                {
                    Console.WriteLine("빼낸값" + stack.pop());

                }
            }

            /*
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            int cnt = stack.Count;

            for(int i=0;i<cnt;i++)
            {
                int val = (int)stack.Pop();
                Console.WriteLine(val);
            }
            */



        }
    }



}
