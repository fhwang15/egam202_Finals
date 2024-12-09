using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LineSelection : MonoBehaviour
{

    public static bool whiteLane;
    public static bool eraser;
    public static bool crossway;


    private void Start()
    {
        whiteLane = true;
        eraser = false;
        crossway = false;
    }

    public void whiteLaneSelected()
    {

        whiteLane = true;
        eraser = false;
        crossway = false;

        Debug.Log("White Lane: " + whiteLane);
        Debug.Log("eraser: " + eraser);
    }

    public void eraserSelected()
    {
        whiteLane = false;
        eraser = true;
        crossway = false;

        Debug.Log("White Lane: " + whiteLane);
        Debug.Log("eraser: " + eraser);

    }

    public void crosswaySelected()
    {
        whiteLane = false;
        eraser = false;
        crossway = true;
    }
}
