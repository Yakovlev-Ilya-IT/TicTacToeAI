public class SecondPlayerTurnState : PlayerTurnState
{
    public SecondPlayerTurnState(IStationStateSwitcher stateSwitcher, MarkType mark, CounterCellsMarkedPlayer counterCellsMarkedPlayer, WinChecker winChecker) : base(stateSwitcher, mark, counterCellsMarkedPlayer, winChecker)
    {
    }

    protected override void FinishTurn()
    {
        _stateSwitcher.SwitchState<FirstPlayerTurnState>();
    }
}
