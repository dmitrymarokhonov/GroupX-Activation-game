using UnityEngine;
using UnityEngine.AI;

// This script is added as a component to the animal so it can move randomly.
// Nav Mesh Agent is also required for the movement.
// Terrain Nav Mesh must be baked for NavMeshAgent to work

namespace Relanima
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class BasicAnimalMovement : MonoBehaviour
    {
        // This value is used for calculating the area for the random movement.
        // Increasing the value increases the movement area.
        public float radius = 5.0f;

        // This value is used for calculating how often the animal starts to move randomly
        // Increasing the value decreases how often the animal moves randomly
        public int movementHelper = 150;

        private bool _isStationary = true;
        private NavMeshAgent agent;

        public RuntimeAnimatorController idleAnimator;
        public RuntimeAnimatorController walkAnimator;
        public Vector3 previousPosition;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            previousPosition = new Vector3(0,0,0);
        }

        public void Update()
        {
            // Uses randomization for checking if the stationary animal needs to move or not
            if (agent != null && _isStationary)
            {
                int randomNumber = Random.Range(0, movementHelper);
                if (randomNumber != 0) return;
                
                agent.SetDestination(RandomDestination());
                _isStationary = false;
            }
            // Checks if the animal has reached the random target
            else if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
            {
                _isStationary = true;
            }

            //var animalSleeping = this.GetComponent<Rigidbody>().IsSleeping();
            //var animalSpeed = this.GetComponent<Rigidbody>().velocity.magnitude;
            var positionChange = ((transform.position - previousPosition).magnitude);

            if (positionChange < 0.01f)
            {
                this.GetComponent<Animator>().runtimeAnimatorController = idleAnimator as RuntimeAnimatorController;
            } else
            {
                this.GetComponent<Animator>().runtimeAnimatorController = walkAnimator as RuntimeAnimatorController;
            }

            previousPosition = transform.position;
        }   

        // This function is used for finding the next random place for the animal
        private Vector3 RandomDestination()
        {
            Vector3 finalPosition = Vector3.zero;
            Vector3 randomPosition = Random.insideUnitSphere * radius;
            randomPosition += transform.position;
            
            if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, radius, 1))
            {
                finalPosition = hit.position;
            }
            
            return finalPosition;
        }
    }
}