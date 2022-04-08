using TMPro;
using UnityEngine;

namespace Relanima.Rewards
{
    public class RewardManager : MonoBehaviour
    {
        public TextMeshProUGUI rewardDisplay;
        
        private static int _rewardsCollected;
        private static int _totalRewardsSpawned;
        private const int MaxRewardsOnField = 50;
        private static RewardSpawner _rewardSpawner;
        // private RewardCollector _rewardCollector;

        public static RewardManager instance;

        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        private void Start()
        {
            _rewardSpawner = GetComponent<RewardSpawner>();
        }

        public void CollectReward()
        {
            _rewardsCollected++;
            _totalRewardsSpawned--;
            UpdateRewardDisplay();
        }

        public static void SpawnReward(GameObject spawnRequester)
        {
            if (_totalRewardsSpawned >= MaxRewardsOnField) return;
            
            _rewardSpawner.SpawnReward(spawnRequester);
            _totalRewardsSpawned++;
        }

        private void UpdateRewardDisplay()
        {
            rewardDisplay.text = _rewardsCollected.ToString();
        }
    }
}
