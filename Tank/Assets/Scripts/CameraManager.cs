using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float moveDamping = 30f;
    public float rotateDamping = 30f;
    public float distance = 10f;
    public float height = 5f;
    public float targetOffset = 3f;
    private Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        var camPos = target.position - (target.forward * distance) + (target.up * height);

        tr.position = Vector3.Slerp(tr.position, camPos, Time.deltaTime * moveDamping);

        tr.rotation = Quaternion.Slerp(tr.rotation, tr.rotation, Time.deltaTime * rotateDamping);

        tr.LookAt(target.position + (target.up * targetOffset));
    }
}