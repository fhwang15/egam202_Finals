using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseCondition : MonoBehaviour
{
    public static float currentScore;
    public float maxScore;

    public GameObject winText;


    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentScore == maxScore)
        {
            winText.SetActive(true);
        }

    }
}
