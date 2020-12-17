using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Vector3 returnEndPoint()
    {
        Vector3 calculetedEndPoint; 
        calculetedEndPoint.x = spriteRenderer.bounds.size.x + this.transform.position.x + Random.Range(0f,2.2f);
        calculetedEndPoint.y = Random.Range(0f,2.2f);
        calculetedEndPoint.z = 1;
        return calculetedEndPoint;
    }
}
