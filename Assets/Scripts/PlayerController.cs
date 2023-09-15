using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed = 5;

    public bool isMoving;

    public Vector3 targetPos;
    public Vector2 input;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("moveY", -1);
    }

    private void Update()
    {        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input != Vector2.zero)
        {
            if (Math.Abs(input.x) == 1 && Math.Abs(input.y) == 1)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", 0);
            }
            else
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
            }

            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        targetPos = transform.position;
        targetPos.x += input.x;
        targetPos.y += input.y;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        animator.SetBool("isMoving", isMoving);
    }
}
