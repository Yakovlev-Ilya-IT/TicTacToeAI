public interface IGameBehaviour : IStationStateSwitcher
{
    public IState CurrentState { get; }
    public void Launch();
}
