using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.CH11
{
    class MyClass : IEnumerable, IEnumerator
    {
        string[] student;
        int pos = -1;

        public MyClass()
        {
            student = new string[3] { "홍길동", "김길동", "최길동" };
        }

        public object Current
        {
            get
            {
                return student[pos];
            }
        }

        public bool MoveNext()
        {
            if (pos == student.Length - 1)
            {
                Reset();
                return false;
            }
            else
            {
                pos++;
                return true;
            }
        }

        public void Reset()
        {
            pos = -1;
        }

        public IEnumerator GetEnumerator()
        {
            foreach(string name in student)
            {
                yield return name;
            }
        }
    }

    class CH11_11
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            foreach(string name in myClass)
            {
                Console.WriteLine(name);
            }
        }
    }
}
