using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStudy.Data_Structure
{
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

    class BSerchTree<T>
    {
        BNode<T> root = null;
        Comparer<T> comparer = Comparer<T>.Default;

        public void Insert(T value)
        {
            BNode<T> node = root;
            if (node == null)
            {
                root = new BNode<T>(value);
                return;
            }

            while (node != null)
            {
                int result = comparer.Compare(node.Value, value);
                if (result == 0)
                {
                    // 동일한 크기
                    return;
                }
                else if (result > 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new BNode<T>(value);
                        return;
                    }
                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new BNode<T>(value);
                        return;
                    }
                    node = node.Right;
                }
            }
        }

        public void ShowRootNode()
        {
            ShowNode(root);
        }

        public void ShowNode(BNode<T> node)
        {
            if (node == null) return;

            ShowNode(node.Left);
            Console.WriteLine(node.Value);
            ShowNode(node.Right);
        }
    }

    class BST
    {
        static void Main(string[] args)
        {
            BSerchTree<int> tree = new BSerchTree<int>();
            tree.Insert(99);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(7);

            tree.ShowRootNode();
        }
    }
}
