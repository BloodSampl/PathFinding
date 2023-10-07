using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PathFindingGrid : MonoBehaviour
{
    PathFindingCalculations calculations;
    public int width;
    public int height;
    [SerializeField] List<Node> nodes = new List<Node>();
    public GameObject prefab;
    public GameObject nodPrefab;

    public Node GetNode(Vector2Int gridPosition)
    {
        int index = gridPosition.x + gridPosition.y * width;
        return nodes[index];
    }

    public void GenerateGrid()
    {
        for(int z = 0; z < height; z++)
        {
            for(int x = 0; x < width; x++)
            {
                Vector2Int pos = new Vector2Int(x, z);
                Node newNode = new Node(pos,new Vector3(pos.x,0 ,pos.y));
                nodPrefab = Instantiate(prefab, new Vector3(pos.x ,0, pos.y), Quaternion.identity);
                nodPrefab.transform.parent = transform;
                nodPrefab.name = pos.ToString();
                nodes.Add(newNode);
               // Debug.Log(nodes.Count);
                //Debug.Log(newNode.NodeGridPos);
                //Renderer renderer = nodPrefab.GetComponentInChildren<Renderer>();
                //renderer.material.color = Color.red;
            }
        }
    }

}
