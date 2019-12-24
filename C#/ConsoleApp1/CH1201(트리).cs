using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
//T는 타입 속성을 받을때 지정해줌
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

class CH1201
{
    static void Main()
    {
        MyNode<string> node = new MyNode<string>("장현우");
        node.Left = new MyNode<string>("레프트");
        node.Right = new MyNode<string>("라이트");

        node.Left.Left = new MyNode<string>("");

        ShowTree(node);
    }

    static public void ShowTree<T>(MyNode<T> node)
    {
        if (node == null)
        {
            return;
        }
        Console.WriteLine(node.value);
        ShowTree(node.Left);
        ShowTree(node.Right);
    }
}
*/