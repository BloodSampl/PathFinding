using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingCalculations : MonoBehaviour
{
    PathFindingGrid grid;
    [SerializeField] Vector2Int startingNode;
    [SerializeField] Vector2Int goalNode;
    List<Node> openNodes = new List<Node>();
    List<Node> closedNodes = new List<Node>();

    private void Awake()
    {
        grid = GetComponent<PathFindingGrid>();
    }
    private void Start()
    {
        grid.GenerateGrid();
        AddingNeighbors();
        ChangeColorsForOpenNodes(Color.green);
        foreach (Node node in openNodes)
        {
            Debug.Log(node.NodeGridPos);
        }
    }
    //void Astar()
    //{
    //    while (true)
    //    {
    //        if(openNodes.Count <= 0)
    //        
    //            return false;
    //
    //        openList.Sort();
    //
    //        Node currentNode = openNodes[0];
    //        for (int i = 0; i < openNodes.Count; i++)
    //        {
    //
    //        }
    //        
    //    }
    //}

    
    
    public void AddingNeighbors()
    {
        Node startNode = grid.GetNode(startingNode);
        openNodes.Add(startNode);

        if(startNode.NodeGridPos.x < grid.width-1)
        {
            openNodes.Add(grid.GetNode(startingNode + new Vector2Int(1, 0)));
        }
        if(startNode.NodeGridPos.x > 0)
        {
            openNodes.Add(grid.GetNode(startingNode + new Vector2Int(-1, 0)));
        }
        if (startNode.NodeGridPos.y < grid.height-1)
        {
            openNodes.Add(grid.GetNode(startingNode + new Vector2Int(0, 1)));
        }
        if (startNode.NodeGridPos.y > 0)
        {
            openNodes.Add(grid.GetNode(startingNode + new Vector2Int(0, -1)));
        }
    }

    int CalculateNodeCost(Vector2Int nodOneVector, Vector2Int nodTwoVector)
    {
        return Mathf.Abs(nodOneVector.x - nodTwoVector.x) +
                Mathf.Abs(nodOneVector.y - nodTwoVector.y);
    }
    void ChangeColorsForOpenNodes(Color color)
    {
        foreach (Node node in openNodes)
        {
            GameObject nodeObject = GameObject.Find(node.NodeGridPos.ToString());
            Debug.Log(node.NodeGridPos);
            Renderer nodeRenderer = nodeObject.GetComponentInChildren<Renderer>();
            nodeRenderer.material.color = color;
        }
    }
}
