using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSStudy.CH11
{
    class CH11_08
    {
        static void Main(string[] args)
        {
            int[] scores = { 80, 90, 100, 70, 60 };

            Hashtable hashtable = new Hashtable();
            hashtable["name"] = "홍길동";
            hashtable["id"] = "hong";
            hashtable["scores"] = scores;

            int[] tmpScores = (int[])hashtable["scores"];
            
            for (int i = 0; i < tmpScores.Length; i++)
            {
                Console.WriteLine(tmpScores[i]);
            }
        }
    }
}
