using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //구체적이지 않은것
    //나를 상속할려면 이런 것이 있어야 한다, 클래스의 역할도 함
    //추상 변수, 추상 함수 만들고 싶을때
    abstract class Human
    {
        string username;

        public abstract string GetUsername();

        public void ShowUsername()
        {
            username = GetUsername();
            Console.WriteLine($"유저이름{username}");
        }
    }

        class Player:Human
        {
            public override string GetUsername()
            {
                return "홍길동";
            }
        }
        class CH0901
        {
            static void Main()
            {
                Player player = new Player();
                player.ShowUsername();
            }
        }

    
}
