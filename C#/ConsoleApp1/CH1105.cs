using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Person :IComparable
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public int CompareTo(object obj)
        {
            if(obj==null)
            {
                return 1;
            }
            Person person = obj as Person;

            if(person != null)
            {
                return this.Score.CompareTo(person.Score);
            }

            else
            {
         
                throw new ArgumentException("Object is not person");
            }
        }
    }

    class CH1105
    {
        static void Main()
        {

            ArrayList Players = new ArrayList();
            Players.Add(new Person() { Name = "장현우", Score = 50 });
            Players.Add(new Person() { Name = "김민수", Score = 40 });
            Players.Add(new Person() { Name = "최민수", Score = 30 });
            Players.Add(new Person() { Name = "홍반장", Score = 20 });
            Players.Add(new Person() { Name = "최반장", Score = 10 });


            Players.Sort();

            foreach (Person players in Players)
            {
                Console.WriteLine($"{players.Name}:{players.Score}");
            }
            /*
            ArrayList names = new ArrayList();
            names.Add("홍길동");
            names.Add("김길동");
            names.Add("최길동");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            names.RemoveAt(1);

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            names[0] = 1.ToString();

            names.Insert(0,"마길동");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

    */




        }
    }
}
