using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTest : MonoBehaviour
{
 
    void Start()
    {
        GetComponent<Renderer>().material.SetFloat("_TexValue",0);
    }

    // Update is called once per frame
    void Update()
    {
        float val = Mathf.PingPong(Time.time,1);
       GetComponent<Renderer>().material.SetFloat("_TexValue",val);
    }
}
