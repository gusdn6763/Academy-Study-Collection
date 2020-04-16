using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            float alpha = GetComponent<Image>().color.a;
            alpha -= 0.03f;
            GetComponent<Image>().color = new Color(1, 1, 1, alpha);

            if (alpha < 0.01f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    //private void OnDisable()
    //{
    //    GetComponent<Image>().color = new Color(1, 1, 1, 1);
    //}

    public void StartFlash()
    {
        gameObject.SetActive(true);
    }
}
