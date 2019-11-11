using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{
    List<string> myList = new List<string>();

    private void Start()
    {
        //myList.Add("1");
        //myList.Add("3");
        //myList.Add("2");
        //myList.Add("4");
        //myList.Sort();
        //Debug.Log(myList);
        int[] parr = new int[5] { 22, 33, 16, 3, 9 };
        string[] nameArr = new string[5] { "홍길", "이길", "좌길", "우길", "혁길" };
        MySort(parr);
        MySort(nameArr);
    }

    void MySort(int[] data)
    {
        int age = data.Length;

        for(int i=0;i< data.Length; i++)
        {
            int ptr = i;
            for (int j = i+1; j < data.Length; j++)
            {
                if(data[ptr] < data[j])
                {
                    ptr = j;
                }
            }
            int tmp = data[i];
            data[i] = data[ptr];
            data[ptr] = tmp;
        }
        Debug.Log(data);
    }

    void MySort(string[] data)
    {
        int age = data.Length;

        for (int i = 0; i < data.Length; i++)
        {
            int ptr = i;
            for (int j = i + 1; j < data.Length; j++)
            {
                string s1 = "Phone";
                string s2 = "Car";
                int result = s1.CompareTo(s2);
                if (data[ptr].CompareTo(data[j])>0)
                {
                    ptr = j;
                }
            }
            Swap(ref data[i],ref data[ptr]);
        }
        Debug.Log(data);
    }

    void Swap(ref string a,ref string b)
    {
        string tmp;
        tmp = a;
        a = b;
        b = tmp;
    }
}
