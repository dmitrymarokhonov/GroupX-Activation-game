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
            _happinessManager.happySliderBar.useGradient = true;
        }

        public void Unhappy(IHappinessContext context)
        {
            context.SetState(new UnhappyState(_happinessManager));
        }

        public void Happy(IHappinessContext context)
        {
            _happinessManager.AddHappiness();
        }

        public void Draining(IHappinessContext context)
        {
            _happinessManager.currentHappiness -= Time.deltaTime * DrainModifier;
            _happinessManager.UpdateSliderBar();
            
            if (_happinessManager.currentHappiness <= 0)
            {
                Unhappy(context);
            }
        }
    }
}