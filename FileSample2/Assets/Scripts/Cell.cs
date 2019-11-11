using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Text name;
    public Text age;
    public Text phoneNumber;
    public Text email;

    //public void SetCellData(Dictionary<string,string> cellData)
    public void SetCellData(Person cellData)
    {
        //this.name.text = cellData["NAME"];
        //this.age.text = cellData["AGE"];
        //this.phoneNumber.text = cellData["PHONENUMBER"];
        //this.email.text = cellData["EMAIL"];
        this.name.text = cellData.Name;
        this.age.text = cellData.Age.ToString();
        this.phoneNumber.text = cellData.PhoneNumber;
        this.email.text = cellData.Email;
    }
}
