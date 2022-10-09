public class FirstPlayerTurnState : PlayerTurnState
{
    public FirstPlayerTurnState(IStationStateSwitcher stateSwitcher, ICellTagger cellTagger, MarkType mark, CounterCellsMarkedPlayer counterCellsMarkedPlayer, VictoryHandler winChecker) : base(stateSwitcher, cellTagger, mark, counterCellsMarkedPlayer, winChecker)
    {
    }

    protected override void FinishTurn()
    {
        _stateSwitcher.SwitchState<SecondPlayerTurnState>();
    }
}
