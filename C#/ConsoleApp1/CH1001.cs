using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        string name;
        int age;
        string phoneNumber;

        //밑에 것으로 더 좋게 만듬
        //차이점:get set 나누기 위함
        //차이점:유효성 판단 가능 ex)if
        //차이점:변수의 형태로 값을 받음
        //->>+=3 , ++등 가능

        //void SetName(string name)
        //{
        //    this.name = name;
        //}
        //

        //프로퍼티라 불름
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }


    }
    class CH1001
    {
        static void Main()
        {
            Person person = new Person();
            person.Age = 33;
            person.PhoneNumber = "010-0000-0000";
            person.Name = "장현우";

            Console.WriteLine(person.Name);
        }
    }
}
