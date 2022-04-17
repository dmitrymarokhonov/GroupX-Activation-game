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

        public static int RewardCount()
        {
            return _rewardsCollected;
        }

        public void SetRewardCollected(int amount)
        {
            _rewardsCollected = amount;
            UpdateRewardDisplay();
        }

        public void ReduceRewardsBy(int amount)
        {
            _rewardsCollected -= amount;
            if (_rewardsCollected < 0)
                _rewardsCollected = 0;
            
            UpdateRewardDisplay();
        }
        
        private void UpdateRewardDisplay()
        {
            rewardDisplay.text = _rewardsCollected.ToString();
        }
    }
}
