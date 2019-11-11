using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy
{
    class Person
    {
        string name;

        public Person(string name)
        {
            this.name = name;
        }

        public virtual void Walk()
        {
            Console.WriteLine("Walk");
        }

        public void Run()
        {
            Console.WriteLine("Run");
        }
    }

    class Hero : Person
    {
        int HP;

        public Hero(string name, int HP) : base(name)
        {
            this.HP = HP;
        }

        public override void Walk()
        {
            Console.Write("Super-");
            base.Walk();
        }

        public new void Run()
        {
            Console.WriteLine("Super-Run");
            
        }
    }

    class CH07_09
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero("슈퍼맨", 100);
            hero.Walk();
            hero.Run();

            Person person = hero;
            hero.Run();
        }
    }
}
