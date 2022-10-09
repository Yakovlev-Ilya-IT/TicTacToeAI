using System;
using Zenject;

public class Game: IInitializable, IDisposable
{
    private ICellSelectionHandler _cellSelectionHandler;
    private IGameBoard _gameBoard;
    private IGameBehaviour _gameBehaviour;

    public IGameBoard GameBoard => _gameBoard;

    public Game(IGameBoard gameBoard, ICellSelectionHandler cellSelectionHandler)
    {
        _cellSelectionHandler = cellSelectionHandler;
        _gameBoard = gameBoard;

        _gameBoard.Build();
    }

    public void Initialize()
    {
        _cellSelectionHandler.CellSelected += OnCellSelected; 
    }

    public void Dispose()
    {
        _cellSelectionHandler.CellSelected -= OnCellSelected;
    }

    public void StartGame(IGameBehaviour gameBehaviour)
    {
        Clear();
        _gameBehaviour = gameBehaviour;
        _gameBehaviour.Launch();
    }

    private void Clear()
    {
        _gameBoard.Clear();
    }

    private void OnCellSelected(ISelectableCell cell)
    {
        _gameBehaviour.CurrentState.OnCellSelected(cell);
    }
}
