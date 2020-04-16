using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] float minPosistionY;
    [SerializeField] float maxPosistionY;

    void Start()
    {
        ChangePosition();
    }

    public void ChangePosition()
    {
        float positionY = Random.Range(minPosistionY, maxPosistionY);
        transform.localPosition = 
            new Vector3(transform.localPosition.x, positionY, transform.localPosition.z);
    }
}
