using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float startPosition;
    [SerializeField] float endPosition;

    void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        if (transform.position.x <= endPosition)
        {
            transform.Translate(-1 * (endPosition - startPosition), 0, 0);

            SendMessage("ChangePosition", SendMessageOptions.DontRequireReceiver);
        }
    }
}
