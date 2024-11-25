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
    //    // ���� NavMeshObstacle�� ���ٸ� �߰�
    //    navObstacle = GetComponent<NavMeshObstacle>();
    //    if (navObstacle == null)
    //    {
    //        navObstacle = gameObject.AddComponent<NavMeshObstacle>();
    //    }
    //    navObstacle.carving = false; // NavMesh�� Ÿ���� ������ �� �ֵ��� ������ ���� �� �ְ� ����
    //    navObstacle.enabled = false; // �ʱ⿡�� ��Ȱ��ȭ

    //    Debug.Log($"NavMeshObstacle initialized. Carving: {navObstacle.carving}, Enabled: {navObstacle.enabled}");
    //}


    public bool CanMove()
    {
        return !roadtype.blocksMovement;
    }
}
