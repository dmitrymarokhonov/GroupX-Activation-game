namespace Relanima.Happiness
{
    public interface IHappinessState
    {
        void Click(IHappinessContext context);
        void Tick(IHappinessContext context);
    }
}