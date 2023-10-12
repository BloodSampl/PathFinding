using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IComparer
{
    public int Hcost;
    public int Gcost;
    public int Fcost;


    public bool Walkble;

    public Node ParantNode; 
    public Vector2Int NodeGridPos;
    public Vector3 NodeWorldPos;

    public Node(Vector2Int nodePos, Vector3 nodeWorldPos)
    {
        NodeGridPos = nodePos;
        NodeWorldPos = nodeWorldPos;
    }
    public int CompareTo(object obj)
    {
        Node otherNode = (Node)obj;

        if(Fcost < otherNode.Fcost)
        {

        }
    }
}
