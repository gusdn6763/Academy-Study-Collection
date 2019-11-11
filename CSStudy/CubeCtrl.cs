using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeCtrl : MonoBehaviour
{
    Color initColor;

    Renderer rend;

    Vector3 vector;

    public GameObject sphere;

    public GameObject rect;

    public GameObject a;

    private int move_random;

    private Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();
        rend = GetComponent<Renderer>();
        StartCoroutine(MpveCub2());
    }


    public void changeColorButton()
    {
        //1
        //Coroutine c = StartCoroutine(Change(1,2));

        //StopCoroutine(c);

        //2
        //StartCoroutine("문자열");
        //StopCoroutine("문자열");

        //3
        //StopAllCoroutines();
        StartCoroutine(Move());

    }

     IEnumerator Move()
    {
        move_random = Random.Range(0, 5);


        if (move_random == 0)
        {
            vector.Set(1f, 0, 0);
        }
        else if (move_random == 1)
        {
            vector.Set(-1f, 0, 0);
        }
        else if (move_random == 2)
        {
            vector.Set(0, 1f, 0);
        }
        else if (move_random == 3)
        {
            vector.Set(0, -1f, 0);
        }
        else if (move_random == 4)
        {
            vector.Set(0, 0, 0);
        }


        this.transform.Translate(vector.x, vector.y, 0);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Move());
        
    }

    IEnumerator MpveCub2()
    {
        Vector3 targetPos1 = new Vector3( 0, 0, 0);
        Vector3 targetPos2 = new Vector3( 0, 0, 5);

        while(Vector3.Distance(targetPos2,tr.position ) !=0 )
        {
            tr.position = Vector3.Lerp(tr.position, targetPos2, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator moveCub3(Vector3 targetPos,float duration)
    {
        Vector3 startPos = tr.position;

        float startTime = Time.deltaTime;

        float myTime = Time.deltaTime - startTime;

        while (myTime<duration)
        {
            float t = myTime / duration;
            tr.position = Vector3.Lerp(startPos, targetPos, t);
            myTime = Time.time - startTime;
            yield return null;

            //yield break;
        }       
    }

    IEnumerator moveCub4()
    {
        Debug.Log("Start moveCube4()");
        yield return StartCoroutine(moveCub5());
        Debug.Log("End moveCub4()");
    }

    IEnumerator moveCub5()
    {
        Debug.Log("moveCube5-1");
        yield return new WaitForSeconds(1);

        Debug.Log("moveCube5-2");
        yield return new WaitForSeconds(1);

        Debug.Log("moveCube5-3");
    }
}

