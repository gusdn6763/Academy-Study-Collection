using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraCast : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    private Animator animator;
    private GameObject prevButton;
    private GameObject currButton;
    public GameObject deleate;

    public float dist = 10.0f;

    public float selectedTime = 1.0f;
    private float passdTime = 0.0f;
    private bool isClocked = false;
    private Image progressImage;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }



    void Update()
    {
        ray = new Ray(transform.position,transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * dist, Color.green);

        if(Physics.Raycast(ray,out hit,dist, 1<<8 | 1<<9))
        {
            animator.SetBool("IsLook", true);
            moveDirection.isStopped = true;
            GazeButton();
        }
        else
        {
            animator.SetBool("IsLook", false);
            moveDirection.isStopped = false;
        }
    }

    void ButtonInit()
    {
        passdTime = 0;
        isClocked = false;
        if(progressImage !=null)
        {
            progressImage.fillAmount = 0.0f;
        }

        if(prevButton !=null)
        {
            prevButton.GetComponentsInChildren<Image>()[1].fillAmount = 0.0f;
        }
    }

    void GazeButton()
    {
        //이벤트를 발생시킨 주체에 대한 정보
        PointerEventData date = new PointerEventData(EventSystem.current);

        if(hit.collider.gameObject.layer==9)
        {
            currButton = hit.collider.gameObject;

            progressImage = currButton.GetComponentsInChildren<Image>()[1];

            if(currButton != prevButton)
            {
                ButtonInit();

                ExecuteEvents.Execute(currButton, date, ExecuteEvents.pointerEnterHandler);

                ExecuteEvents.Execute(prevButton, date, ExecuteEvents.pointerExitHandler);

                prevButton = currButton;

            }

            else
            {
                if(isClocked ==true)
                {
                    return;
                }
                passdTime += Time.deltaTime;
                progressImage.fillAmount = passdTime / selectedTime;

                if(passdTime>= selectedTime)
                {
                    ExecuteEvents.Execute(currButton, date, ExecuteEvents.pointerClickHandler);
                    deleate.SetActive(false);
                    isClocked = true;
                }
            }
        }

        else
        {
            Debug.Log("1");
            ReleaseButton();
        }
    }

    void ReleaseButton()
    {
        ButtonInit();

        PointerEventData data = new PointerEventData(EventSystem.current);

        if (prevButton != null)
        {
            ExecuteEvents.Execute(prevButton, data, ExecuteEvents.pointerExitHandler);

            prevButton = null;
        }
    }
    
}
