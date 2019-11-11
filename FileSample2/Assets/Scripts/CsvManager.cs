using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CsvManager : MonoBehaviour
{
    [SerializeField] public TextAsset csvFile;
    [SerializeField] public RectTransform contentRectTransform;
    [SerializeField] GameObject cellPrefab;

    const float cellHeight = 150;

    private void Start()
    {
        if(csvFile != null)
        {
            //TOOD: CSV file parsing
            // List<Dictionary<string,string>> result = CsvParser.LoadData(csvFile.bytes);
            List<Person> result = CsvParser.LoadData(csvFile.bytes);
            contentRectTransform.sizeDelta = new Vector2(0, result.Count * cellHeight);
            for(int i =0;i<result.Count;i++)
            {
                //Dictionary<string,string> values= result[i];
                Person person = result[i];

                Cell cell = Instantiate(cellPrefab, contentRectTransform).GetComponent<Cell>();
                //cell.SetCellData(values);
                cell.SetCellData(person);
            }
        }
    }
}
