using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingCalculations : MonoBehaviour
{
    PathFindingGrid grid;
    [SerializeField] Vector2Int startingNode;
    [SerializeField] Vector2Int endNode;
    Material nodRendererMaterial;
    List<Node> openNodes = new List<Node>();
    void AddingNeighbors()
    {
        Node startNode = grid.GetNode(startingNode);

        if(startNode.NodeGridPos.x < grid.width)
        {
            openNodes.Add(grid.GetNode(startingNode + new Vector2Int(1, 0)));     
        }
        if(startNode.NodeGridPos.x >= 0)
        {
            openNodes.Add(grid.GetNode(startingNode + new Vector2Int(-1, 0)));
        }
        if (startNode.NodeGridPos.y > grid.height)
        {
            openNodes.Add(grid.GetNode(startingNode + new Vector2Int(-1, 0)));
        }
        if (startNode.NodeGridPos.x >= 0)
        {
            openNodes.Add(grid.GetNode(startingNode + new Vector2Int(-1, 0)));
        }
    }
}
