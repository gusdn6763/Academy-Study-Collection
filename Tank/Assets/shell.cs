using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    public float speed = 100.0f;

    private Rigidbody rigi;


    void Start()

    {
        rigi = GetComponent<Rigidbody>();

        rigi.AddForce(transform.forward * speed);

    }

    private void Update()
    {
        //Vector3 v = rigi.velocity;
        //Vector3 dir = v.normalized;
        //float angle = Mathf.Atan2(dir.y, dir.z) * Mathf.Rad2Deg;
        //this.gameObject.transform.rotation = Quaternion.Euler(-angle, 0, 0);

        //벨로시티는 방향과 크기값만 가지고 있음

        Debug.Log(rigi.velocity);
        //이 방향으로 계속 움직이기 한다
        this.transform.forward = rigi.velocity;
        Debug.Log(this.transform.forward);
        //rigi.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, Quaternion.Euler(55, 0, 0), 0.05f);
    }



}
