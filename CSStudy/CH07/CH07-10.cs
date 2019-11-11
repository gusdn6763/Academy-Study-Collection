using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_10
{
    class Person
    {
        public virtual void Walk()
        {

        }
    }

    class Student : Person
    {
        public sealed override void Walk()
        {
            base.Walk();
        }
    }

    class CH07_10
    {
        static void Main(string[] args)
        {

        }
    }
}
