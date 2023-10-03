using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingGrid : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] List<NodeClass> grid = new List<NodeClass>();
    [SerializeField] GameObject prefab;

    private void Start()
    {
        GenerateGrid(); 
    }

    private void GenerateGrid()
    {
        for(int z = 0; z < height; z++)
        {
            for(int x = 0; x < width; x++)
            {
                Vector2Int pos = new Vector2Int(x, z);
                NodeClass newNode = new NodeClass(pos,new Vector3(pos.x,0 ,pos.y));
                GameObject nodPrefab = Instantiate(prefab, new Vector3(pos.x ,0, pos.y), Quaternion.identity);
                nodPrefab.transform.parent = transform;
                nodPrefab.name = pos.ToString();
                grid.Add(newNode);
                Debug.Log(grid.Count);
                Debug.Log(Mathf.RoundToInt(newNode.NodeGridPos.x) + "," + Mathf.RoundToInt(newNode.NodeGridPos.y));
                
            }
        }
    }

}
