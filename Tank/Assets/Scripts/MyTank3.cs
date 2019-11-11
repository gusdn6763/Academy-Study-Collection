using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MyTank3 : MonoBehaviour
{
    public Transform turret;

    // Start is called before the first frame update
    void Start()
    {
        Sequence mySeq = DOTween.Sequence();
        mySeq.Append(transform.DOMoveZ(10, 3));
        mySeq.Append(turret.DOLocalRotate(new Vector3(0, 90, 0), 1));
        mySeq.Append(turret.DOLocalRotate(new Vector3(0, -90, 0), 1));
        mySeq.Append(turret.DOLocalRotate(new Vector3(0, 0, 0), 1));
        mySeq.Append(transform.DOMoveZ(-10, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
