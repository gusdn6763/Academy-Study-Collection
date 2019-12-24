using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class My_stack
    {
        int[] arr = new int[100];
        public int count { get; set; }
        int save;

        public void push(int arr)
        {
            this.arr[count] = arr;
            count++;
        }

        public int pop()
        {
            count--;
            save = arr[count];
            arr[count] = 0;
            return save;
        }

    }

    class Test
    {

        static void Main()
        {
            My_stack mystack = new My_stack();
            mystack.push(1);
            mystack.push(2);
            mystack.push(3);
            Console.WriteLine(mystack.pop());
            Console.WriteLine(mystack.pop());
            Console.WriteLine(mystack.pop());
        }
    }
}
