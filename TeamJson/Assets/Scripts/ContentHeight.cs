using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentHeight : MonoBehaviour
{
    private void Awake()
    {
        gameObject.transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0, this.gameObject.GetComponent<RectTransform>().sizeDelta.y);
    }
}
