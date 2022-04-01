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
        private AudioController _audioController;
        
        private void Start()
        {
            happySliderBar.SetMaxValue(maxHappiness);
            _currentState = new UnhappyState(this);
            _addition = maxHappiness / 8;
            _audioController = GameObject.Find("Main Camera").GetComponent<AudioController>();
        }

        private void Update()
        {
            Tick();
        }
        
        private void Tick() => _currentState.Tick(this);

        public void AddHappiness()
        {
            currentHappiness += _addition;
            
            if (currentHappiness > maxHappiness)
            {
                currentHappiness = maxHappiness;
            }
            
            UpdateSliderBar();
        }
        
        public void UpdateSliderBar()
        {
            if (happySliderBar == null) return;
            happySliderBar.SetValue(currentHappiness);
        }
        
        public void TrySpawnReward()
        {
            var lowerBoundary = maxHappiness / 2;
            var upperBoundary = maxHappiness * 1.2f;
            var randomValue = Random.Range(lowerBoundary, upperBoundary);
            
            if (currentHappiness < randomValue) return;
            
            RewardManager.SpawnReward(gameObject);
        }
        
        private void OnMouseDown()
        {
            Click();
            HandleClickParticle();
            HandleClickAudioEffect();
        }

        private void Click() => _currentState.Click(this);

        private void HandleClickParticle()
        {
            if (clickParticle == null) return;
            
            var particlePosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            Instantiate(clickParticle, particlePosition, clickParticle.transform.rotation);
        }

        private void HandleClickAudioEffect() => _audioController.PlayClip(GetNormalizedHappiness());
        
        private float GetNormalizedHappiness() => currentHappiness / maxHappiness;

        void IHappinessContext.SetState(IHappinessState newState)
        {
            _currentState = newState;
        }
    }
}