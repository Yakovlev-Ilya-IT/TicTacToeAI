using UnityEngine;
using Zenject;

public class GameBoard : MonoBehaviour, IGameBoard, ICellTagger
{
    [SerializeField] Cell _cellPrefab;
    private Cell[] _cells;
    private int _numberMarkedCells;

    public Cell[] Cells => _cells;

    private GameBoardConfig _data;
    public int BoardSize => _data.BoardSize;
    private float CellSize => _cellPrefab.Size;
    private float Offset => (BoardSize*CellSize - CellSize) * 0.5f;

    public int NumberMarkedCells => _numberMarkedCells;

    [Inject]
    public void Construct(GameBoardConfig gameBoardData)
    {
        _data = gameBoardData;
    }

    public void Build()
    {
        _cells = new Cell[BoardSize * BoardSize];

        int cellNumberOnBoard = 0;
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                _cells[cellNumberOnBoard] = Instantiate(_cellPrefab, new Vector3(i * CellSize - Offset, 0, j * CellSize - Offset), Quaternion.identity, transform);
                _cells[cellNumberOnBoard].Initialize(i, j, cellNumberOnBoard);
                cellNumberOnBoard++;
            }
        }
    }

    public void Clear()
    {
        _numberMarkedCells = 0;
        foreach (var cell in _cells)
            cell.Clear();
    }

    public bool TryMarkCell(int cellNumberOnBoard, MarkType mark)
    {
        if (_cells[cellNumberOnBoard].TrySetMark(mark))
        {
            _numberMarkedCells++;
            return true;
        }
        return false;
    }
}
