using Relanima.Rewards;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima.Happiness
{
    public class HappinessManager : MonoBehaviour, IHappinessContext
    {
        public float currentHappiness;
        public float maxHappiness;
        public ParticleSystem clickParticle;
        public Image unhappyImage;
        public SliderBar happySliderBar;

        private float _addition;
        private IHappinessState _currentState;

        #region Unity Event Functions
        
        private void Start()
        {
            _currentState = new UnhappyState(this);
            happySliderBar.SetMaxValue(maxHappiness);
            _addition = maxHappiness / 8;
            InvokeRepeating(nameof(TrySpawnReward), 1.0f, 3.0f);
        }

        private void Update()
        {
            _currentState.Draining(this);
        }
        
        #endregion
        
        public float GetNormalizedHappiness()
        {
            return currentHappiness / maxHappiness;
        }

        public void UpdateSliderBar()
        {
            if (happySliderBar == null) return;
            happySliderBar.SetValue(currentHappiness);
        }

        public void AddHappiness()
        {
            currentHappiness += _addition;
            
            if (currentHappiness > maxHappiness)
            {
                currentHappiness = maxHappiness;
            }
            
            UpdateSliderBar();
        }

        private void HandleClickParticle()
        {
            if (clickParticle == null) return;
            
            var particlePosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            Instantiate(clickParticle, particlePosition, clickParticle.transform.rotation);
        }
        
        private void OnMouseDown()
        {
            Happy();
            HandleClickParticle();
        }

        private void TrySpawnReward()
        {
            // Very, very bad
            if (_currentState.GetType() != typeof(DrainingState)) return;

            var randomValue = Random.Range(maxHappiness / 2, maxHappiness * 1.2f);
            if (currentHappiness < randomValue) return;

            RewardManager.SpawnReward(gameObject);
        }
        
        #region State Specific Behaviour

        public void Unhappy() => _currentState.Unhappy(this);
        
        public void Happy() => _currentState.Happy(this);
        
        public void Draining() => _currentState.Draining(this);
        
        void IHappinessContext.SetState(IHappinessState newState)
        {
            _currentState = newState;
        }

        #endregion
    }
}