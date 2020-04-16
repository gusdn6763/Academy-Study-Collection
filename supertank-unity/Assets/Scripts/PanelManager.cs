using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {
    RectTransform cachedRectTransform;
    public RectTransform CachedRectTransform {
        get {
            if (!cachedRectTransform) {
                cachedRectTransform = GetComponent<RectTransform>();
            }
            return cachedRectTransform;
        }
    }
    public void Show() {
        CachedRectTransform.anchoredPosition = Vector2.zero;
    }
    public void Hide() {
        CachedRectTransform.anchoredPosition = new Vector2(1200, 0);
    }
}