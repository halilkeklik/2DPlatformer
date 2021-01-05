using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHealth : Health, IDamageable<int>
{
    public SpriteRenderer spriteRenderer;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        HitFeedback();

        if (CheckIfWeDead())
        {
            onDeath();
        }
    }

    protected override void HitFeedback()
    {
        base.HitFeedback();
        
        this.gameObject.transform.DOShakePosition(0.1f, new Vector3(0.3f, 0.03f, 0), 10, 90);
        Tween colorTween = spriteRenderer.DOBlendableColor(Color.cyan, 0.1f);
        colorTween.OnComplete(() => spriteRenderer.DOBlendableColor(Color.white, 0.05f));
    }

    protected override void onDeath()
    {
        base.onDeath();

        this.gameObject.transform.DOShakePosition(0.1f, new Vector3(0.3f, 0.03f, 0), 10, 90);
        Tween colorTween = spriteRenderer.DOBlendableColor(Color.black, 0.3f);
        colorTween.OnComplete(() => Destroy(gameObject));
    }
}
