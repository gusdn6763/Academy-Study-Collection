using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : GamePanel
{
    [SerializeField] Animator popupAnimator;
    public override void Close()
    {
        popupAnimator.SetTrigger("hide");
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public override void Open()
    {
        popupAnimator.SetTrigger("show");
    }
}
