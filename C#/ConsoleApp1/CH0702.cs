using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{   
    class Calculator
    {
        //static은 전역 변수
        //class 객체를 생성하지 않아도 자동으로 생성
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
            
            int resutlt = Calculator.Add(2, 3);
            resutlt = Calculator.Add(3, 5);
            resutlt = Calculator.Add(1, 5);
            Console.WriteLine($"{Calculator.calcNumber}");
        }
    }
}
