using Relanima.GameManager;
using TMPro;
using UnityEngine;

namespace Relanima.Rewards
{
    public class RewardManager : MonoBehaviour
    {
        public TextMeshProUGUI rewardDisplay;
        
        // private static int _rewardsCollected;
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
            GameManagerElement.instance.AddScore();
            _totalRewardsSpawned--;
            UpdateRewardDisplay();
        }

        public static void SpawnReward(GameObject spawnRequester)
        {
            if (_totalRewardsSpawned >= MaxRewardsOnField) return;
            
            _rewardSpawner.SpawnReward(spawnRequester);
            _totalRewardsSpawned++;
        }

        public void ReduceRewardsBy(int amount)
        {
            GameManagerElement.instance.ReduceRewardsBy(amount);
            
            if (GameManagerElement.instance.GetScore() < 0)
                GameManagerElement.instance.SetScore(0); 
            
            UpdateRewardDisplay();
        }
        
        private void UpdateRewardDisplay()
        {
            rewardDisplay.text = GameManagerElement.instance.GetScore().ToString();
        }
    }
}
