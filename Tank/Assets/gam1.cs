using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gam1 : MonoBehaviour
{
    public Text positionText;

    public movetank move;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPos = Input.GetTouch(0).deltaPosition;
            positionText.text = touchPos.ToString();

            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(touchPos);

            if(Physics.Raycast(ray.origin,ray.direction,out hit))
            {
                move.MoveTank(hit.point);
            }
        }
    }
    // Update is called once per frame


}