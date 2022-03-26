namespace Relanima.Happiness
{
    public class HappyState : IHappinessState
    {
        private readonly HappinessManager _happinessManager;

        public HappyState(HappinessManager happinessManager)
        {
            _happinessManager = happinessManager;
            _happinessManager.unhappyImage.gameObject.SetActive(false);
            _happinessManager.happySliderBar.gameObject.SetActive(true);
        }

        public void Unhappy(IHappinessContext context)
        {
        }

        public void Happy(IHappinessContext context)
        {
            _happinessManager.AddHappiness();
            
            if (_happinessManager.currentHappiness >= _happinessManager.maxHappiness)
            {
                Draining(context);
            }
        }

        public void Draining(IHappinessContext context)
        {
            if (_happinessManager.GetNormalizedHappiness() < 1) return;
            context.SetState(new DrainingState(_happinessManager));
        }
    }
}