using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy
{
    struct Point
    {
        public float x;
        public float y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class CH07_14
    {
        static void Main(string[] args)
        {
            Point p1;
            p1.x = 30;
            p1.y = 20;

            Console.WriteLine($"p1.x = {p1.x}, p1.y = {p1.y}");

            Point p2 = new Point();
            p2.x = 10;
            p2.y = 10;

            Console.WriteLine($"p2.x = {p2.x}, p2.y = {p2.y}");
        }
    }
}
