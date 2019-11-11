using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
struct Person
{
    public string name;
    public int age;
}

struct PersonList
{
    public Person[] persons;
}

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Person p1 = new Person();
        p1.name = "홍길동";
        p1.age = 23;


        Person p2 = new Person();
        p2.name = "최길동";
        p2.age = 26;

        Person p3 = new Person();
        p3.name = "남길동";
        p3.age = 20;

        Person[] pArr = new Person[] { p1, p2, p3 };

        //배열 지원안함
        //string jsonStr = JsonUtility.ToJson(pArr);

        PersonList personList = new PersonList();
        personList.persons = pArr;      
        string jsonStr1 = JsonUtility.ToJson(personList);
        Debug.Log(jsonStr1);

        StreamWriter streamWriter = new StreamWriter(@"Assets\data.json");
        streamWriter.Write(jsonStr1);
        streamWriter.Close();

        PersonList newPersonList = JsonUtility.FromJson<PersonList>(jsonStr1);
    }
}
