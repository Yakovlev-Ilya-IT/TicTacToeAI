using System.Threading;

public class FirstCPUTurnState : CPUTurnState
{
    public FirstCPUTurnState(IStationStateSwitcher stateSwitcher, ICellTagger cellTagger, AIAgent agent, ISelectableCell[] boardCells, MarkType mark, CounterCellsMarkedPlayer counterCellsMarkedPlayer, VictoryHandler winChecker) : base(stateSwitcher, cellTagger, agent, boardCells, mark, counterCellsMarkedPlayer, winChecker)
    {
    }

    protected override void FinishTurn()
    {
        _stateSwitcher.SwitchState<SecondCPUTurnState>();
    }

    protected override void GoToResult()
    {
        _stateSwitcher.SwitchState<CPUVsCPUResultState>();
    }
}
