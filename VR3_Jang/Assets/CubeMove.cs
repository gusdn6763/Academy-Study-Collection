using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private Transform cameraTrans;

    private void Awake()
    {
        cameraTrans = Camera.main.GetComponent<Transform>();
    }
    private void Update()
    {
        this.transform.LookAt(cameraTrans);
    }
}
