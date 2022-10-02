using System;
using UnityEngine;

[Serializable]
public class GameBoardData
{
    [SerializeField] private int _boardSize;

    public int BoardSize => _boardSize;
}
