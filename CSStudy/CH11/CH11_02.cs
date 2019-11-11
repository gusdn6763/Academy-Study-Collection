using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.CH11
{
    class CH11_02
    {
        static void addTitle(string name)
        {
            Console.WriteLine($"{name}씨 반갑습니다.");
        }

        static bool isCorrect(string name)
        {
            if (name == "홍길동")
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            string[] names = new string[] { "홍길동", "김길동", "최길동" };

            foreach (string name in names)
                Console.WriteLine(name);

            Console.WriteLine();

            /////////////////////////////////////////////////////////////////////
            // Sort
            Array.Sort(names);
            foreach (string name in names)
                Console.WriteLine(name);

            Console.WriteLine();

            /////////////////////////////////////////////////////////////////////
            // ForEach
            Array.ForEach<string>(names, new Action<string>(addTitle));

            Console.WriteLine();

            /////////////////////////////////////////////////////////////////////
            // Binary Search, IndexOf, FindIndex

            // Binary Search는 좀 더 다양한 비교 조건을 검색 가능
            int index1 = Array.BinarySearch<string>(names, "김길동");
            Console.WriteLine($"김길동의 인덱스는 {index1}");
            
            // IndexOf는 단순히 동일한 아이템을 찾는 기능
            int index2 = Array.IndexOf(names, "홍길동");
            Console.WriteLine($"홍길동의 인덱스는 {index2}");

            // FindIndex
            int index3 = Array.FindIndex<string>(names, delegate (string name)
            {
                if (name == "최길동")
                    return true;
                else
                    return false;
            });
            Console.WriteLine($"최길동의 인덱스는 {index3}");

            Console.WriteLine();

            // TrueForAll
            bool isHong = Array.TrueForAll<string>(names, delegate (string name)
            {
                if (name == "홍길동")
                    return true;
                else
                    return false;
            });

            if (isHong == true)
                Console.WriteLine("모두 홍길동입니다.");
            else
                Console.WriteLine("모두 홍길동은 아닙니다.");

            Console.WriteLine();

            // Resize
            Array.Resize<string>(ref names, 5);
            foreach (string name in names)
                Console.WriteLine(name);

            Console.WriteLine();

            // Clear
            Array.Clear(names, 0, names.Length);
            foreach (string name in names)
                Console.WriteLine(name);
        }
    }
}
