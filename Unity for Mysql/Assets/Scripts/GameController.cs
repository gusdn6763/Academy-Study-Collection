using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetScore());
    }

    IEnumerator GetScore()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:3000");
        yield return www.SendWebRequest();
        if(www.isNetworkError||www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
}
