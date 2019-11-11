using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBullet : MonoBehaviour
{
    public GameObject bullet;

    private bool waitCheck;

    private void Awake()
    {
        waitCheck = true;
    }

    public void Shot()
    {
        if (waitCheck == true)
        {
            waitCheck = false;
            StartCoroutine(WaitTime());
        }
    }

    IEnumerator WaitTime()
    {
        Instantiate(bullet, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(1f);
        waitCheck = true;
    }
}
