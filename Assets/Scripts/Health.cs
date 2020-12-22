using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Health : MonoBehaviour
{
    public enum AttackableObject
    {
        Player,
        Tree
    }

    public int health;
    public AttackableObject objectType;
    public SpriteRenderer spriteRenderer;

    public  void TakeDamage(int damage)
    {
        health -= damage;

        if (objectType == AttackableObject.Tree)
        {
            HitFeedback();
        }

        CheckIfWeDead();
    }

    protected  void CheckIfWeDead()
    {
        if (health <= 0)
        {
            health = 0;
            if (objectType == AttackableObject.Tree)
            {
                TreeDestoryFedBack();
            }

        }
    }

    private void HitFeedback()
    {
        this.gameObject.transform.DOShakePosition(0.1f, new Vector3(0.3f, 0.03f, 0), 10, 90);
        Tween colorTween = spriteRenderer.DOBlendableColor(Color.red, 0.1f);
        colorTween.OnComplete(() => spriteRenderer.DOBlendableColor(Color.white, 0.05f));
    }

    private void TreeDestoryFedBack()
    {
        this.gameObject.transform.DOShakePosition(0.1f, new Vector3(0.3f, 0.03f, 0), 10, 90);
        Tween colorTween = spriteRenderer.DOBlendableColor(Color.red, 0.1f);
        colorTween.OnComplete(() => Destroy(gameObject));
    }
}
