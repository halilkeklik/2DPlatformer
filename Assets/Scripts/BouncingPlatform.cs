using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPlatform : MonoBehaviour
{
    public float bounceForce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterMovementController>().jumpJorce += bounceForce;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<CharacterMovementController>().jumpJorce -= bounceForce;
    }
}
