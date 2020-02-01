using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShipCollider : MonoBehaviour
{
    public List<CollisionBox> colliderBoxs = new List<CollisionBox>();
    List<CollisionBox> lastColliderBoxs = new List<CollisionBox>();
    GameObject colliderParent;

    List<BoxCollider2D> colliders = new List<BoxCollider2D>() { null, null };

    private void Awake()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        while (box != null)
        {
            DestroyImmediate(box);
            box = GetComponent<BoxCollider2D>();
        }

        Transform t = transform.parent.Find("Colliders");
        colliderParent = t == null ? new GameObject("Colliders",typeof(RectTransform)) : t.gameObject;
        colliderParent.transform.parent = transform.parent;
        colliderParent.transform.localPosition = transform.localPosition;
    }

    private void Start()
    {
        if (Application.isPlaying)
            UpdateColliders();
    }

    private void Update()
    {
        if (!Application.isPlaying)
            UpdateColliders();
    }

    void UpdateColliders()
    {
        if (isUpdated() || Application.isPlaying)
        {
            for (int i = colliders.Count - 1; i >= 0; i--)
            {
                DestroyImmediate(colliders[i]);
            }

            for (int i = 0; i < colliderBoxs.Count; i++)
            {
                BoxCollider2D box = colliderParent.AddComponent<BoxCollider2D>();
                box.offset = colliderBoxs[i].position;
                box.size = colliderBoxs[i].size;
                colliders.Add(box);
            }

            lastColliderBoxs = new List<CollisionBox>();

            foreach (CollisionBox box in colliderBoxs)
            {
                lastColliderBoxs.Add(box.Copy());
            }
        }
    }

    bool isUpdated()
    {
        if (lastColliderBoxs.Count != colliderBoxs.Count)
            return true;
        
        for (int i = 0; i < lastColliderBoxs.Count; i++)
        {
            if (!lastColliderBoxs[i].Equals(colliderBoxs[i]))
                return true;
        }

        return false;
    }
}
