using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Shape
    {
        protected int x, y, width, height;
        public abstract int Number { get; set; }

        public void initCanvas()
        {
            Console.WriteLine("캔버스초기화");
        }

        public abstract void Draw();
    }

    class Rectangle:Shape

    {
        public override int Number { get; set; }

        public override void Draw()
        {
            Console.WriteLine("사각형 그리기");
        }
    }

    class CH1006
    {
        static void Main()
        {
            Rectangle rectangle = new Rectangle()
            {
                Number = 1
            };
            rectangle.Draw();
        }
    }
}
