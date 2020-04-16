using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ChatCell : MonoBehaviour
{
    Text cachedText;
    public Text CachedText
    {
        get
        {
            if (!cachedText)
            {
                cachedText = GetComponent<Text>();
            }
            return cachedText;
        }
    }
}
