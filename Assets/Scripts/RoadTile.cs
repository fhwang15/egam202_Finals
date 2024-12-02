using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class RoadTile : MonoBehaviour
{

    public RoadType roadtype;
   
    private Renderer tileRenderer;

    public NavMeshModifier modifier;

    // Start is called before the first frame update
    void Start()
    {

        tileRenderer = GetComponent<Renderer>();

        if(roadtype != null)
        {
            tileRenderer.material.color = roadtype.laneColor;
        }
        
    }

    private void Awake()
    {
     
    }


    public bool CanMove()
    {
        return !roadtype.blocksMovement;
    }
}
