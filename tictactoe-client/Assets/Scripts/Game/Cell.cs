using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MarkerType { None, Circle, Cross }

public class Cell : MonoBehaviour
{
    [SerializeField] SpriteRenderer markerSpriteRenderer;

    [SerializeField] Sprite circleMarkerSprite;
    [SerializeField] Sprite crossMarkerSprite;

    BoxCollider2D cachedBoxCollider2D;
    public BoxCollider2D CachedBoxCollider2D
    {
        get
        {
            if (!cachedBoxCollider2D)
                cachedBoxCollider2D = GetComponent<BoxCollider2D>();
            return cachedBoxCollider2D;
        }
    }

    private SpriteRenderer cachedSpriteRenderer;
    public SpriteRenderer CachedSpriteRenderer
    {
        get
        {
            if (!cachedSpriteRenderer)
                cachedSpriteRenderer = GetComponent<SpriteRenderer>();
            return cachedSpriteRenderer;
        }
    }

    private MarkerType markerType;
    public MarkerType MarkerType
    {
        get
        {
            return markerType;
        }
        set
        {
            if (markerType != MarkerType.None) return;

            switch (value)
            {
                case MarkerType.None:
                    markerSpriteRenderer.sprite = null;
                    break;
                case MarkerType.Circle:
                    markerSpriteRenderer.sprite = circleMarkerSprite;
                    break;
                case MarkerType.Cross:
                    markerSpriteRenderer.sprite = crossMarkerSprite;
                    break;
            }
            markerType = value;
        }
    }

    public void SetActiveTouch(bool active)
    {
        CachedBoxCollider2D.enabled = active;
        CachedSpriteRenderer.color = (active == true) ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0.5f);
    }
}
