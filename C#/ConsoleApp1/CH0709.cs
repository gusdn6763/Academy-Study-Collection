using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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
                if(this.user.energy>30)
                {
                    Console.WriteLine("빵");
                    this.user.energy -= 10;
                }
                else
                {
                    Console.WriteLine("체력부족");
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
            if(gun!=null)
            {
                gun.Shoot();
            }
            else
            {
                Console.WriteLine("무기 없음");
            }
        }

    }




    class CH0709
    {
        static void Main()
        {
            User user =new User("홍길동");
            user.Attack();
            user.GetGun();
            user.Attack();
            user.GetGun();
            user.Attack();
            user.Attack();
            user.GetGun();
            user.Attack();
            user.GetGun();
            user.Attack();
            user.GetEnergy();
            user.GetGun();
        }
    }
}
