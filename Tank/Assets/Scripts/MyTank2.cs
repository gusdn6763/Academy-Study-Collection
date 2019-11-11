using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTank2 : MonoBehaviour
{
    protected Vector3 vector;

    protected bool check;

    private Transform trans;

    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) {
        //    RaycastHit hit = new RaycastHit();
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray.origin,ray.direction, out hit)) {
        //        Debug.Log(hit.point);
        //        StopAllCoroutines();
        //        StartCoroutine(moveTo2(hit.point));
        //    }
        //}
    }

    /*
    IEnumerator moveTo1(Vector3 destination)
    {
        yield return StartCoroutine(rotateTank(destination));

        while (Vector3.Distance(tr.position, destination) >= 0.1f)
        {
            tr.position = Vector3.MoveTowards(tr.position, destination, 0.1f);
            yield return null;
        }
    }

    IEnumerator rotateTank(Vector3 destination)
    {
        Vector3 relativePos = destination - tr.position;
        
        float angle = Mathf.Atan2(relativePos.x, relativePos.z) * Mathf.Rad2Deg;

        while (!Mathf.Approximately(tr.rotation.eulerAngles.y, angle))
        {
            tr.rotation = Quaternion.RotateTowards(tr.rotation,
            Quaternion.Euler(0, angle, 0), 1f);

            yield return null;
        }
        Debug.Log("End");
    }

    public IEnumerator moveTo2(Vector3 destination)
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
    */

    private void Awake()
    {
        trans = this.gameObject.GetComponent<Transform>();
    }


    public void GetKey(string key)
    {
        check = true;
        switch (key)
        {
            case "LEFT":
                vector.Set(0, -1, 0);
                break;

            case "RIGHT":
                vector.Set(0, 1, 0);
                break;

            case "FORWARD":
                vector.Set(0, 0, 1);
                break;

            case "SLOW":
                vector.Set(0, 0, -1);
                break;

            case "STOP":
                check = false;
                StopAllCoroutines();
                break;
        }
        StartCoroutine(MoveCoroutine(vector));
    }

    IEnumerator MoveCoroutine(Vector3 vector)
    {
        while (check)
        {
            this.gameObject.transform.Translate(0, 0, vector.z * 0.1f);
            this.gameObject.transform.Rotate(0, vector.y*1f,0);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
