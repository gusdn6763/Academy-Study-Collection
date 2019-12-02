using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Around : MonoBehaviour
{
    public GameObject Planet; 

    public float speed;  

    private void Update()
    {
        transform.RotateAround(Planet.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}