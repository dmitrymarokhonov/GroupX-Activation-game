namespace Relanima.Happiness
{
    public class UnhappyState : IHappinessState
    {
        private readonly HappinessManager _happinessManager;

        public UnhappyState(HappinessManager happinessManager)
        {
            _happinessManager = happinessManager;
            _happinessManager.happySliderBar.gameObject.SetActive(false);
            _happinessManager.unhappyImage.gameObject.SetActive(true);
            _happinessManager.happySliderBar.useGradient = false;
            _happinessManager.happySliderBar.SetGreen();
        }

        public void Unhappy(IHappinessContext context)
        {
        }

        public void Happy(IHappinessContext context)
        {
            _happinessManager.AddHappiness();
            context.SetState(new HappyState(_happinessManager));
        }

        public void Draining(IHappinessContext context)
        {
        }
    }
}