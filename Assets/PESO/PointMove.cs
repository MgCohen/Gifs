using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PointMove : MonoBehaviour
{
    public Vector2 pointA;
    public Vector2 pointB;

    public float time;
    public float initialOffset;
    public Ease ease;
    private void OnEnable()
    {
        time /= initialOffset;
        Move(pointA, pointB);
        time *= initialOffset;
    }

    public void Move(Vector2 dir, Vector2 nextDir)
    {
        transform.DOLocalMove(dir, time).SetEase(ease).OnComplete(() =>
        {
            Move(nextDir, dir);
        });
    }
}
