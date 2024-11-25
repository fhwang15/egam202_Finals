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

    public bool[] typeIndicator = new bool[4];

    //type 1 = default Road;
    //type 2 = yellow Lane
    //type 3 = white single lane
    //type 4 = cross way

    
}
