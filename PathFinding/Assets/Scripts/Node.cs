using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    
    public Vector2 NodeGridPos;
    public Vector3 NodeWorldPos;

    public Node(Vector2 nodePos, Vector3 nodeWorldPos)
    {
        NodeGridPos = nodePos;
        NodeWorldPos = nodeWorldPos;
    }
}
