using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.CH10
{
    abstract class Shape
    {
        protected int x, y, width, height;
        public abstract int Number { get; set; }

        public void InitCanvas()
        {
            Console.WriteLine("캔버스 초기화");
        }

        public abstract void Draw();

    }

    class Rectangle : Shape
    {
        public override int Number { get; set; }

        public override void Draw()
        {
            Console.WriteLine("Draw()");
        }
    }

    class CH10_06
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle()
            {
                Number = 1
            };
            rectangle.Draw();
        }
    }
}
