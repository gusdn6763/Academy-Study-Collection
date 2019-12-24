using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        protected string name;
        protected string age;

        public virtual void Walk()
        {
            Console.WriteLine("Walk()");
        }
    }

    class Student : Person
    {
        string major;
        public void Study()
        {
            Console.WriteLine("Study()");
        }

        public override void Walk()
        {
            //부모의 walk를 재정이 하고 있지만 부모의 기능을 실행한다는 의미
            //base.Walk();

            Console.WriteLine("Student:Walk");
        }
     
    }

    class CH0502
    {
        static void Main(string[] args)
        {
            // Person person = new Person();
            // person.Walk();
            // Student.Study();
            // Student student = new Student();
            // student.Walk();


            //컴퓨터는 이 부모 개체를 이러이러한 변수2개 함수1개로 인식
            //Person에 삽입해도 가리킬수 있는 수준은 person 수준밖에 안됨  
            Person person = new Student();
            //그래서 실행 안됨
            //person.Study();
            person.Walk();
          

   
            


            Student s1 = new Student();
            Person p1 = new Person();
            //as 명시적으로 선언한것,부모개체에게 추가로 더한 자식객체의 변수나 함수기능을 못 불러와 위험함
            //student 
            //자식객체에 부모객체 할당은 불가
            s1 = p1 as Student;
            p1.Walk();

        }
    }
}
