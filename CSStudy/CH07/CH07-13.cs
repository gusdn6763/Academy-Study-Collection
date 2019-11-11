using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extension;

namespace Extension
{
    public static class IntegerExtension
    {
        public static int Square(this int value)
        {
            return value * value;
        }
    }
}

namespace CH07_13
{
    class CH07_13
    {
        static void Main(string[] args)
        {
            Console.WriteLine(2.Square());
        }
    }

}