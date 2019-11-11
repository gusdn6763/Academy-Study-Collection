using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    private Fire fire;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stad()
    {

            StartCoroutine(fire.Delay());
    }
}
