using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MyNode<T>
    {
        public T value { get; set; }
        public MyNode<T> Left { get; set; }
        public MyNode<T> Right { get; set; }

        public MyNode(T value)
        {
            this.value = value;
        }
    }


    class MyNodeSearch<T>
    {
        MyNode<T> root = null;
        Comparer<T> comparer = Comparer<T>.Default;

        public void insert(T value)
        {
            MyNode<T> node = root;

            if(node==null)
            {
                root = new MyNode<T>(value);
                return;
            }
            while(node!=null)
            {
                int result = comparer.Compare(node.value, value);
                if(result==0)
                {
                    return;
                }
                else if(result>0)
                {
                    if(node.Left==null)
                    {
                        node.Left = new MyNode<T>(value);
                        return;
                    }
                    node = node.Left;
                }
                else
                {
                    if(node.Right==null)
                    {
                        node.Right = new MyNode<T>(value);
                        return;
                    }
                    node = node.Right;
                }
            }
        }
        public void ShowNodes()
        {
            ShowTree(root);
        }

        void ShowTree(MyNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            ShowTree(node.Left);
            Console.WriteLine(node.value);
            ShowTree(node.Right);
        }

        internal void insert(int v)
        {
            throw new NotImplementedException();
        }
    }


    class CH1201
    {
        static void Main()
        {
            MyNodeSearch<int> tree = new MyNodeSearch<int>();
            tree.insert(2);
            tree.insert(5);
            tree.insert(7);
        }

      
    }
}
