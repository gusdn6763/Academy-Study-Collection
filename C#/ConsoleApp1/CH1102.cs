using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CH1102
    {
        static void addTitle(string name)
        {
            Console.WriteLine($"{name}님");

        }
        //결정나지 않은 변수
        //일반호, 제너릭
        static T Test<T>(T i)
        {
            Console.WriteLine(i);
            return i;
        }

        static void Main()
        {
            string[] names = new string[] { "장", "현", "우" };

            /*
             * 
            Array.Sort(names);

            Console.WriteLine(names[0]);
            Console.WriteLine(names[1]);
            Console.WriteLine(names[2]);

            Console.WriteLine();
            ///////////////////////////////////////////////////////

            Test<int>(3);
            Test<string>("as");
            Console.WriteLine();
            ////////////////////////////////////////////////////////////////////

            //기준이 되는 변수 만듬
            //타입 선택
            //모든 배열의 값에 동일한 기능 실행

            Array.ForEach<string>(names,new Action<string>(addTitle));


            Console.WriteLine();
            /////////////////////////////////////////////////////////////

            //배열의 인덱스 위치값 반환 1~n
            int index1 = Array.IndexOf(names, "현");
            Console.WriteLine(index1);

            ///////////////////////////////////////////////////////////
            
            int index2 = Array.FindIndex<string>(names, delegate (string name)
             {
                 if (name.StartsWith("현"))
                 {
                     return true;
                 }

                 else
                     return false;

             });
            Console.WriteLine(index2);
            */
            ///////////////////////////////////////////////////////////

            bool isHong = Array.TrueForAll<string>(names, delegate (string name)
            {
                if (name == "장현우")
                {
                    return true;
                }
                else
                    return false;
            });
            Console.WriteLine(isHong);

        }
    }
}