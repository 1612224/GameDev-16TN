using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Speed;
    public KeyCode Left;
    public KeyCode Right;

    private Vector2 currentPosition;
    private bool wasFacingRight;
    private bool isFacingRight;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = GetComponent<Transform>().position;
        wasFacingRight = true;
        isFacingRight = true;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        ControlAnimation();
    }

    private void ControlAnimation()
    {
        GetComponent<Animator>().SetBool("IsMoving", isMoving);
        if (isFacingRight != wasFacingRight)
        {
            GetComponent<Transform>().Rotate(Vector3.up, 180.0f);
            wasFacingRight = isFacingRight;
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(Left))
        {
            isFacingRight = false;
        }
        else if (Input.GetKeyDown(Right))
        {
            isFacingRight = true;
        }

        isMoving = Input.GetKey(Left) || Input.GetKey(Right);
    }

    private void FixedUpdate()
    {
        currentPosition = CalculateNewPosition();
        GetComponent<Transform>().position = currentPosition;
    }

    private Vector2 CalculateNewPosition()
    {
        if (!isMoving)
        {
            return currentPosition;
        }

        Vector2 offset = Vector2.right * Speed * Time.fixedDeltaTime;
        if (isFacingRight)
        {
            return currentPosition + offset;
        }
        return currentPosition - offset;
    }
}
