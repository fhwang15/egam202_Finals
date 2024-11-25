using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class RoadMap : MonoBehaviour
{

    public int width = 8;
    public int height = 8;
    public float spacing = 1.05f;

    public RoadTile tilePrefab;

    public NavMeshSurface NavMeshSurface;

    RoadTile[,] tileArray;


    // Start is called before the first frame update
    void Start()
    {
        tileArray = new RoadTile[width, height];



        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++) 
            { 

                RoadTile newTile = Instantiate(tilePrefab);
                
                Vector3 newPosition = new Vector3(x*spacing, 0, y*spacing);
                newTile.transform.localPosition = newPosition;  
            
                tileArray[x, y] = newTile;

            }
        }


        NavMeshSurface.BuildNavMesh();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
