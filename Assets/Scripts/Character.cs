using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    CharacterAnimationController characterAnimation;
    CharacterMovementController characterMovement;
    CharacterCombat characterCombat;
    Health health;

    private Rigidbody2D rigidBody2D;

    private void Awake()
    {
        characterAnimation = GetComponent<CharacterAnimationController>();
        characterMovement = GetComponent<CharacterMovementController>();
        characterCombat = GetComponent<CharacterCombat>();
        health = GetComponent<Health>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetCharaterState();

        if(Input.GetMouseButton(0) && characterMovement.movementStates != CharacterMovementController.MovementStates.Jumping)
        {
            StartCoroutine(AttackOrder());
        }
    }
    private void SetCharaterState()
    {
        if (characterMovement.isGrounded())
        {
            if (characterCombat.isAttacking)
                return;
            if (rigidBody2D.velocity.x == 0)
            {
                characterMovement.movementStates = CharacterMovementController.MovementStates.Idle;
            }
            else if (rigidBody2D.velocity.x > 0)
            {
                characterMovement.facingDirection = CharacterMovementController.FacingDirection.Right;
                characterMovement.movementStates = CharacterMovementController.MovementStates.Running;
            }
            else if (rigidBody2D.velocity.x < 0)
            {
                characterMovement.facingDirection = CharacterMovementController.FacingDirection.Left;
                characterMovement.movementStates = CharacterMovementController.MovementStates.Running;
            }
        }
        else
        {
            characterMovement.movementStates = CharacterMovementController.MovementStates.Jumping;
        }
    }

    private IEnumerator AttackOrder()
    {
        if (characterCombat.isAttacking)
            yield break;

        characterCombat.isAttacking = true;
        characterMovement.movementStates = CharacterMovementController.MovementStates.Attacking;

        characterAnimation.TiggerAttackAnim();

        yield return new WaitForSeconds(0.46f);

        characterCombat.Attack();

        characterCombat.isAttacking = false;
    }


}
