using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

[System.Serializable]
public class Contact
{
    public string Name;

    public int Age;

    public string Email;

    public string Password;
}

[SerializeField]
public class AccountManager : MonoBehaviour
{
    [SerializeField]
    private Contact contact;

    [SerializeField] InputField userName;
    [SerializeField] InputField userAge;
    [SerializeField] GYInputField userEmail;
    [SerializeField] InputField userPassword;

    public GameObject trueIcon;
    public GameObject falseIcon;


    private void Start()
    {
        userAge.onValidateInput+= GYValidate;
    }

    char GYValidate(string str, int val, char chr)
    {
        string allText = str + chr;

        Regex regex = new Regex(@"^\d{1,3}$");

        if (regex.IsMatch(allText))

            if (allText.Length > 10)
            {
                return chr;
            }
        return '\n';
    }
    public void Save()
    {
        if(!isCorrectEmail(userEmail.text))
        {
            userEmail.Incorrect();
            return;
        }

        bool checkId = Regex.IsMatch(userName.text, @"[^a-zA-Z0-9가-힣]");
        bool checkAge = Regex.IsMatch(userAge.text, @"[0-9]");
        bool checkEmail = Regex.IsMatch(userEmail.text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        if (!checkId) contact.Name = userName.text;
        else
        {
            falseIcon.SetActive(true);
            return;
        }

        if (checkAge && checkAge.ToString().Length >0) contact.Age = int.Parse(userAge.text);
        else
        {
            falseIcon.SetActive(true);
            return;
        }

        //if (isContain = userEmail.text.Contains("@") && userEmail.text.Contains(".")) contact.Email = userEmail.text;
        if (checkEmail) contact.Email = userEmail.text;
        else
        {
            falseIcon.SetActive(true);
            return;
        }

        if (userPassword.text.Length > 6 && userPassword.text.Length < 15) contact.Password = userPassword.text;
        else
        {
            falseIcon.SetActive(true);
            return;
        }

        Debug.Log("1");

        trueIcon.SetActive(true);

        BinaryFormatter bf = new BinaryFormatter();

        FileStream fs = File.Create(GetFilePath("data.tat"));

        bf.Serialize(fs, contact);

        fs.Close();
    }

    string GetFilePath(string fileName)
    {
        string path =string.Format("{0}/{1}", Application.persistentDataPath, fileName);
        return path;

        
    }

    public Contact Load()
    {
        return contact;
    }


    bool isCorrectEmail(string email)
    {
        return false;
    }

}

