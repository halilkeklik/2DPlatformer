using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
    public float iceForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterMovementController>().movementSpeed -= iceForce;
            collision.gameObject.GetComponent<CharacterMovementController>().jumpJorce -= iceForce;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<CharacterMovementController>().movementSpeed += iceForce;
        collision.gameObject.GetComponent<CharacterMovementController>().jumpJorce += iceForce;
    }
}
