namespace Relanima.Happiness
{
    public class HappinessIncreasingState : IHappinessState
    {
        private readonly HappinessManager _happinessManager;

        public HappinessIncreasingState(HappinessManager happinessManager)
        {
            _happinessManager = happinessManager;
            _happinessManager.happySliderBar.gameObject.SetActive(true);
        }

        public void Click(IHappinessContext context)
        {
            _happinessManager.AddHappiness();
            
            if (_happinessManager.currentHappiness >= _happinessManager.maxHappiness)
            {
                Exit(context);
            }
        }

        public void Tick(IHappinessContext context)
        {
        }

        private void Exit(IHappinessContext context)
        {
            context.SetState(new DrainingState(_happinessManager));
        }
    }
}