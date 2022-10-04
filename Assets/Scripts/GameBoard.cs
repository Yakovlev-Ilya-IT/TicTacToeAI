using UnityEngine;
using Zenject;

public class GameBoard : MonoBehaviour
{
    [SerializeField] Cell _cellPrefab;
    private Cell[] _cells;

    public Cell[] Cells => _cells;

    private GameBoardConfig _data;
    public int BoardSize => _data.BoardSize;
    private float CellSize => _cellPrefab.Size;
    private float Offset => (BoardSize*CellSize - CellSize) * 0.5f;

    [Inject]
    public void Construct(GameBoardConfig gameBoardData)
    {
        _data = gameBoardData;
    }

    public void Build()
    {
        _cells = new Cell[BoardSize];
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                _cells[i] = Instantiate(_cellPrefab, new Vector3(i * CellSize - Offset, 0, j * CellSize - Offset), Quaternion.identity, transform);
                _cells[i].Initialize(i, j);
            }
        }
    }
}
