using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    
    public float speed;

    private void Update()
    {
        transform.Rotate(0, speed, 0);
    }
}
