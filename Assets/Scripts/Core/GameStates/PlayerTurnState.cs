using UnityEngine;

public class PlayerTurnState : IState
{
    protected IStationStateSwitcher _stateSwitcher;
    private MarkType _mark;
    private CounterCellsMarkedPlayer _counterCellsMarkedPlayer;
    private WinChecker _winChecker;

    public PlayerTurnState(IStationStateSwitcher stateSwitcher, MarkType mark, CounterCellsMarkedPlayer counterCellsMarkedPlayer, WinChecker winChecker)
    {
        _stateSwitcher = stateSwitcher;
        _mark = mark;
        _counterCellsMarkedPlayer = counterCellsMarkedPlayer;
        _winChecker = winChecker;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void MakeMove(Cell cell)
    {
        if (cell.TrySetMark(_mark))
        {
            _counterCellsMarkedPlayer.Count(cell.Row, cell.Column);

            if (_winChecker.Check(_counterCellsMarkedPlayer))
            {
                Debug.Log("Победа игрока");
                //Переход в состояние победы
            }
        }

        FinishTurn();

        //предупрждение о том что клетка занята
    }

    protected virtual void FinishTurn()
    {
        //передача хода компьютеру
    }
}
