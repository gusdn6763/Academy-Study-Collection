using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Shape
    {
        float x;
        float y;
        float width;
        float height;

        public virtual void Draw()
        {
            Console.WriteLine("초기화");
        }
    }

    class Rectangle :Shape
    {
        public override  void Draw()
        {
            base.Draw();
            Console.WriteLine("사각형 그리기");
        }
    }

    class Circle :Shape
    {
        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("원그리기");
        }
    }   

     


class CH0504
    {
        static void DrawSomething(Shape shape)
        {
            shape.Draw();
        }

        static void Main(string[] args)
        {
            Circle circle = new Circle();
            DrawSomething(circle);
            Rectangle rectangle = new Rectangle();
            DrawSomething(rectangle);
            Shape shape = new Shape();
            DrawSomething(shape);
        }
    }
}
