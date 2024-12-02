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


    public RoadType whiteSingleLane;
    public RoadType defaultLane;


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

                if (clickedTile != null && LineSelection.whiteLane)
                {

                    clickedTile.roadtype = whiteSingleLane;
                    clickedTile.GetComponent<Renderer>().material.color = whiteSingleLane.laneColor;

                    NavMeshModifier clickedmodifier = clickedTile.GetComponent<NavMeshModifier>();



                    if (clickedmodifier != null)
                    {
                        Debug.Log($"Modifier 설정 확인: Area {clickedmodifier.area}, Override {clickedmodifier.overrideArea}");

                        clickedmodifier.overrideArea = true; // 반드시 true로 설정
                        clickedmodifier.area = NavMesh.GetAreaFromName("Not Walkable");
                        Debug.Log($"Modifier 설정 완료: Area {clickedmodifier.area}, Override {clickedmodifier.overrideArea}");
                    }

                    UpdateNavMesh();
                }

                else if (clickedTile != null && LineSelection.eraser)
                {
                    clickedTile.roadtype = defaultLane;
                    clickedTile.GetComponent<Renderer>().material.color = defaultLane.laneColor;

                    NavMeshModifier clickedmodifier = clickedTile.GetComponent<NavMeshModifier>();

                    if (clickedmodifier != null)
                    {
                        clickedmodifier.overrideArea = true; // 반드시 true로 설정
                        clickedmodifier.area = NavMesh.GetAreaFromName("Walkable");
                        Debug.Log($"Modifier 설정 완료: Area {clickedmodifier.area}, Override {clickedmodifier.overrideArea}");
                    }

                    UpdateNavMesh();
                }

            }
        }
    }


    private void UpdateNavMesh()
    {
        if (NavMeshSurface != null)
        {
            NavMeshSurface.BuildNavMesh();
            Debug.Log("NavMesh 업데이트 완료");
        }
    }

}
