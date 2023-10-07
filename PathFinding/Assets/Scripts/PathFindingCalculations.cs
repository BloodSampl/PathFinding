using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingCalculations : MonoBehaviour
{
    PathFindingGrid grid;
    [SerializeField] Vector2Int startingNode;
    [SerializeField] Vector2Int endNode;
    List<Node> openNodes = new List<Node>();

    private void Awake()
    {
        grid = GetComponent<PathFindingGrid>();
    }
    private void Start()
    {
        grid.GenerateGrid();
        AddingNeighbors();
        ChangingColorsForOpenNodes(Color.green);
        foreach (Node node in openNodes)
        {
            Debug.Log(node.NodeGridPos);
        }
    }
    public void AddingNeighbors()
    {
        Node startNode = grid.GetNode(startingNode);

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
    void ChangingColorsForOpenNodes(Color color)
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
