using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;

    public float moveSpeed = 5;

    private bool isMoving;
    [SerializeField] private bool isCentering = false;

    [SerializeField] private bool cameraCentered = true;

    public Vector3 targetPos;
    public Vector2 input;
    public Vector3 tempPos;

    private void Start()
    {
        tempPos = player.transform.position;
        tempPos.z = -30;

        transform.position = tempPos;
    }

    private void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            targetPos = player.transform.position;
            targetPos.z = -30;

            moveSpeed = 20;

            isCentering = true;
        }

        if (isCentering && (getPlayerPos().x - .1 <= getCameraPos().x && getCameraPos().x <= getPlayerPos().x + .1) && (getPlayerPos().y - .1 <= getCameraPos().y && getCameraPos().y <= getPlayerPos().y + .1))
        {
            isCentering = false;
            cameraCentered = true;

            moveSpeed = 5;
        }

        if (!isCentering)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                cameraCentered = false;

                targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

            }

            if (cameraCentered)
            {
                targetPos = player.transform.position;
                targetPos.z = -30;
            }
        }
        
        targetPos.z = -30;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    public Vector3 getPlayerPos()
    {
        return player.transform.position;
    }

    public Vector3 getCameraPos()
    {
        return transform.position;
    }

    public bool camIsCentering()
    {
        return isCentering;
    }
}
