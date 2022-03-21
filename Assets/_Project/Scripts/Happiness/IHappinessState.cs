namespace Relanima.Happiness
{
    public interface IHappinessState
    {
        void Unhappy(IHappinessContext context);
        void Happy(IHappinessContext context);
        void Draining(IHappinessContext context);
    }
}