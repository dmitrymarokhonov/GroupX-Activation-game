using UnityEngine;

namespace Relanima.Rewards
{
    public class RewardSpawner : MonoBehaviour
    {
        public GameObject rewardPrefab;
        
        public void SpawnReward(GameObject spawnRequester)
        {
            var itemPosition = GetRandomRewardSpawnPosition(spawnRequester.transform.position);
            Instantiate(rewardPrefab, itemPosition, Quaternion.Euler(-90,0,0));
        }

        private Vector3 GetRandomRewardSpawnPosition(Vector3 spawnRequester)
        {
            var tempPosition = Random.insideUnitCircle.normalized * 3;
            var xPos = spawnRequester.x + tempPosition.x;
            var yPos = spawnRequester.y + 1f;
            var zPos = spawnRequester.z + tempPosition.y;
            return new Vector3(xPos, yPos, zPos);
        }
    }
}