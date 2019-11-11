using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWaypoint : MonoBehaviour
{

    private float speed = 3.0f;

    public Transform[] points;

    Transform tr;

    private Vector3 vector;

    private int nextidx=1;

    private void Start()
    {
        tr = GetComponent<Transform>();

        GameObject waypoints = GameObject.Find("WayPoints");

        if (waypoints != null)
        {
            points = waypoints.GetComponentsInChildren<Transform>();
        }
    }

    private void Update()
    {
        Vector3 direction =  points[nextidx].position - tr.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        tr.rotation = Quaternion.Slerp(tr.rotation, rotation, Time.deltaTime * 3.0f);

        tr.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WayPoints"))
        {
            nextidx = (++nextidx >= points.Length) ? 1 : nextidx;
        }
    }

}
