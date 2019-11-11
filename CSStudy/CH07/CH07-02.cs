using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_02
{
    class Calculator
    {
        public static int calcNumber = 0;

        public static int Add(int i, int j)
        {
            calcNumber++;
            return i + j;
        }
    }

    class CH07_02
    {
        static void Main(string[] args)
        {
            int result = Calculator.Add(2, 3);
            result = Calculator.Add(3, 5);
            result = Calculator.Add(1, 5);

            Console.WriteLine($"Calculator Number = {Calculator.calcNumber}");
        }
    }
}
