using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoadTile : MonoBehaviour
{

    public RoadType roadtype;
   // public NavMeshObstacle navObstacle;

    private Renderer tileRenderer; 

    // Start is called before the first frame update
    void Start()
    {

        tileRenderer = GetComponent<Renderer>();

        if(roadtype != null)
        {
            tileRenderer.material.color = roadtype.laneColor;
        }
        
    }

    //private void Awake()
    //{
    //    // 만약 NavMeshObstacle이 없다면 추가
    //    navObstacle = GetComponent<NavMeshObstacle>();
    //    if (navObstacle == null)
    //    {
    //        navObstacle = gameObject.AddComponent<NavMeshObstacle>();
    //    }
    //    navObstacle.carving = false; // NavMesh가 타일을 지나갈 수 있도록 구멍을 뚫을 수 있게 설정
    //    navObstacle.enabled = false; // 초기에는 비활성화

    //    Debug.Log($"NavMeshObstacle initialized. Carving: {navObstacle.carving}, Enabled: {navObstacle.enabled}");
    //}


    public bool CanMove()
    {
        return !roadtype.blocksMovement;
    }
}
