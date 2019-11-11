using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem effect;

    // 총알의 파괴력
    public float damage = 20.0f;
    // 총알 발사 속도
    public float speed = 1000.0f;

    // 컴포넌트를 저장할 변수
    private Transform tr;
    private Rigidbody rb;

    private void Awake()
    {
        // 컴포넌트 할당
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * speed);
    }


    // Update is called once per frame
    void Update()
    {
        transform.forward = rb.velocity;
    }


}
