using UnityEngine;
using UnityEngine.AI;

namespace Relanima.Rewards
{
    public class RewardSpawner : MonoBehaviour
    {
        public GameObject rewardPrefab;
        
        public void SpawnReward(GameObject spawnRequester)
        {
            // var itemPosition = GetRandomRewardSpawnPosition(spawnRequester.transform.position);
            // Instantiate(rewardPrefab, itemPosition, Quaternion.Euler(-90,0,0));
            InstantiateOnNavMesh(spawnRequester.transform.position);
        }

        private Vector3 GetRandomRewardSpawnPosition(Vector3 spawnRequester)
        {
            var tempPosition = Random.insideUnitCircle.normalized * 3;
            var xPos = spawnRequester.x + tempPosition.x;
            var yPos = spawnRequester.y + 1f;
            var zPos = spawnRequester.z + tempPosition.y;
            return new Vector3(xPos, yPos, zPos);
        }

        private void InstantiateOnNavMesh(Vector3 spawnRequester)
        {
            var failedPositions = 0;
            while (failedPositions < 50)
            {
                var randomSpawnPosition = GetRandomRewardSpawnPosition(spawnRequester);
                const int areaMask = NavMesh.AllAreas;
                
                var spawnLocationOnNavMesh = 
                    NavMesh.SamplePosition(randomSpawnPosition, out var hit, 1f, areaMask);

                if (spawnLocationOnNavMesh)
                {
                    var yOffset = new Vector3(0, 0.7f, 0);
                    Instantiate(rewardPrefab, hit.position + yOffset, Quaternion.Euler(-90,0,0));
                    return;
                }
                
                failedPositions++;
            }
            
            Debug.Log("Could not find a valid spawn position for reward");
        }
    }
}