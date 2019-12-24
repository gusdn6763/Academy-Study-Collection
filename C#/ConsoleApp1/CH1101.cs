using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CH1101
    {
        static void Main()
        {
           /*
           int save;
           int o = 2; // 0  1  2  3  4  5  6  7  8
           int[] arr = { 1, 2, 3 ,4 ,5 ,6 ,7 ,8 ,9 };
           save = arr.Length / o;

            Console.WriteLine("탐색할 값 입력");
            int input;
            input = int.Parse(Console.ReadLine());

            for (; ; )
           {
                Console.WriteLine("탐색");

                if (save < input)
                {
                    if (save<arr.Length)
                    {
                        save += arr.Length / o;
                        o *= 2;
                        
                    }
                    else
                    {
                        o++;
                    }
               
                }
                else if(save > input)
                {
                    if (save < arr.Length)
                    {
                        save -= arr.Length / o;
                        o *= 2;
                       
                    }
                    else
                    {
                        o--;
                    }

                }
                else if(save== input)
                {
                    Console.WriteLine("위치는" + save);
                    break;
                }
               
           }
            
            */
            
            int[] arr = {1, 2, 3, 4, 5, 6, 7, 8 ,9};

            int left = 0;
            int right = arr.Length;
            int mid = 0;
            int target = 1;

            while(left<=right)
            {
                mid = (left + right) / 2;

                Console.WriteLine("탐색");

                if (arr[mid]==target)
                {
                    Console.WriteLine("위치는" + mid);
                    break;
                }

                else if(arr[mid]>target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            

        }
    }
}
