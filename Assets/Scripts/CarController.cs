using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class CarController : MonoBehaviour
{

    private NavMeshAgent car;

    public Transform destination; //Destination for the goal 

    public float waypointRadius;
    public float Angle;
    public float randomizeInterval;

    public ParticleSystem explosion;

    public GameObject replay;
    public GameObject Win;

    bool reachedGoal;


    private float randomizeTimer;

    // Start is called before the first frame update
    void Start()
    {
        Angle = 90f;
        waypointRadius = 3f;
        reachedGoal = false;

        car = GetComponent<NavMeshAgent>();
        car.enabled = false; //Ŭ�� �ɶ����� �������� ����. won't move until simulation button is pressed.
        randomizeTimer = randomizeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(car != null && car.enabled && !reachedGoal)
        {

            randomizeTimer -= Time.deltaTime;

            if(randomizeTimer <= 0f)
            {
                UpdateRandomPath();
                randomizeTimer = randomizeInterval;
            }


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

        else if (reachedGoal)
        {
            car.enabled = false;
        }

    }


    private void UpdateRandomPath()
    {
        if(destination != null)
        {
            Vector3 randomOffset = GetRandomForwardOffset();
            Vector3 randomWaypoint = car.transform.position + randomOffset;

            if(NavMesh.SamplePosition(randomWaypoint, out NavMeshHit hit, waypointRadius, NavMesh.AllAreas))
            {
                car.SetDestination(hit.position);
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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);

            replay.SetActive(true);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            reachedGoal = true;
            Win.SetActive(true);
        }
    }

}