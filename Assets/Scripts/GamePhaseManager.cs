using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;

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
    public GameObject[] pedestrians; //Pedestrians objects that will move

    public Transform[] CarDestination; //destination for the cars/pedestrains. 
    public Transform[] PedestrainDestination; 

    //Button to simulate the result.
    //public Button simulate;


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
        if(currentPhase == GamePhase.SetUp)
        {
            currentPhase = GamePhase.Play;

            for (int i = 0; i < cars.Length; i++)
            {
                NavMeshAgent agent = cars[i].GetComponent<NavMeshAgent>();
                NavMeshAgent agentPedestrains = pedestrians[i].GetComponent<NavMeshAgent>(); //Will develop further.

                if(agent != null)
                {
                    agent.enabled = true;
                    agent.SetDestination(CarDestination[i].position);
                }

            }
            
        }

    }

    //Coroutine will be included once other stuffs are finished. until then, work on the things.





}
