using System;
using UnityEngine;

[Serializable]
public class GameBoardConfig
{
    [SerializeField] private int _boardSize;

    public int BoardSize => _boardSize;
}
