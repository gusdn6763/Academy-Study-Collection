using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.CH10
{
    interface Person
    {
        int Age { get; set; }
    }

    class Player : Person
    {
        int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }

    class CH10_05
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Age = 30;

            Console.WriteLine("Age = " + player.Age);
        }
    }
}
