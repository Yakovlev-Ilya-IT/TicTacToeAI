using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveResultChecker : MonoBehaviour
{
    private GameBoard _gameBoard;

    public MoveResultTypes Check()
    {
        return MoveResultTypes.Continue;
    }
}
