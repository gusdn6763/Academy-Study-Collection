using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class SignUpPanelManager : PanelManager
{
    [SerializeField] InputField usernameInputFiled;
    [SerializeField] InputField firstPasswordInputField;
    [SerializeField] InputField secondPasswordInputField;
    [SerializeField] InputField nameInputField;

    [SerializeField] Button SignUpButton;
    [SerializeField] SignInPanelManager signInPanelManager;

    byte validationFlag = 0;

    public override void Show()
    {
        base.Show();
        SignUpButton.interactable = false;
    }

    void SetInputFieldInteractable(bool value)
    {
        usernameInputFiled.interactable = value;
        firstPasswordInputField.interactable = value;
        secondPasswordInputField.interactable = value;
        nameInputField.interactable = value;
    }

    public void OnClickOK()
    {
        string username = usernameInputFiled.text;
        string password = firstPasswordInputField.text;
        string name = nameInputField.text;

        SetInputFieldInteractable(false);

        HTTPNetworkManager.Instance.SignUp(username, password, name, (response) =>
        {
            SetInputFieldInteractable(true);

            if (response.Headers.ContainsKey("Set-Cookie"))
            {
                string cookie = response.Headers["Set-Cookie"];

                int firstIndex = cookie.IndexOf('=') + 1;
                int lastIndex = cookie.IndexOf(';');

                string cookieValue = cookie.Substring(firstIndex, lastIndex - firstIndex);

                PlayerPrefs.SetString("sid", cookieValue);
            }

            // 유저의 점수 표시
            HTTPResponseInfo info = response.GetDataFromMessage<HTTPResponseInfo>();
            MainManager.Instance.SetInfo(info.name, info.score);

            // 회원가입창 닫기
            Hide();
        }, () =>
        {
            SetInputFieldInteractable(true);
        });
    }

    public void OnClickCancel()
    {
        signInPanelManager.Show();
        Hide();
    }

    void OnValueChangedFinalCheck()
    {
        string firstPassword = firstPasswordInputField.text;
        string secondPassword = secondPasswordInputField.text;
        if (validationFlag == 15 && (firstPassword == secondPassword))
        {
            SignUpButton.interactable = true;
        }
        else
        {
            SignUpButton.interactable = false;
        }
    }

    public void OnValueChangedUsername(InputField inputField)
    {
        string pattern = @"^[a-zA-Z0-9]{4,12}$";

        if (Regex.IsMatch(inputField.text, pattern))
        {
            validationFlag = (byte)(validationFlag | 1);
        }
        else
        {
            validationFlag = (byte)(validationFlag & ~1);
        }
        Debug.Log("Flag = " + validationFlag);
        OnValueChangedFinalCheck();
    }

    public void OnValueChangedFirstPassword(InputField inputField)
    {
        string pattern = @"^[a-zA-Z0-9]{4,12}$";

        if (Regex.IsMatch(inputField.text, pattern))
        {
            validationFlag = (byte)(validationFlag | 1 << 1);
        }
        else
        {
            validationFlag = (byte)(validationFlag & ~(1 << 1));
        }
        Debug.Log("Flag = " + validationFlag);
        OnValueChangedFinalCheck();
    }

    public void OnValueChangedSecondPassword(InputField inputField)
    {
        string pattern = @"^[a-zA-Z0-9]{4,12}$";

        if (Regex.IsMatch(inputField.text, pattern))
        {
            validationFlag = (byte)(validationFlag | 1 << 2);
        }
        else
        {
            validationFlag = (byte)(validationFlag & ~(1 << 2));
        }
        Debug.Log("Flag = " + validationFlag);
        OnValueChangedFinalCheck();
    }

    public void OnValueChangedName(InputField inputField)
    {
        string pattern = @"^[a-zA-Z0-9]{4,12}$";

        if (Regex.IsMatch(inputField.text, pattern))
        {
            validationFlag = (byte)(validationFlag | 1 << 3);
        }
        else
        {
            validationFlag = (byte)(validationFlag & ~(1 << 3));
        }
        Debug.Log("Flag = " + validationFlag);
        OnValueChangedFinalCheck();
    }
}
