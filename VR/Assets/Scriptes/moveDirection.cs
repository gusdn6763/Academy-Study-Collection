using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDirection : MonoBehaviour
{
    Transform tr;

    CharacterController cc;

    Transform camTr;

    public float speed = 3.0f;

    internal bool wait;

    public static bool isStopped = false;

    private void Start()
    {
        tr = GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
        camTr = Camera.main.GetComponent<Transform>();
    }

    private void Update()
    {
        if (isStopped)
        {
            return;
        }
            Vector3 heading = camTr.forward;
            cc.SimpleMove(heading * speed);
    }
}
