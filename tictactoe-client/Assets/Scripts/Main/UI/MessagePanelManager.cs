using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MessagePanelManager : PanelManager
{
    [SerializeField] Text messageText;
    Action callback;

    public void Show(string message, Action callback)
    {
        messageText.text = message;
        base.Show();
        this.callback = callback;
    }

    public void OnClickOk()
    {
        Hide();
        callback?.Invoke();
    }
}
