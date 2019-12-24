using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
/*
namespace ConsoleApp1
{


    class Person
    {
        string name;

        public Person(string name)
        {
            this.name = name;
        }

        public virtual void walk()
        {
            Console.WriteLine("22");
        }

        class Hero : Person
        {
            int HP;

            //base로 부모의 생성자를 실행
            public Hero(string name, int HP) : base(name)
            {
                this.HP = HP;
            }

            public override void walk()
            {
                base.walk();
                Console.WriteLine("33");

            }
        }
        static void Main()
        {

            Hero hero = new Hero("", 11);
            hero.walk();

        }
    }

    */

class Shape
{
    public float x, y, width, height;

    public virtual void Draw()
    {
        Console.WriteLine("초기화");
    }
}


class Circle : Shape
{
    public override void Draw()
    {
        base.Draw();
        Console.WriteLine("원");
    }
}


class Rectangle : Shape
{
    public sealed override void Draw()
    {
        base.Draw();
        Console.WriteLine("삼각형");
    }
}

class A
{
    static void Main()
    {


        ArrayList arr = new ArrayList();
        arr.Add(new Rectangle());
        arr.Add(new Rectangle());
        arr.Add(new Rectangle());
        arr.Add(new Rectangle());
        arr.Add(new Rectangle());
        arr.Add(new Circle());

        foreach (Shape rectangle in arr)
        {
           
            rectangle.Draw();
        }
    }
}

