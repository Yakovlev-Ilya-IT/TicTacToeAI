public class FirstPlayerTurnState : PlayerTurnState
{
    public FirstPlayerTurnState(IStationStateSwitcher stateSwitcher, MarkType mark, CounterCellsMarkedPlayer counterCellsMarkedPlayer, WinChecker winChecker) : base(stateSwitcher, mark, counterCellsMarkedPlayer, winChecker)
    {
    }

    protected override void FinishTurn()
    {
        _stateSwitcher.SwitchState<SecondPlayerTurnState>();
    }
}
