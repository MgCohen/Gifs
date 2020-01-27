using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PointRotation : MonoBehaviour
{

    public float rotA;
    public float rotB;

    public float time;
    public float initialOffset;
    public Ease ease;
    private void OnEnable()
    {
        time /= initialOffset;
        Rotate(rotA, rotB);
        time *= initialOffset;
    }

    public void Rotate(float dir, float nextDir)
    {
        var rotation = new Vector3(0, 0, dir);
        transform.DORotate(rotation, time).SetEase(ease).OnComplete(() =>
        {
            Rotate(nextDir, dir);
        });
    }
}
