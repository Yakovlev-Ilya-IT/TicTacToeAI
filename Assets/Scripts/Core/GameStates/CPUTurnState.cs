
using UnityEngine;

public class CPUTurnState : IState
{
    protected IStationStateSwitcher _stateSwitcher;
    private AIAgent _agent;
    private Cell[] _boardCells;
    private MarkType _mark;
    private CounterCellsMarkedPlayer _counterCellsMarkedPlayer;
    private WinChecker _winChecker;

    public CPUTurnState(IStationStateSwitcher stateSwitcher, AIAgent agent, Cell[] boardCells, MarkType mark, CounterCellsMarkedPlayer counterCellsMarkedPlayer, WinChecker winChecker)
    {
        _stateSwitcher = stateSwitcher;
        _agent = agent;
        _boardCells = boardCells;
        _mark = mark;
        _counterCellsMarkedPlayer = counterCellsMarkedPlayer;
        _winChecker = winChecker;
    }

    public void Enter()
    {
        float[] inputBoard = ConvertBoardToInputValues();

        int numberCellForMove = _agent.GetNumberCellForMove(inputBoard);

        _boardCells[numberCellForMove].TrySetMark(_mark);

        if (_boardCells[numberCellForMove].TrySetMark(_mark))
        {
            _counterCellsMarkedPlayer.Count(_boardCells[numberCellForMove].Row, _boardCells[numberCellForMove].Column);

            if (_winChecker.Check(_counterCellsMarkedPlayer))
            {
                Debug.Log("Победа компьютера");
                //Переход в состояние победы
            }
        }

        FinishTurn();

        //предупрждение о том что клетка занята
    }

    public void Exit()
    {
    }

    public void MakeMove(Cell cell) { }

    private float[] ConvertBoardToInputValues()
    {
        float[] inputValues = new float[_boardCells.Length];

        for (int i = 0; i < _boardCells.Length; i++)
        {
            if (_boardCells[i].Mark == _mark)
            {
                inputValues[i] = MarkTypeForAI.FriendlyMark;
                continue;
            }
            if(_boardCells[i].Mark == MarkType.Empty)
            {
                inputValues[i] = MarkTypeForAI.EmptyMark;
                continue;
            }

            inputValues[i] = MarkTypeForAI.EnemyMark;
        }

        return inputValues;
    }

    protected virtual void FinishTurn()
    {
        _stateSwitcher.SwitchState<PlayerTurnState>();
    }
}
