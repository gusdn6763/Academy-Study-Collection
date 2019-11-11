using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_06
{
    class Person
    {
        protected string name;
        public Person(string name)
        {
            this.name = name;
        }

        public void ShowName()
        {
            Console.WriteLine($"이름은 {name}");
        }
    }

    class Hero : Person
    {
        int energy;

        public Hero(string name, int energy) : base(name)
        {
            this.energy = energy;
        }

        public void ShowNameAndAge()
        {
            base.ShowName();
            Console.WriteLine($"에너지는 {energy}");
        }
    }

    class CH07_06
    {
        static void Main(string[] args)
        {
            Person person = new Person("홍길동");

            Hero hero = new Hero("슈퍼맨", 100);
            hero.ShowName();
            hero.ShowNameAndAge();
        }
    }
}
