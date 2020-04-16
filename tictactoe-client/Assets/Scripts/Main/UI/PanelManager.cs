using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    RectTransform panelRectTransform;
    public RectTransform PanelRectTransform
    {
        get
        {
            if (!panelRectTransform)
            {
                panelRectTransform = GetComponent<RectTransform>();
            }
            return panelRectTransform;
        }
    }

    public virtual void Show()
    {
        PanelRectTransform.anchoredPosition = Vector2.zero;
    }

    public void Hide()
    {
        PanelRectTransform.anchoredPosition = new Vector2(1200, 0);
    }
}
