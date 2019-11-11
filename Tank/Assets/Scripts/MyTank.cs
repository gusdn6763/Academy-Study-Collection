using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTank : MonoBehaviour
{
    public Transform turret;
    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(startTank());
    }

    IEnumerator turnTurret(float rotateY, float duration)
    {
        float startTime = Time.time;
        float initTime = Time.time - startTime;
        Quaternion turretRot = turret.localRotation;

        while (initTime <= duration)
        {
            turret.localRotation = Quaternion.Slerp(turretRot,
                Quaternion.Euler(0, rotateY, 0), initTime / duration);
            initTime = Time.time - startTime;
            yield return null;
        }
    }

    IEnumerator move()
    {
        Vector3 targetPos = new Vector3(tr.position.x, 
            tr.position.y,
            tr.position.z + 10);

        while (Vector3.Distance(tr.position, targetPos) >= 0.01f)
        {
            tr.position = Vector3.MoveTowards(tr.position, targetPos, 0.1f);
            yield return null;
        }

        yield return StartCoroutine(turnTurret(-90, 3));
        yield return StartCoroutine(turnTurret(0, 6));
        yield return StartCoroutine(turnTurret(90, 3));
        yield return StartCoroutine(turnTurret(0, 3));
    }

    IEnumerator startTank()
    {
        while (true)
        {
            yield return StartCoroutine(move());
        }
    }
}
