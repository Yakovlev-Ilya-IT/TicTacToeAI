using System.Threading;

public class SecondCPUTurnState : CPUTurnState
{
    public SecondCPUTurnState(IStationStateSwitcher stateSwitcher, ICellTagger cellTagger, AIAgent agent, ISelectableCell[] boardCells, MarkType mark, CounterCellsMarkedPlayer counterCellsMarkedPlayer, VictoryHandler winChecker) : base(stateSwitcher, cellTagger, agent, boardCells, mark, counterCellsMarkedPlayer, winChecker)
    {
    }

    protected override void FinishTurn()
    {
        _stateSwitcher.SwitchState<FirstCPUTurnState>();
    }

    protected override void GoToResult()
    {
        _stateSwitcher.SwitchState<CPUVsCPUResultState>();
    }
}
