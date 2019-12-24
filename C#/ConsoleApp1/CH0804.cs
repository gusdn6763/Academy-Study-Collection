using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IShape
    {
        void Draw();
        
    }

    interface IMovable
    {
        void Move();
    }

    class Rectangle :A, IShape, IMovable
    {
        public void Draw()
        {
            Console.WriteLine("Draw");
        }

        public void Move()
        {
            Console.WriteLine("Move");
        }
    }

    class A
    {

    }

    class CH0804
    {
        static void Main()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Draw();
        }
    }
}
