using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameBoard _board;
    [SerializeField] GameBoardData _data;

    public void Start()
    {
        _board.Initialize(_data);
    }
}
