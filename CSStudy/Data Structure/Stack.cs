using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.Data_Structure
{
class Stack
{
    private int[] stack;
    private int sp = -1;

    public int Count
    {
        get { return sp + 1; }
    }

    //없을시 생성
    public Stack()
    {
        stack = new int[100];
    }

    //스택의 사이즈 결정
    public Stack(int size)
    {
        stack = new int[size];
    }

    public void Push(int data)
    {
        stack[++sp] = data;
    }

    public int Pop()
    {
        return stack[sp--];
    }
}
 
    class StackExam
    {
        static void Main(string[] args)
        {
            Stack a = new Stack();
            a.Push(1);
            a.Push(2);
            a.Push(3);

            int cnt = a.Count;
            for (int i = 0; i < a.count ; i++)
            {
                Console.WriteLine(a.Pop());
            }
           
        }
    }
}
