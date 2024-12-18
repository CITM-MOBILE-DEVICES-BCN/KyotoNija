using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PopUpDoTween : MonoBehaviour
{
    [Header("Grow Settings")]
    public float growDuration = 0.5f;
    public Ease growEase = Ease.OutBack;
    public float delay = 0f;

    [Header("Rotation Settings")]
    public float rotationDuration = 0.5f;
    public Ease rotationEase = Ease.OutBack;
    public float rotationAngle = 360f;

    private RectTransform rectTransform;
    private Vector3 initialScale;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            return;
        }

        initialScale = rectTransform.localScale;
        rectTransform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        rectTransform.localScale = Vector3.zero;
        rectTransform.DOScale(initialScale, growDuration).SetEase(growEase).SetDelay(delay);

        rectTransform.localRotation = Quaternion.Euler(0, 0, 0);
        rectTransform.DORotate(new Vector3(0, 0, rotationAngle), rotationDuration, RotateMode.FastBeyond360)
                     .SetEase(rotationEase).SetDelay(delay);
    }
}
