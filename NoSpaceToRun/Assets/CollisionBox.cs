using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollisionBox 
{
    public Vector2 position;
    public Vector2 size = Vector2.one;

    public bool Equals(CollisionBox box)
    {
        return position == box.position && size == box.size;
    }

    public override string ToString()
    {
        return "("+position + ", "+size+")";
    }

    public CollisionBox Copy()
    {
        CollisionBox box = new CollisionBox();
        box.position.x = position.x;
        box.position.y = position.y;
        box.size.x = size.x;
        box.size.y = size.y;
        return box;
    }
}
