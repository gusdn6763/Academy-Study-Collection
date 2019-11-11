using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_11
{
    class User
    {
        string name;
        int energy;

        class Gun
        {
            string name;
            User user;

            public Gun(string name, User user)
            {
                this.name = name;
                this.user = user;
            }

            public void Shoot()
            {
                if (this.user.energy > 30)
                {
                    Console.WriteLine("빵!");
                    this.user.energy -= 10;
                }
                else
                {
                    Console.WriteLine("체력이 부족합니다.");
                }
            }
        }

        Gun gun;

        public User(string name)
        {
            this.name = name;
            energy = 100;
        }

        public void GetGun()
        {
            gun = new Gun("권총", this);
        }

        public void GetEnergy()
        {
            energy += 50;
        }

        public void Attack()
        {
            if (gun != null)
            {
                gun.Shoot();
            }
            else
            {
                Console.WriteLine("무기가 없습니다.");
            }
        }
    }

    class CH07_11
    {
        static void Main(string[] args)
        {
            User user = new User("홍길동");
            user.Attack();
            user.GetGun();
            user.Attack();
            user.Attack();
            user.Attack();
            user.Attack();
            user.Attack();
            user.Attack();
            user.Attack();
            user.Attack();
            user.GetEnergy();
            user.Attack();
            user.Attack();
        }
    }
}
