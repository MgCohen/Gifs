using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PointText : MonoBehaviour
{
    TextMeshPro text;

    public int currentValue;
    public int pointA;
    public int pointB;

    public float time;
    public float initialOffset;
    public Ease ease;
    private void OnEnable()
    {
        text = GetComponent<TextMeshPro>();
        time /= initialOffset;
        updateText(pointA, pointB);
        time *= initialOffset;
    }

    public void updateText(int dir, int nextDir)
    {
        DOTween.To(() => currentValue, x => currentValue = x, dir, time).SetEase(ease).OnComplete(() =>
        {
            updateText(nextDir, dir);
        });
    }

    private void Update()
    {
        text.text = currentValue.ToString();
    }
}
