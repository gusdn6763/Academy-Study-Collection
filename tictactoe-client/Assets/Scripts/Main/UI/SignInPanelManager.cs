using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class SignInPanelManager : PanelManager
{
    [SerializeField] SignUpPanelManager signUpPanelManager;
    [SerializeField] InputField usernameInputField;
    [SerializeField] InputField passwordInputField;

    [SerializeField] Button signInButton;
    [SerializeField] Button signUpButton;

    byte validationFlag = 0;

    public override void Show()
    {
        base.Show();
        signInButton.interactable = false;
    }

    public void OnClickSignUp()
    {
        signUpPanelManager.Show();
        Hide();
    }

    public void OnClickSignIn()
    {
        signInButton.interactable = false;
        signUpButton.interactable = false;
        // 로그인
        HTTPNetworkManager.Instance.SignIn(usernameInputField.text, passwordInputField.text, (response) =>
        {
            // 세션ID 저장
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

            // 로그인창 닫기
            Hide();
        }, () =>
        {
            signInButton.interactable = true;
            signUpButton.interactable = true;
        });        
    }

    void OnValueChangedFinalCheck()
    {
        if (validationFlag == 3)
        {
            signInButton.interactable = true;
        }
        else
        {
            signInButton.interactable = false;
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

    public void OnValueChangedPassword(InputField inputField)
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
}
