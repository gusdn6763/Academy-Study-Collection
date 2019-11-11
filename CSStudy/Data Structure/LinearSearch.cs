using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.Data_Structure
{
    class LinearSearch
    {
        static int LSearch<T>(T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("탐색중...");
                if (arr[i].Equals(value))
                    return i;
;           }
            return -1;
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 9, 3, 6, 0, 2, 4 };
            int[] arr1 = { "a", "b" };
            int idx = LSearch<int>(arr, 0);

            int idx = LSearch<string>(arr1, 0);
            Console.WriteLine(idx);

        }
    }
}
