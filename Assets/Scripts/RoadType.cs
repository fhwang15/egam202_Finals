using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lane Type", menuName = "Road/LaneType")]

public class RoadType : ScriptableObject
{
    public string name;
    public string description;

    public Color laneColor;

    public bool blocksMovement;

    public LayerMask layerMask;

    public bool[] typeIndicator = new bool[3];

    //type 1 = default Road;
    //type 2 = white Lane
    //type 3 = cross way

    
}
