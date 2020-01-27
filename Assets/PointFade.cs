using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PointFade : MonoBehaviour
{
    public float valueA;
    public float valueB;

    public float time;
    public float initialOffset;
    public Ease ease;
    private void OnEnable()
    {
        time /= initialOffset;
        Fade(valueA, valueB);
        time *= initialOffset;
    }

    public void Fade(float dir, float nextDir)
    {
        var sprite = GetComponent<SpriteRenderer>();
        sprite.DOFade(dir, time).SetEase(ease).OnComplete(() =>
        {
            Fade(nextDir, dir);
        });
    }
}
