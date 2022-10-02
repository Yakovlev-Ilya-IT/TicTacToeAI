using System;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] Cell _cellPrefab;
    private Cell[] _cells;

    public Cell[] Cells => _cells;

    private GameBoardData _data;
    private int BoardSize => _data.BoardSize;
    private float CellSize => _cellPrefab.Size;
    private float Offset => (BoardSize*CellSize - CellSize) * 0.5f;

    public void Initialize(GameBoardData gameBoardData)
    {
        _data = gameBoardData;

        Build();
    }

    private void Build()
    {
        _cells = new Cell[BoardSize];
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                _cells[i] = Instantiate(_cellPrefab, new Vector3(i * CellSize - Offset, 0, j * CellSize - Offset), Quaternion.identity, transform);
            }
        }
    }
}
