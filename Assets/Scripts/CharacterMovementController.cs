using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public enum MovementStates
    {
        Idle,
        Running,
        Jumping,
        Attacking
    }

    public enum FacingDirection
    {
        Right,
        Left
    }

    [Header("Movememt values")]
    public float movementSpeed;
    public float jumpJorce;

    [Header("Raycast leght and layermask")]
    public float isGroundedRayLength;
    public LayerMask platformLayerMask;

    [Header("Movememt States")]
    public MovementStates movementStates;
    public FacingDirection facingDirection;

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private CharacterAnimationController animController;

    private void Awake()
    {
        rigidBody2D = GetComponent < Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animController = GetComponent<CharacterAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleJump();
    }



    private void FixedUpdate()
    {
        HandleMovement();
        PlayAnmationsBasedOnState();
        SetCharacterDirection();
    }

    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {

            rigidBody2D.velocity = Vector2.up * jumpJorce;
        }
    }
    private void HandleMovement()
    {
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody2D.velocity = new Vector2(-movementSpeed, rigidBody2D.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rigidBody2D.velocity = new Vector2(+movementSpeed, rigidBody2D.velocity.y);
            }
            else // No Keys Pressed
            {
                rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
                rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }


    public bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(spriteRenderer.bounds.center,
            spriteRenderer.bounds.size, 0f, Vector2.down,
            isGroundedRayLength, platformLayerMask);

        return raycastHit2D.collider != null;
    }

    private void SetCharacterDirection()
    {
        switch (facingDirection)
        {
            case FacingDirection.Right:
                spriteRenderer.flipX = false;
                break;
            case FacingDirection.Left:
                spriteRenderer.flipX = true;
                break;
        }
    }

    private void PlayAnmationsBasedOnState()
    {
        switch (movementStates)
        {
            case MovementStates.Idle:
                animController.PlayIdleAnim();
                break;
            case MovementStates.Running:
                animController.PlayRunningAnim();
                break;
            case MovementStates.Jumping:
                animController.PlayJumpingAnim();
                break;
            default:
                break;
        }
    }

}
