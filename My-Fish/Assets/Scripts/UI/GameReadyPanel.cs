using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReadyPanel : GamePanel
{
    [SerializeField] Animator logoAnimator;
    [SerializeField] Animator touchAnimator;
    public override void Close()
    {
        logoAnimator.SetTrigger("hide");
        touchAnimator.SetTrigger("hide");
    }

    public override void Open()
    {
        logoAnimator.SetTrigger("show");
        touchAnimator.SetTrigger("show");
    }
}
