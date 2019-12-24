using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface Person
    {
        int Age { get; set; }
    }

    class Player :Person
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

    class CH1005
    {
        static void Main()
        {
            Player player = new Player();
            player.Age = 11;
            Console.WriteLine(player.Age);
        }
    }

}
