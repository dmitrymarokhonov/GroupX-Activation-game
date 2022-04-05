namespace Relanima.Happiness
{
    public class UnhappyState : IHappinessState
    {
        private readonly HappinessManager _happinessManager;

        public UnhappyState(HappinessManager happinessManager)
        {
            _happinessManager = happinessManager;
            _happinessManager.happySliderBar.Reset();
            _happinessManager.unhappyImage.gameObject.SetActive(true);
        }

        public void Click(IHappinessContext context)
        {
            _happinessManager.AddHappiness();
            Exit(context);
        }

        public void Tick(IHappinessContext context)
        {
        }

        private void Exit(IHappinessContext context)
        {
            _happinessManager.unhappyImage.gameObject.SetActive(false);
            context.SetState(new HappinessIncreasingState(_happinessManager));
        }
    }
}