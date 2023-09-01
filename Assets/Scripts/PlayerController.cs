using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new CameraController camera;

    public float moveSpeed = 5;

    private bool isMoving;

    public Vector3 targetPos;

    public Vector2 input;

    private void Update()
    {
        if (camera.camIsCentering() == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPos.z = transform.position.z;
                targetPos.y += 0.375f;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }
}
