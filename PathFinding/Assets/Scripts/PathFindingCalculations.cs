using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;


public class PathFindingCalculations : MonoBehaviour
{
    PathFindingGrid grid;
    [SerializeField] Vector2Int startingNode;
    [SerializeField] Vector2Int endNode;
    TextMeshProUGUI []lable;
    List<Node> openNodes = new List<Node>();
    List<Node> closedNodes = new List<Node>();

    public string gCostLabelName = "Gcost"; 
    public string hCostLabelName = "Hcost";
    public string fCostLabelName = "Fcost";
    public string labelsParentName = "Canvas";

    private void Awake()
    {
        grid = GetComponent<PathFindingGrid>();
    }
    private void Start()
    {
        grid.GenerateGrid();
        ChangeColorsForOpenNodes(Color.green);
        FindPath();
    }
    void FindPath()
    {
        Node startNode = grid.GetNode(startingNode);
        Node targetNode = grid.GetNode(endNode);
        openNodes.Add(startNode);

        while (openNodes.Count > 0)
        {
            Node currentNode = GetLowestFcostNode(openNodes);

            if(currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                Debug.Log("Path Found");
                return; 
            }
            openNodes.Remove(currentNode);
            closedNodes.Add(currentNode);


            foreach(Node neighbor in GetNeighbors(currentNode))
            {
                if(!neighbor.Walkble || closedNodes.Contains(neighbor))
                {
                    continue;
                }

                int newNeighborGcost = currentNode.Gcost + CalculateNodeCost(currentNode.NodeGridPos, neighbor.NodeGridPos);

                if(newNeighborGcost < neighbor.Gcost || !openNodes.Contains(neighbor))
                {
                    neighbor.Gcost = newNeighborGcost;
                    //Debug.Log(neighbor.Gcost);
                    neighbor.Hcost = CalculateNodeCost(neighbor.NodeGridPos, endNode);
                    //Debug.Log(neighbor.Hcost);
                    neighbor.Parent = currentNode;

                    if(!openNodes.Contains(neighbor))
                    {
                        openNodes.Add(neighbor);
                    }
                }

            }

        }
        Debug.Log("No Path was found");
    }

    Node GetLowestFcostNode(List<Node> nodes)
    {
        Node lowestFcostNode = nodes[0];
        for(int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].Fcost < lowestFcostNode.Fcost)
            {
                lowestFcostNode = nodes[i];
            }
        }
        return lowestFcostNode;
    }



    List<Node> GetNeighbors(Node current)
    {
        List<Node> neighborNodes = new List<Node>();

        Vector2Int currentPosition = current.NodeGridPos;

        if (currentPosition.x < grid.width - 1)
        {
            neighborNodes.Add(grid.GetNode(currentPosition + new Vector2Int(1, 0)));
        }
        if (currentPosition.x > 0)
        {
            neighborNodes.Add(grid.GetNode(currentPosition + new Vector2Int(-1, 0)));
        }
        if (currentPosition.y < grid.height - 1)
        {
            neighborNodes.Add(grid.GetNode(currentPosition + new Vector2Int(0, 1)));
        }
        if (currentPosition.y > 0)
        {
            neighborNodes.Add(grid.GetNode(currentPosition + new Vector2Int(0, -1)));
        }

        return neighborNodes;
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
            //Debug.Log(node.NodeGridPos);
            Renderer nodeRenderer = nodeObject.GetComponentInChildren<Renderer>();
            nodeRenderer.material.color = color;

        }
    }


    void RetracePath(Node start, Node goal)
    {
        List<Node> path = new List<Node>();
        Node currentNode = goal;

        while (currentNode != start)
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }
        DisplayPath(path);
    }
    void DisplayPath(List<Node> path)
    {
        foreach(Node node in path)
        {
            GameObject nodeObject = GameObject.Find(node.NodeGridPos.ToString());
            Renderer nodeRenderer = nodeObject.GetComponentInChildren<Renderer>();
            nodeRenderer.material.color = Color.blue;
        }
    }
}
