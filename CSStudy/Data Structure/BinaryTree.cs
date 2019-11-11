using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.Data_Structure
{
    class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }

    class BNode<T>
    {
        public T Value { get; set; }
        public BNode<T> Left { get; set; }
        public BNode<T> Right { get; set; }

        public BNode(T value)
        {
            this.Value = value;
        }
    }

    class BTree<T>
    {
        public BNode<T> Root { get; set; }
        
        public void ShowNode(BNode<T> node)
        {
            if (node == null) return;

            Console.WriteLine(node.Value);
            ShowNode(node.Left);
            ShowNode(node.Right);
        }
    }


    class BinaryTree
    {
        static void Main(string[] args)
        {
            BTree<Person> tree = new BTree<Person>();
            tree.Root = new BNode<Person>(new Person("홍길동", 23));
            tree.Root.Left = new BNode<Person>(new Person("김길동", 33));
            tree.Root.Right = new BNode<Person>(new Person("최길동", 33));

            tree.ShowNode(tree.Root);
        }
    }
}
