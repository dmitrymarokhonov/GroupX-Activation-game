using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This script is added as a component to the animal so it can move randomly.
// Nav Mesh Agent is also requared for the movement.

public class BasicAnimalMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    // This value is used for calculating the area for the random movement.
    // Increasing the value increases the movement area.
    public float radius = 5.0f;

    // This value is used for calculating how often the animal starts to move randomly
    // Increasing the value decreases how often the animal moves randomly
    public int movementHelper = 150;

    private bool isStationary = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Uses randomization for checking if the stationary animal needs to move or not
        if(agent != null && isStationary == true){
            int randomNumber = Random.Range(0, movementHelper);
            if(randomNumber == 0){
              agent.SetDestination(RandomDestination());
              isStationary = false;
            }
        }
        // Checks if the animal has reached the random target
        else if(agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            isStationary = true;
        }
    }

    // This function is used for finding the next random place for the animal
    public Vector3 RandomDestination()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * radius;
        randomPosition += transform.position;
        if(NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, radius, 1)){
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
