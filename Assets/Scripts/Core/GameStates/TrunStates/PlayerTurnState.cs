using UnityEngine;

public class PlayerTurnState : TurnState
{
    public PlayerTurnState(IStationStateSwitcher stateSwitcher, ICellTagger cellTagger, MarkType mark, CounterCellsMarkedPlayer counterCellsMarkedPlayer, VictoryHandler winChecker) : base(stateSwitcher, cellTagger, mark, counterCellsMarkedPlayer, winChecker)
    {
    }

    protected override void FinishTurn()
    {
        _stateSwitcher.SwitchState<CPUTurnState>();
    }

    protected override void GoToResult()
    {
        _stateSwitcher.SwitchState<PlayerVsCPUResultState>();
    }
}
