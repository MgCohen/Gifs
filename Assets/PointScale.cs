using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PointScale : MonoBehaviour
{

    public bool useSlice = false;

    public Vector2 scaleA;
    public Vector2 scaleB;

    public float time;
    public float initialOffset;
    public Ease ease;
    private void OnEnable()
    {
        time /= initialOffset;
        Scale(scaleA, scaleB);
        time *= initialOffset;
    }

    public void Scale(Vector2 dir, Vector2 nextDir)
    {
        if (!useSlice)
        {
            transform.DOScale(dir, time).SetEase(ease).OnComplete(() =>
            {
                Scale(nextDir, dir);
            });
        }
        else
        {
            var sprite = GetComponent<SpriteRenderer>();
            DOTween.To(() => sprite.size, x => sprite.size = x, dir, time).SetEase(ease).OnComplete(() =>
              {
                  Scale(nextDir, dir);
              });
        }

    }
}
