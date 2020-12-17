using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    public float bounceForce;
    public float DisappearTime;

    IEnumerator disappearTime()
    {
        yield return new WaitForSeconds(DisappearTime);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterMovementController>().jumpJorce += bounceForce;
            StartCoroutine(disappearTime());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<CharacterMovementController>().jumpJorce -= bounceForce;
    }
}
