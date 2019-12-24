using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CH1108
    {
        static void Main()
        {
            int[] score = { 89, 80, 100, 70, 60 };

            Hashtable hashtable = new Hashtable();
            hashtable["name"] = "홍길동";
            hashtable["id"] = "hong";
            hashtable["Score"] = score;
            hashtable[true] = "트루";
            hashtable[1] = "일반";

            int[] tmpScores = (int[])hashtable["Score"];

            for(int i=0;i<tmpScores.Length;i++)
            {
                Console.WriteLine(tmpScores[i]);
            }

        }
    }
}
