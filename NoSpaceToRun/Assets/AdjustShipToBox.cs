using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(RectTransform))]
public class AdjustShipToBox : MonoBehaviour
{
    RectTransform rect;
    public float buffer;
    public float autoScale;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        if (Application.isPlaying)
            UpdateSize();
    }

    private void Update()
    {
        if (!Application.isPlaying)
            UpdateSize();
    }

    void UpdateSize()
    {
        RectTransform parent = transform.parent.GetComponent<RectTransform>();
        if (parent != null)
        {
            float width = parent.sizeDelta.x - buffer;
            float height = parent.sizeDelta.y - buffer;
            float xMul = width / 256;
            float yMul = height / 128;
            float mul = xMul < yMul ? xMul : yMul;
            Vector2 scale = new Vector2(256, 128) * mul;
            rect.sizeDelta = scale;
            autoScale = mul;
        }
    }
}
