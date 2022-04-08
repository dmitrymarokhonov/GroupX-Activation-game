using Relanima.Rewards;
using UnityEngine;

namespace Relanima.Happiness
{
    public class DrainingState : IHappinessState
    {
        private readonly HappinessManager _happinessManager;
        private const float DrainModifier = 0.2f;

        public DrainingState(HappinessManager happinessManager)
        {
            _happinessManager = happinessManager;
            _happinessManager.happySliderBar.UseGradient();
            
            _happinessManager.InvokeRepeating(nameof(_happinessManager.TrySpawnReward), 1.0f, 3.0f);
        }

        public void Click(IHappinessContext context)
        {
            _happinessManager.AddHappiness();
        }
        
        public void Tick(IHappinessContext context)
        {
            _happinessManager.currentHappiness -= Time.deltaTime * DrainModifier;
            _happinessManager.UpdateSliderBar();
            
            if (_happinessManager.currentHappiness <= 0)
            {
                Exit(context);
            }
        }

        private void Exit(IHappinessContext context)
        {
            _happinessManager.CancelInvoke(nameof(_happinessManager.TrySpawnReward));
            context.SetState(new UnhappyState(_happinessManager));
        }
    }
}