using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.Data_Structure
{
    class BinarySearch
    {
        static int BSearch<T>(T[] arr, T target)
        {
            int first = 0;
            int mid = 0;
            int last = arr.Length;

            Comparer<T> comparer = Comparer<T>.Default;

            while (first <= last)
            {
                Console.WriteLine("탐색중...");
                mid = (first + last) / 2;       // 나머지는 버림
                int result = comparer.Compare(arr[mid], target);
                if (result == 0)
                {
                    return mid;
                }
                else if (result > 0)            // arr[mid]가 더 크면
                {
                    last = mid - 1;             // 최종 위치를 mid 이전 인덱스로 설정
                }
                else
                {
                    first = mid + 1;            // 시작 위치를 mid 이후 인덱스으로 설정
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

int first = 0;
int mid = 0;
int last = arr.Length;

int target = 6;

while (first <= last)
{
    mid = (first + last) / 2;

    if (arr[mid] == target)
    {
        Console.WriteLine(mid);
        break;
    }
    else if (arr[mid] > target)
    {
        last = mid - 1;
    }
    else
    {
        first = mid + 1;
    }
}
        }

    }
}
