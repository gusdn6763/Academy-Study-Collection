using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH08_03
{
    interface IShape
    {
        void Draw();
    }

    interface IMovable
    {
        void Move();
    }

    class Rectangle : IShape, IMovable
    {
        public void Draw()
        {
            Console.WriteLine("Draw()");
        }

        public void Move()
        {
            Console.WriteLine("Move()");
        }
    }

    class CH08_03
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();

            rect.Move();
            rect.Draw();
        }
    }
}
