using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player
    {
        Enemy enemy;

        public Player(Enemy e)
        {
            enemy = e;
        }

        public void Die()
        {
            Console.WriteLine("사망");

            int time = 10;

            // enemy.playerDie(delegate ()
            //     {
            //         Console.WriteLine("매우기쁨");
            //     });
            enemy.playerDie(() =>
            {
                Console.WriteLine("매우슬픔");
                //다른 메모리 상에서 형성됨
                Console.WriteLine(time);
            });

            enemy.PlayerSleep((a) =>
            {
                Console.WriteLine(a);
            });

            enemy.PlayerWakeup(() =>
            {
                return true;
            });
        }
        // public void DieAction()
        // {
        //     Console.WriteLine("동작해라");
        // }
    }

    class Enemy
    {
        public delegate void PlayerDieDelegate();
        public PlayerDieDelegate player;

        public void playerDie(PlayerDieDelegate playerDieDelegate)
        {
            this.player = playerDieDelegate;
        }
        public void Excute()
        {
            this.player();
        }
        public void PlayerSleep(Action</*매개변수타입*/int> act)
        {
            act(3);
        }

        public void PlayerWakeup(Func</*반환타입*/bool> act)
        {
            bool result = act();
        }
    }

    //플레이어가 죽을시 값을 변경하고
    //여러명인 enemy가 그걸 항상 체크하기에는 비효율적임

    class Program
    {
        static void Main(string[] args)
        {
            Enemy e1 = new Enemy();
            Player p1 = new Player(e1);

            p1.Die();
            e1.Excute();
        }
    }
}