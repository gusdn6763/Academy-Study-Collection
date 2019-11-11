using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveShell : MonoBehaviour
{
    public GameObject sparkEffect;

    private void OnCollisionEnter(Collision col)
    {

        if (col.collider.CompareTag("SHELL"))
        {
            StartCoroutine(forDestory(col));
            Destroy(col.gameObject);
        }
    }

    IEnumerator forDestory(Collision col)
    {
        GameObject tel = Instantiate(sparkEffect, col.gameObject.transform.position, col.gameObject.transform.rotation);
        yield return new WaitForSeconds(1f);
        Destroy(tel);
    }
}
