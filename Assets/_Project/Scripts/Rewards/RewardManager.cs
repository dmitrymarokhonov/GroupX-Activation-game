using Relanima.GameManager;
using TMPro;
using UnityEngine;

namespace Relanima.Rewards
{
    public class RewardManager : MonoBehaviour
    {
        public static RewardManager instance;
        
        [SerializeField] private int maxRewardsOnField = 50;
        [SerializeField] private TextMeshProUGUI rewardDisplay;

        private static int _totalRewardsSpawned;
        private static RewardSpawner _rewardSpawner;

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
            if (_totalRewardsSpawned >= instance.maxRewardsOnField) return;
            
            _rewardSpawner.SpawnReward(spawnRequester);
            _totalRewardsSpawned++;
        }

        public void ReduceRewardsBy(int amount)
        {
            GameManagerElement.instance.ReduceRewardsBy(amount);
            
            if (GameManagerElement.instance.GetResources() < 0)
                GameManagerElement.instance.SetResources(0); 
            
            UpdateRewardDisplay();
        }
        
        private void UpdateRewardDisplay()
        {
            rewardDisplay.text = GameManagerElement.instance.GetResources().ToString();
        }
    }
}
