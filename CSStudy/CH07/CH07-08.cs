using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_08
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
    }

    class CH07_08
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero("슈퍼맨", 100);
            hero.Walk();
        }
    }
}
