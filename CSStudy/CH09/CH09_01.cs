using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH09_01
{
    abstract class Human
    {
        string username;

        public abstract string GetUsername();
        public void ShowUsername()
        {
            username = GetUsername();
            Console.WriteLine($"유저이름: { username }");
        }
    }

    class Player : Human
    {
        public override string GetUsername()
        {
            return "홍길동";
        }
    }

    class CH09_01
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.ShowUsername();
        }
    }
}
