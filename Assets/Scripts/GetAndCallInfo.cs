using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataInfo;
using System.Text.RegularExpressions;

public class GetAndCallInfo : MonoBehaviour
{
    public InputField name;
    public InputField phoneNumber;
    public InputField email;

    public Image errorImage;
    public Color errorColor;
    private Color resetColor;

    private int count = 0;
    public Action<Data> callInfo;


    private void Awake()
    {
        resetColor = GetComponent<Image>().color;
    }

    public void GetInfoInput()
    {
        Data data = new Data();

        bool checkName = Regex.IsMatch(name.text, @"[가-힣]");
        bool checkphoneNumber = Regex.IsMatch(phoneNumber.text, @"[0-9]");
        bool checkEmail = Regex.IsMatch(email.text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        try
        {
            if(!checkName) name.GetComponent<Image>().color = errorColor;
            else name.GetComponent<Image>().color = resetColor;

            if (!checkphoneNumber) phoneNumber.GetComponent<Image>().color = errorColor;
            else phoneNumber.GetComponent<Image>().color = resetColor;

            if (!checkEmail)  email.GetComponent<Image>().color = errorColor;
            else email.GetComponent<Image>().color = resetColor;

           
            if ( checkName && checkphoneNumber && checkEmail)
            {
                data.Name = name.text;
                data.PhoneNumber = phoneNumber.text;
                data.Email = email.text;
                callInfo(data);
            }
            else
            {
                errorImage.gameObject.SetActive(true);
            }
        }
        catch
        {
            Debug.Log("참조할 캔버스가 없습니다");
        }
    }

}
