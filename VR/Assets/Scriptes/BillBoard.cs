using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    Transform camTr;
    Transform tr;

    private void Start()
    {
        camTr = Camera.main.GetComponent<Transform>();
        tr = GetComponent<Transform>();
    }
    private void Update()
    {
        tr.LookAt(camTr.position);
    }
}
