using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new CameraController camera;
    private Animator animator;

    public float moveSpeed = 5;

    public Vector3 targetPos;
    public Vector2 input;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (camera.camIsCentering() == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPos.y += 0.375f;

                setAnimationAngle();
            }
            targetPos.z = -1;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    private void setAnimationAngle()
    {
        if(transform.position.x > targetPos.x)
        {
            double xDirection = -1;
        }
        else
        {
            double xDirection = 1;
        }

        if (transform.position.y > targetPos.y)
        {
            double yDirection = -1;
        }
        else
        {
            double yDirection = 1;
        }

        double ChangeInX = Math.Abs(targetPos.x - transform.position.x);
        double ChangeInY = Math.Abs(targetPos.y - transform.position.y);


    }
}
