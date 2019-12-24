using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
    class Car
    {
        Engine engine;

        public Car()
        {
            engine = new Engine();
            engine.car = this;
        }
        public void Run()
        {
            engine.StartEngine();
        }
        public void Stop()
        {
            engine.StopEngine();
        }

        public void DidReceivedEmergenctMessage(string str)
        {
            Console.WriteLine(str);
        }
    }

    class Engine
    {
        public Car car;

        public void StartEngine()
        {
            Console.WriteLine();
        }

        public void StopEngine()
        {
            Console.WriteLine();
        }

        void Emergency()
        {
            car.DidReceivedEmergenctMessage("불");
        }
    }
    */


    class Car
    {
        Engine engine;

        public Car()
        {
            engine = new Engine(this);
        }

        public virtual void RecvNoti(string msg)
        {
            Console.WriteLine(msg);
        }


    }

    class Sedan : Car
    {
        public override void RecvNoti(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    class Engine
    {

        Car car;
        public Engine(Car car)
        {
            this.car = car;
        }

        void Emergency()
        {
            car.RecvNoti("aa");
        }

    }


    class A
    {
        static void Main()
        {
            Car car = new Car();
        }
    }
}
