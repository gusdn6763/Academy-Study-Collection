using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class JSONManager : MonoBehaviour
{
    private void Start()
    {
        Score s1 = new Score();
        s1.attackScore = 10;
        s1.damageScore = 20;
        s1.stageScore = 30;

        Person p1 = new Person("홍길동", 21, "010-0000-0000", "gusdddd",s1);


 
        string p1Json = JsonUtility.ToJson(p1);

        Debug.Log(p1Json);
    }

    void SaveToFile(string jsonStr)
    {
        if (jsonStr.Length <= 0) return;

        FileStream fs = new FileStream(GetPath(Constant.kFILE_NAME),FileMode.Create);

        byte[] data = Encoding.UTF8.GetBytes(jsonStr);
        fs.Write(data,0,data.Length);
        fs.Close();
    }

    string GetPath(string fileName)
    {
        string filePath = string.Format("{0}/{1}", Application.persistentDataPath, fileName);
        return filePath;
    }
}
