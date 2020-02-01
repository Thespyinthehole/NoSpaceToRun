using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode,RequireComponent(typeof(RectTransform))]
public class CharacterResizer : MonoBehaviour
{
    public Vector2 baseSize;
    public AdjustShipToBox scaledTo;

    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rect.sizeDelta = scaledTo.autoScale * baseSize;   
    }
}
