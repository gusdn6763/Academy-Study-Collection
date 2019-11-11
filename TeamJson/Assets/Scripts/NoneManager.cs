using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DataInfo;


public class NoneManager : MonoBehaviour
{
    [SerializeField] public RectTransform contentRectTransform;
    public GameObject cell;

    public GetAndCallInfo getInfo;
    DataList dataList = new DataList();
    Data[] pArr = new Data[100];

    public static int num = 0;
    public int count = 0;

    private void Awake()
    {
        getInfo.callInfo = SaveInfo;

        try
        {
            dataList = CallInfo();
        }
        catch
        {
            Debug.Log("파일오류 or 파일없음 or 폴더없음");
            if (!Directory.Exists(Application.persistentDataPath + "/Data"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Data");

            }
        }
    }

    public DataList CallInfo()
    {
        StreamReader streamReader = new StreamReader(@"Assets\Data" + @"\data.json");

        string str = streamReader.ReadToEnd();

        DataList readData = JsonUtility.FromJson<DataList>(str);
     
        for (int j=0 ;readData.datas[j].cellNumber != 0 ; j++ )
        {
            Instantiate(cell, contentRectTransform);

            contentRectTransform.GetChild(j).GetChild(0).GetComponent<Text>().text = readData.datas[j].Name;
            contentRectTransform.GetChild(j).GetChild(1).GetComponent<Text>().text = readData.datas[j].PhoneNumber;
            contentRectTransform.GetChild(j).GetChild(2).GetComponent<Text>().text = readData.datas[j].Email;

            pArr[j] = readData.datas[j];
            dataList.datas = pArr;

            count++;
        }

        return readData;
    }

    public void SaveInfo(Data data)
    {
        StreamWriter streamWriter = new StreamWriter(@"Assets\Data" + @"\data.json");

        data.cellNumber =count+1;

        pArr[count] = data;

        dataList.datas = pArr;

        string jsonStr = JsonUtility.ToJson(dataList);

        streamWriter.Write(jsonStr);
        streamWriter.Close();

        DataList readData = JsonUtility.FromJson<DataList>(jsonStr);


        Instantiate(cell, contentRectTransform);

        contentRectTransform.GetChild(count).GetChild(0).GetComponent<Text>().text = readData.datas[count].Name;
        contentRectTransform.GetChild(count).GetChild(1).GetComponent<Text>().text = readData.datas[count].PhoneNumber;
        contentRectTransform.GetChild(count).GetChild(2).GetComponent<Text>().text = readData.datas[count].Email;
        count++;
        num++;
    }
}
