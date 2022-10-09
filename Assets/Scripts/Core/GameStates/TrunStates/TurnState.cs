using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnState : IState
{
    protected IStationStateSwitcher _stateSwitcher;
    protected ICellTagger _cellTagger;

    protected CounterCellsMarkedPlayer _counterCellsMarkedPlayer;
    protected VictoryHandler _victoryHandler;

    protected MarkType _mark;

    public TurnState(IStationStateSwitcher stateSwitcher, ICellTagger cellTagger, MarkType mark, CounterCellsMarkedPlayer counterCellsMarkedPlayer, VictoryHandler victoryHandler)
    {
        _stateSwitcher = stateSwitcher;
        _cellTagger = cellTagger;
        _mark = mark;
        _counterCellsMarkedPlayer = counterCellsMarkedPlayer;
        _victoryHandler = victoryHandler;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void OnCellSelected(ISelectableCell cell)
    {
        MakeMove(cell);
    }

    protected virtual void MakeMove(ISelectableCell cell)
    {
        if (_cellTagger.TryMarkCell(cell.NumberOnBoard, _mark))
        {
            _counterCellsMarkedPlayer.Count(cell.Row, cell.Column);

            if (_victoryHandler.CheckWin(_counterCellsMarkedPlayer))
            {
                SetWinner();
                GoToResult();
                return;
            }

            if(_cellTagger.NumberMarkedCells == _victoryHandler.MarkedCellsNumberForDraw)
            {
                _victoryHandler.SetResult(GameResults.Draw);
                GoToResult();
                return;
            }
        }

        FinishTurn();
    }

    protected void SetWinner()
    {
        switch (_mark)
        {
            case MarkType.Cross:
                _victoryHandler.SetResult(GameResults.CrossWin);
                break;
            case MarkType.Zero:
                _victoryHandler.SetResult(GameResults.ZeroWin);
                break;
            default:
                Debug.LogError("mark is empty");
                _victoryHandler.SetResult(GameResults.Draw);
                break;
        }
    }

    protected virtual void GoToResult()
    {
        _stateSwitcher.SwitchState<CPUVsCPUResultState>();
    }

    protected abstract void FinishTurn();
}
