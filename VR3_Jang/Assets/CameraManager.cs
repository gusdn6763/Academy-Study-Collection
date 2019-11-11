using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    private CharacterController character;
    private Transform trans;
    private Transform cameraTrans;
    private Animator animator;
    private Image image;

    Vector3 vector;
    Ray ray;
    RaycastHit hit;
    public LayerMask layerMask;


    public float dist;
    public float speed;
    private bool stop = false;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        trans = GetComponent<Transform>();
        cameraTrans = Camera.main.GetComponent<Transform>();
        animator = GetComponentInChildren<Animator>();

        image = FindObjectOfType<CubeMove>().GetComponentInChildren<Image>();
    }

    private void Update()
    {
        if (!stop)
        {
            character.Move(cameraTrans.forward * Time.deltaTime);
        }

        CheckCollision();
    }

     void CheckCollision()
    {
        ray = new Ray(cameraTrans.position, cameraTrans.forward);

        if (Physics.Raycast(ray, out hit, dist, layerMask))
        {
            animator.SetBool("Check", true);
            stop = true;

            image.fillAmount += Time.deltaTime;

            if(image.fillAmount >=1)
            {
                Destroy(image);
            }
        }
        else
        {
            animator.SetBool("Check", false);
            stop = false;
        }


    }
}
