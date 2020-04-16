using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class HTTPNetworkManager : MonoBehaviour
{
    static HTTPNetworkManager instance;
    public static HTTPNetworkManager Instance
    {
        get
        {
            if(!instance)
            {
                instance = GameObject.FindObjectOfType(typeof(HTTPNetworkManager)) as HTTPNetworkManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "HTTPNetworkManager";
                    instance = container.AddComponent(typeof(HTTPNetworkManager)) as HTTPNetworkManager;
                }
            }
            return instance;
        }
    }

    public void SignUp(string username, string password, string name, Action<HTTPResponse> success, Action fail)
    {
        HTTPRequestSignUp signUpData = new HTTPRequestSignUp(username, password, name);
        var postData = signUpData.GetJSON();

        StartCoroutine(SendPostRequest(postData, HTTPNetworkConstant.signUpRequestURL, success, fail));
    }

    public void SignIn(string username, string password, Action<HTTPResponse> success, Action fail)
    {
        HTTPRequestSignIn signInData = new HTTPRequestSignIn(username, password);
        var postData = signInData.GetJSON();

        StartCoroutine(SendPostRequest(postData, HTTPNetworkConstant.signInRequestURL, success, fail));
    }

    public void AddMessage(string message, Action<HTTPResponse> success, Action fail)
    {
        HTTPRequestAddMessage addMessageData = new HTTPRequestAddMessage(message);
        var postData = addMessageData.GetJSON();

        StartCoroutine(SendPostRequest(postData, HTTPNetworkConstant.addMessageRequestURL, success, fail));
    }

    public void AddScore(int score, Action<HTTPResponse> success, Action fail)
    {
        HTTPRequestAddScore addScoreData = new HTTPRequestAddScore(score);
        var postData = addScoreData.GetJSON();

        StartCoroutine(SendPostRequest(postData, HTTPNetworkConstant.addScoreRequestURL, success, fail));
    }

    public void Info(Action<HTTPResponse> success, Action fail)
    {
        StartCoroutine(SendGetRequest(HTTPNetworkConstant.infoRequestURL, success, fail));
    }

    public void LoadChat(Action<HTTPResponse> success, Action fail, int lastSeq)
    {
        string requestURL = HTTPNetworkConstant.chatRequestURL + lastSeq.ToString();
        StartCoroutine(SendGetRequest(requestURL, success, fail));
    }

    public void Logout(Action<HTTPResponse> success, Action fail)
    {
        StartCoroutine(SendGetRequest(HTTPNetworkConstant.logoutURL, success, fail));
    }

    IEnumerator SendGetRequest(string requestURL, Action<HTTPResponse> success, Action fail)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(HTTPNetworkConstant.serverURL + requestURL))
        {
            yield return www.SendWebRequest();

            long code = www.responseCode;
            HTTPResponseMessage message = JsonUtility.FromJson<HTTPResponseMessage>(www.downloadHandler.text);

            if (www.isNetworkError)
            {
                NetworkErrorHandler();
                fail();
            }
            else if (www.isHttpError)
            {
                HTTPErrorHandler(code, message.message);
                fail();
            }
            else
            {
                Dictionary<string, string> headers = www.GetResponseHeaders();
                HTTPResponse response = new HTTPResponse(code, message.message, headers);
                success(response);
            }
        }
    }

    IEnumerator SendPostRequest(string data, string requestURL, Action<HTTPResponse> success, Action fail)
    {
        using (UnityWebRequest www = UnityWebRequest.Put(HTTPNetworkConstant.serverURL + requestURL, data))
        {
            www.method = "Post";
            www.SetRequestHeader("Content-Type", "application/json");

            string sid = PlayerPrefs.GetString("sid", "");
            if (sid != "")
            {
                www.SetRequestHeader("Set-Cookie", sid);
            }

            yield return www.SendWebRequest();

            long code = www.responseCode;
            HTTPResponseMessage message = JsonUtility.FromJson<HTTPResponseMessage>(www.downloadHandler.text);

            if (www.isNetworkError)
            {
                NetworkErrorHandler();
                fail();
            }
            else if (www.isHttpError)
            {
                HTTPErrorHandler(code, message.message);
                fail();
            }
            else
            {
                Dictionary<string, string> headers = www.GetResponseHeaders();
                HTTPResponse response = new HTTPResponse(code, message.message, headers);
                success(response);
            }
        }
    }

    void NetworkErrorHandler()
    {
        MainManager.Instance.ShowMessagePanel("서버에 접속할 수 없습니다.", () =>
        {
            Debug.Log("Application Quit");
        });
    }

    void HTTPErrorHandler(long code, string message)
    {
        switch (code)
        {
            case 400:
                MainManager.Instance.ShowMessagePanel(message);
                break;

            case 401:
                MainManager.Instance.ShowMessagePanel(message,() =>
                {
                    PlayerPrefs.SetString("sid", "");
                    MainManager.Instance.ShowSignInPanel();
                });
                break;

            case 404:
                MainManager.Instance.ShowMessagePanel(message);
                break;

            case 503:
                MainManager.Instance.ShowMessagePanel(message);
                break;
        }
    }
}
