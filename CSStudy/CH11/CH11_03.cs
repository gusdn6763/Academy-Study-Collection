using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH11_03
{
    class CH11_03
    {
        static void Main(string[] args)
        {
            int[,] arr1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] arr2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] arr3 = { { 1, 2, 3 }, { 4, 5, 6 } };

            int[,,] arr4 =
            {
                { { 1, 2, 3 }, { 4, 5, 6 } },
                { { 7, 8, 9 }, { 10, 11, 12 } },
                { { 13, 14, 15 }, { 16, 17, 18 } }
            };

            int[,,,] arr5 =
            {
                {
                    { { 1, 2, 3 }, { 4, 5, 6 } },
                    { { 7, 8, 9 }, { 10, 11, 12 } },
                    { { 13, 14, 15 }, { 16, 17, 18 } }
                },
                {
                    { { 1, 2, 3 }, { 4, 5, 6 } },
                    { { 7, 8, 9 }, { 10, 11, 12 } },
                    { { 13, 14, 15 }, { 16, 17, 18 } }
                }
            };
        }
    }
}
