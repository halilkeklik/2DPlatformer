using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private bool movingLeft = true;

    public Transform groundDetection;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D grounInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,2f);
        if (grounInfo == false)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }

}
