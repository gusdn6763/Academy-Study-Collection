using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField] SignInPanelManager signInPanelManager;
    [SerializeField] MessagePanelManager messagePanelManager;
    [SerializeField] Button addScoreButton;
    [SerializeField] Button logoutButton;
    [SerializeField] Button startGameButton;

    [SerializeField] Text nameText;
    [SerializeField] Text scoreText;

    static MainManager instance;
    public static MainManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = GameObject.FindObjectOfType(typeof(MainManager)) as MainManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "GameManager";
                    instance = container.AddComponent(typeof(MainManager)) as MainManager;
                }
            }
            return instance;
        }
    }
    void Start()
    {
        EnableLoginButton(false);
        GetInfo();
    }

    void EnableLoginButton(bool value)
    {
        startGameButton.interactable = value;
        logoutButton.interactable = value;
    }
    public void SetInfo(string name, int score)
    {
        nameText.text = name;
        scoreText.text = score.ToString();

        EnableLoginButton(true);
    }

    void GetInfo()
    {
        HTTPNetworkManager.Instance.Info((response) =>
        {
            string resultStr = response.Message;
            HTTPResponseInfo info = response.GetDataFromMessage<HTTPResponseInfo>();

            SetInfo(info.name, info.score);
        }, () =>
        {
            nameText.text = "";
            scoreText.text = "";
        });
    }

    #region 버튼설정
    public void OnClickStartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickLogout()
    {
        logoutButton.interactable = false;
        HTTPNetworkManager.Instance.Logout((response) =>
        {
            PlayerPrefs.SetString("sid", "");

            addScoreButton.interactable = false;
            nameText.text = "";
            scoreText.text = "";

        }, () =>
        {
            logoutButton.interactable = false;
        });
    }
    #endregion

    public void AddScore()
    {
        addScoreButton.interactable = false;
        HTTPNetworkManager.Instance.AddScore(5, (response) =>
        {
            addScoreButton.interactable = true;

            HTTPResponseInfo info = response.GetDataFromMessage<HTTPResponseInfo>();
            SetInfo(info.name, info.score);
        }, () =>
        {
            addScoreButton.interactable = true;
        });
    }

    public void ShowSignInPanel()
    {
        signInPanelManager.Show();
    }

    public void ShowMessagePanel(string message, Action callback = null)
    {
        messagePanelManager.Show(message, callback);
    }
}
