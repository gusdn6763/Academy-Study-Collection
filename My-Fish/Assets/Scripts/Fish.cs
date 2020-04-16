using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] float jumpVelocity;
    [SerializeField] float maxHeight;
    [SerializeField] GameObject sprite;
    [SerializeField] FlashImage flashImage;

    Rigidbody2D rb;
    bool isDead;
    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            if (!isDead && rb.isKinematic == false)
            {
                rb.velocity = new Vector2(0.0f, jumpVelocity);
            }
        }

        // 물고기 회전
        float angle;
        if (isDead)
        {
            angle = -90f;
        }
        else
        {
            angle = Mathf.Atan2(rb.velocity.y, 10) * Mathf.Rad2Deg;
        }

        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Camera.main.SendMessage("Shake");
        flashImage.StartFlash();

        isDead = true;
    }

    public void SetKinematic(bool value)
    {
        rb.isKinematic = value;
    }
}
