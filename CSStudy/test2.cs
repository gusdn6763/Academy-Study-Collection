using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    public GameObject sphere;

    private int move_random;

    public float speed;

    IEnumerator move6()
    {

        for (; ; )
        {
            sphere.transform.Rotate(speed, 0, 0);
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator move7()
    {

        for (; ; )
        {
            move_random = Random.Range(0, 5);
            if (move_random == 0)
            {
                sphere.transform.Translate(speed, 0, 0);
            }
            else if (move_random == 1)
            {
                sphere.transform.Translate(-speed, 0, 0);
            }
            else if (move_random == 2)
            {
                sphere.transform.Translate(0, speed, 0);
            }
            else if (move_random == 3)
            {
                sphere.transform.Translate(0, -speed, 0);
            }
            else if (move_random == 4)
            {
                sphere.transform.Translate(0, 0, 0);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator move8()
    {
        for (; ; )
        {
            sphere.transform.localScale = new Vector3(1, Random.Range(0.1f,1f), 1);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Start()
    {
        if(sphere.CompareTag("sphere"))
        {
            StartCoroutine(move7());
        }
       else if(sphere.CompareTag("rect"))
        {
            StartCoroutine(move6());
        }

        else if(sphere.CompareTag("Sil"))
        {
            StartCoroutine(move8());
        }
    }
}
