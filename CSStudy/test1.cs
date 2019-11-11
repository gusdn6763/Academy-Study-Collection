using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    public GameObject rect;

    public float speed;

    private void Start()
    {
        StartCoroutine(move6());
    }

    IEnumerator move6()
    {
        
        for (; ; )
        {
            rect.transform.Rotate(speed,0, 0);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
