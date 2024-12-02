using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class GamePhaseManager : MonoBehaviour
{
    public enum GamePhase
    {
        SetUp,
        Play
    }

    public GamePhase currentPhase = GamePhase.SetUp; //current phase.

    //NavMesh Agents
    public GameObject[] cars; //Car Objects that will move
    //public GameObject[] pedestrians; //Pedestrians objects that will move


    public NavMeshSurface finalSurface;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressed() //Once Button is pressed, it starts simulating the result.
    {

        finalSurface.BuildNavMesh();

        if(currentPhase == GamePhase.SetUp)
        {
            currentPhase = GamePhase.Play;

            foreach (GameObject car in cars)
            {
                NavMeshAgent agent = car.GetComponent<NavMeshAgent>();

                if (agent != null)
                {
                    agent.enabled = true;
                }

            }
            
        }

    }

    //Coroutine will be included once other stuffs are finished. until then, work on the things.





}
