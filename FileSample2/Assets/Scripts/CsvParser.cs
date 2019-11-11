using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CsvParser
{
    public static bool test = true;
    //static public List<Dictionary<string,string>> LoadData(byte[] data)
    static public List<Person> LoadData(byte[] data)
    {
        // TODO :
        //매개변수로  csv 파일에 대한 정보를 전달하면,
        //csv 파일을 읽어서 xx형태로 변환

        //List<Dictionary<string, string>> resultList = new List<Dictionary<string, string>>();
        List<Person> resultList = new List<Person>();

        Stream stream = new MemoryStream(data);
        StreamReader reader = new StreamReader(stream);

        string lineValue;
        string[] values;
        

        while ((lineValue = reader.ReadLine()) != null)
        {
            values = lineValue.Split(',');

         //   try
         //   {
         //       Person person = new Person(values[0], int.Parse(values[1]), values[2], values[3]);
         //       resultList.Add(person);
         //   }
         //   catch(FormatException e)
         //   {
         //       Debug.Log(e.Message);
         //   }

            //Dictionary<string, string> valueDict = new Dictionary<string, string>();

            // valueDict.Add("NAME", values[0]);
            // valueDict.Add("AGE", values[1]);
            // valueDict.Add("PHONENUMBER", values[2]);
            // valueDict.Add("EMAIL", values[3]);
            // resultList.Add(valueDict);         
        }
        //return resultList;
        return resultList;
    }

    void add()
    {

    }
}
