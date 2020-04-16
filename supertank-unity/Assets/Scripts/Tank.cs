using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private Vector3 targetPosition;
    public Vector3 TargetPosition
    {
        set
        {
            this.targetPosition = value;
        }

        get
        {
            return this.targetPosition;
        }
    }

    private float speed;
    private float rotSpeed;

    private void Start() 
    {
        speed = 10.0f;
        rotSpeed = 2.0f;

        TargetPosition = transform.position;
    }

    private void Update() 
    {
        if (Vector3.Distance(transform.position, TargetPosition) < 3.0f)
        {
            return;
        }

        Vector3 dirRot = TargetPosition - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(dirRot);

        transform.rotation = Quaternion.Slerp(transform.rotation, 
                                                targetRot, rotSpeed * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
