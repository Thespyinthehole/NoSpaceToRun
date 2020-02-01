using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode,RequireComponent(typeof(RawImage))]
public class SpaceBackGround : MonoBehaviour
{
    RawImage i;
    public Vector2 offset;
    public float scale = 1;

    private void Awake()
    {
        i = GetComponent<RawImage>();
    }

    public void Update()
    {
        Rect r = new Rect();
        r.height = scale;
        r.width = scale;
        r.x = offset.x;
        r.y = offset.y;
        i.uvRect = r;
    }
}
