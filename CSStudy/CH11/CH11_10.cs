using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSStudy.CH11
{
    class Leaderboard
    {
        ArrayList scores = new ArrayList();

        public Hashtable this[int index]
        {
            get
            {
                return (Hashtable)scores[index];
            }
            set
            {
                if (index >= scores.Count)
                {
                    scores.Add(value);
                }
                else
                {
                    scores.Insert(index, value);
                }
            }
        }

        public void ShowLeaderboard()
        {
            foreach (Hashtable hashtable in scores)
            {
                Console.WriteLine($"{ hashtable["name"] } : { hashtable["score"] }");
            }
        }
    }

    class CH11_10
    {
        static void Main(string[] args)
        {
            Leaderboard lb = new Leaderboard();

            Hashtable hong = new Hashtable()
            {
                ["name"] = "홍길동",
                ["score"] = 80
            };
            Hashtable kim = new Hashtable()
            {
                ["name"] = "김길동",
                ["score"] = 90
            };
            Hashtable ko = new Hashtable()
            {
                ["name"] = "최길동",
                ["score"] = 60
            };


            lb[0] = hong;
            lb[0] = kim;
            lb[0] = ko;

            lb.ShowLeaderboard();
        }
    }
}
