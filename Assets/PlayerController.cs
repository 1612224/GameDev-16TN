using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Jump;

    public MovementController MovementScript;

    private int move = 0;
    private bool startToJump = false;

    void Update()
    {
        HandleInput();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        MovementScript.Move(move, startToJump);
    }

    private void UpdateAnimation()
    {
        GetComponent<Animator>().SetBool("IsMoving", move != 0);
    }

    private void HandleInput()
    {
        if (Input.GetKey(Left))
        {
            move = -1;
        }
        else if (Input.GetKey(Right))
        {
            move = 1;
        }
        else
        {
            move = 0;
        }

        startToJump = Input.GetKeyDown(Jump);
    }

    public void OnLanding()
    {
        GetComponent<Animator>().SetBool("IsJumping", false);
    }

    public void OnStartNewJump()
    {
        GetComponent<Animator>().SetBool("IsJumping", true);
        GetComponent<Animator>().Play("Player_Jump", -1, 0.0f);
    }
}
