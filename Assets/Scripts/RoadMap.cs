using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
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


    public RoadType yellowSingleLane;


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

                newTile.transform.SetParent(NavMeshSurface.transform);

            }
        }


        NavMeshSurface.BuildNavMesh();


    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                RoadTile clickedTile = hit.collider.GetComponent<RoadTile>();
                if (clickedTile != null)
                {
                    clickedTile.roadtype = yellowSingleLane;

                    clickedTile.GetComponent<Renderer>().material.color = yellowSingleLane.laneColor;
                    
                    //clickedTile.navmehsobstacle.enabled = true;


                    // NavMesh 업데이트
                    NavMeshSurface.UpdateNavMesh(NavMeshSurface.navMeshData);
                }
            }
        }
    }
}
