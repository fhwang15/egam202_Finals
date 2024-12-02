using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarController : MonoBehaviour
{

    private NavMeshAgent car;

    public Transform destination; //Destination for the goal 

    public float waypointRadius;
    public float Angle;

    // Start is called before the first frame update
    void Start()
    {
        Angle = 45f;
        waypointRadius = 3f;

        car = GetComponent<NavMeshAgent>();
        car.enabled = false; //클릭 될때까지 움직이지 않음. won't move until simulation button is pressed.
    }

    // Update is called once per frame
    void Update()
    {
        if(car != null && car.enabled)
        {
            if(destination != null && !car.pathPending && car.remainingDistance < 0.5f)
            {
                Vector3 randomOffset = GetRandomForwardOffset();
                Vector3 waypoint = destination.position + randomOffset;

                if(NavMesh.SamplePosition(waypoint, out NavMeshHit hit, waypointRadius, NavMesh.AllAreas))
                {
                    car.SetDestination(hit.position);
                }


            }
            

        }
    }


    Vector3 GetRandomForwardOffset()
    {
        Vector3 forward = car.transform.forward;
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(-Angle, Angle), 0);
        Vector3 direction = randomRotation * forward;

        return direction.normalized * Random.Range(1f, waypointRadius);
    }

}
