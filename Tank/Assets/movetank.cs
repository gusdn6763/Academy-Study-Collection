using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetank : MonoBehaviour
{
    private Transform tr;

    public Transform trs;



    private float save = 0;

    private Vector3 vector;


    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    IEnumerator Move1()
    {
        Vector3 setOne = new Vector3(0, 0, 10);

        while (Vector3.Distance(setOne, tr.position) >= 0.1f)
        {
            tr.position = Vector3.Lerp(tr.position, setOne, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }

        StartCoroutine(move2());
    }
    IEnumerator move2()
    {
        float x = 0;
        for (; x <= 90; x++)
        {
            trs.transform.rotation = Quaternion.Euler(0, x, 0);
            yield return new WaitForSeconds(0.05f);
        }
        for (; x > -90; x--)
        {
            trs.transform.rotation = Quaternion.Euler(0, x, 0);
            yield return new WaitForSeconds(0.05f);
        }
        for (; x >= 0; x++)
        {
            trs.transform.rotation = Quaternion.Euler(0, x, 0);
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(move3());

    }
    IEnumerator move3()
    {
        Vector3 setOne = new Vector3(0, 0, 20);

        while (Vector3.Distance(setOne, tr.position) >= 0.1f)
        {
            tr.position = Vector3.Lerp(tr.position, setOne, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Move4()
    {
        int i = 0;
        for (; i < 10; i++)
        {

            tr.rotation = Quaternion.Euler(0, i * 4.5f, 0);
            tr.Translate(1, 0, 1);
            yield return new WaitForSeconds(0.1f);
        }

        for (; i >= 0; i--)
        {

            tr.rotation = Quaternion.Euler(0, i * 4.5f, 0);
            tr.Translate(1, 0, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Move5()
    {
        save = 0;

            for (; ; )
            {
                if (vector.x > 0)
                {
                    tr.rotation = Quaternion.Euler(0, ++save, 0);
                }
                else
                {
                    tr.rotation = Quaternion.Euler(0, --save, 0);
                }

                yield return new WaitForSeconds(0.1f);

                if (Mathf.Atan2(vector.x - tr.position.x, vector.z - tr.position.z) * Mathf.Rad2Deg <= save)
                {
                    break;
                }


            }


            for (; ; )
            {
                tr.position = Vector3.Lerp(tr.position, vector, 0.1f);
                yield return new WaitForSeconds(0.1f);
            }

    }

    IEnumerator moveTo2(Vector3 destination)
    {
        while (Vector3.Distance(tr.position, destination) >= 0.1f)
        {
            Vector3 relativePos = destination - tr.position;
            relativePos.Normalize();

            tr.rotation = Quaternion.RotateTowards(tr.rotation,
            Quaternion.LookRotation(relativePos), 1f);

            tr.Translate(Vector3.forward * Time.deltaTime * 5f);
            yield return null;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                StopAllCoroutines();
                save = 0;
                StartCoroutine(moveTo2(hit.point));
            }
        }


    }



    public void MoveTank(Vector3 position)
    {
        StopAllCoroutines();
        StartCoroutine(moveTo2(position));
    }
}
