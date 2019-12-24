using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IView
    {
        void Draw();
    }

    interface IShape : IView
    {
        void SetPosition(float x, float y);
        void SetSize(float width, float height);
    }

    class Rectangle : IShape
    {
        float x, y, width, height;


        public Rectangle(float x,float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            Console.WriteLine("Draw()");
        }

        public void SetPosition(float x,float y)
        {
            Console.WriteLine("SetPosition()");
        }

        public void SetSize(float width, float height)
        {
            Console.WriteLine("SetSize()");
        }
    }

    class CH08_03
    {
        static void Main()
        {
            Rectangle rectangle = new Rectangle(10, 10, 100,100);
            rectangle.SetPosition(3, 4);
        }
    }
}
