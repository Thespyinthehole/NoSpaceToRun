using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(RectTransform))]
public class AdjustTeamBox : MonoBehaviour
{
    RectTransform rect;
    float xBuffer = 0;
    float yBuffer = 0;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        xBuffer = Mathf.Abs(rect.anchoredPosition.x);
        yBuffer = Mathf.Abs(rect.anchoredPosition.y);
    }

    private void Start()
    {
        if (Application.isPlaying)
            UpdateSize();
    }

    void Update()
    {
        if (!Application.isPlaying)
            UpdateSize();
    }

    void UpdateSize()
    {
        float height = Screen.height / 2 - yBuffer * 1.5f;
        float width = Screen.width / 2 - xBuffer * 1.5f;
        Vector2 scale = rect.sizeDelta;
        scale.y = height;
        scale.x = width;
        rect.sizeDelta = scale;
    }
}
