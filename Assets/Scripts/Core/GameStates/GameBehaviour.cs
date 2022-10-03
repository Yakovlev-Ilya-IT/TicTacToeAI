using System.Collections.Generic;
using System.Linq;
using Zenject;
using System;

public class GameBehaviour : IStationStateSwitcher, IInitializable, IDisposable
{
    private List<IState> _states;
    private IState _currentState;

    private ICellSelectionHandler _cellSelectionHandler;
    private GameBoard _gameBoard;

    public GameBehaviour(GameBoard gameBoard, ICellSelectionHandler cellSelectionHandler)
    {
        _cellSelectionHandler = cellSelectionHandler;
        _gameBoard = gameBoard;
        _gameBoard.Build();

        WinChecker winChecker = new WinChecker(_gameBoard.BoardSize);

        _states = new List<IState>()
        {
            new FirstPlayerTurnState(this, MarkType.Cross, new CounterCellsMarkedPlayer(_gameBoard.BoardSize), winChecker),
            new SecondPlayerTurnState(this, MarkType.Zero, new CounterCellsMarkedPlayer(_gameBoard.BoardSize), winChecker)
        };

        _currentState = _states[0];
    }

    public void Initialize()
    {
        _cellSelectionHandler.CellSelected += OnCellSelected;
    }

    public void Dispose()
    {
        _cellSelectionHandler.CellSelected -= OnCellSelected;
    }

    private void OnCellSelected(Cell cell)
    {
        _currentState.MakeMove(cell);
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(s => s is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
}
