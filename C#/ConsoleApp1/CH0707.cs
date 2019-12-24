using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Espresso
    {
        
        protected string taste;

        public Espresso()
        {
            taste = "쓴맛";
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
            taste = "맛";
        }
    }

    class Cafelatte : Espresso
    {
        public Cafelatte()
        {
            taste = "쓴";
        }
    }

    class CH0707
    {
        static void Main()
        {
            Espresso espresso = new Espresso();

            Americano americano = new Americano();

            Cafelatte cafelatte = new Cafelatte();


            //A클래스가 B클래스의 자식인지 비교 후 1 값 리턴
            //A가 B와 같은 타입인지 비교
            if (americano is Espresso)
            {
                Console.WriteLine("1");
            }

            if (americano is Cafelatte)
            {
                Console.WriteLine("2");
            }


            if (cafelatte is Espresso)
            {
                Console.WriteLine("3");
            }

            //부모객체 생성 = 자식객체를 부모객체로 만듬
            Espresso a = americano as Espresso;
            if(a!=null)
            {
                Console.WriteLine("4");
            }


            Americano b  = espresso as Americano;
            if (b != null)
            {
                Console.WriteLine("5");
            }










        }

        
    }


}
