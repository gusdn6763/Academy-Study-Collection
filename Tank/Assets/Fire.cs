using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Shell;

    public Transform launch;

    public GameObject startBoom;

    private bool count= true;

    private void Update()
    {
        if (count == true)
            {
            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(Delay());
            }
        }
    }



    public IEnumerator Delay()
    {
        while (count == true)
        {
            count = false;
            Instantiate(Shell, launch.position, launch.rotation);
            GameObject tel = Instantiate(startBoom, launch.position, launch.rotation);
            yield return new WaitForSeconds(1f);
            Destroy(tel);
        }
        count = true;
    }



}
