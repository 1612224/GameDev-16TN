using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementController : MonoBehaviour
{
    public int Speed;
    public int JumpForce;
    public int JumpPerOnAir;
    public bool StartFacingRight;

    private Rigidbody2D rigidBody;
    public Transform GroundCheck;

    private bool isFacingRight;
    private bool onGround = false;
    private int jumpCount = 0;

    [Header("Events")]
    [Space]

    public UnityEvent OnLanding;
    public UnityEvent OnStartNewJump;

    void Awake()
    {
        isFacingRight = StartFacingRight;
        rigidBody = GetComponent<Rigidbody2D>();

        if (OnLanding == null)
        {
            OnLanding = new UnityEvent();
        }
        if (OnStartNewJump == null)
        {
            OnStartNewJump = new UnityEvent();
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        GetComponent<Transform>().Rotate(Vector3.up, 180.0f);
    }

    public void Move(int move, bool jump)
    {
        HandleLeftRightMovement(move);
        HandleJump(jump);
    }

    private void HandleLeftRightMovement(int move)
    {
        float normalizedMove = move == 0 ? 0 : (move / Mathf.Abs(move));

        Vector3 desiredVelocity = new Vector2(move * Speed, rigidBody.velocity.y);
        rigidBody.velocity = desiredVelocity;

        if (normalizedMove > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (normalizedMove < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void HandleJump(bool jump)
    {
        if (!jump || (jumpCount >= JumpPerOnAir && !onGround))
        {
            return;
        }

        if (jumpCount < JumpPerOnAir)
        {
            jumpCount++;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            OnStartNewJump.Invoke();
        }

        if (onGround)
        {
            onGround = false;
        }

        rigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Vector2 colliderPosition = collider.GetComponent<Transform>().position;

        if (collider.CompareTag("Ground") && colliderPosition.y < GroundCheck.position.y)
        {
            jumpCount = 0;
            onGround = true;
            OnLanding.Invoke();
        }
    }
}
