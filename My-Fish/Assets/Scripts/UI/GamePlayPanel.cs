using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayPanel : GamePanel
{
    [SerializeField] Text scoreText;

    private void Start()
    {
        Close();
    }

    public override void Close()
    {
        scoreText.enabled = false;
    }

    public override void Open()
    {
        scoreText.enabled = true;
    }
}
