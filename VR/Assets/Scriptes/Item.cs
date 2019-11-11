using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public moveDirection move;

    public void onLook(bool isLook)
    {
        moveDirection.isStopped = isLook;
    }

    public void OnClickButton()
    {
        
    }

}
