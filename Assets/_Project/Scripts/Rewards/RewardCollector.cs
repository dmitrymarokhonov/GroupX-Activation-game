using UnityEngine;

namespace Relanima.Rewards
{
    public class RewardCollector : MonoBehaviour
    {
        public ParticleSystem collectParticle;

        private void CollectReward()
        {
            var rewardPosition = transform.position;
            var particlePosition = new Vector3(rewardPosition.x, rewardPosition.y + 3, rewardPosition.z); 
            Instantiate(collectParticle, particlePosition, collectParticle.transform.rotation);
            RewardManager.instance.CollectReward();
            Destroy(gameObject);
        }

        private void OnMouseDown()
        {
            CollectReward();
        }
    }
}