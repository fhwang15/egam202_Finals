using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Road", menuName = "Road")]

public class RoadType : ScriptableObject
{
    public string name;
    public string description;

    public LayerMask layerMask;

    
}
