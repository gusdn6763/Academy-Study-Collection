using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy
{
    class Espresso
    {
        protected string taste;

        public Espresso()
        {
            taste = "쓴 맛";
        }

        public string GetTaste()
        {
            return taste;
        }
    }

    class Americano : Espresso
    {
        public Americano()
        {
            taste = "달콤한 맛";
        }

        public void ShowTaste()
        {
            Console.WriteLine(taste);
        }
    }

    class Cafelatte: Espresso
    {
        public Cafelatte()
        {
            taste = "부드러운 맛";
        }

        public void ShowTaste()
        {
            Console.WriteLine(taste);
        }
    }

    class CH07_07
    {
        static void Main(string[] args)
        {
            Espresso espresso = new Espresso();
            Console.WriteLine($"맛 = {espresso.GetTaste()}");

            Americano americano = new Americano();
            Console.WriteLine($"맛 = {americano.GetTaste()}");
            
            Cafelatte cafelatte = new Cafelatte();
            Console.WriteLine($"맛 = {cafelatte.GetTaste()}");

            if (americano is Espresso)
            {
                Console.WriteLine($"아메리카노는 에스프레소로 만듦.");
            }

            if (americano is Cafelatte)
            {
                Console.WriteLine($"아메리카노는 카페라떼로 만듦.");
            }

            if (cafelatte is Espresso)
            {
                Console.WriteLine($"카페라떼는 에스프레소로 만듦.");
            }

            Espresso e = americano as Espresso;
            if (e != null)
                Console.WriteLine("아메리카노를 에스프레소로 변신!");

            Americano a = espresso as Americano;
            if (a != null)
                Console.WriteLine("에스프레소를 아메리카노로 변신!");


        }
    }
}
