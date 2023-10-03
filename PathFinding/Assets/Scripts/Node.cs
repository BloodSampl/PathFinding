using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeClass
{
    public Vector2 NodeGridPos;
    public Vector3 NodeWorldPos;

    public NodeClass(Vector2 nodePos, Vector3 nodeWorldPos)
    {
        NodeGridPos = nodePos;
        NodeWorldPos = nodeWorldPos;
    }
}
