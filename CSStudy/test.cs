using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void Start()
    {
        IEnumerator myEnum = TestFunc();

       Debug.Log(myEnum.MoveNext());
        Debug.Log(myEnum.Current);
    }

    IEnumerator TestFunc()
    {
        yield return 3;
        yield return 5;
    }
}
