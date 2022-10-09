using UnityEngine;

public class PlayerVsCPUResultState : IState
{
    private VictoryHandler _victoryHandler;

    public PlayerVsCPUResultState(VictoryHandler victoryHandler)
    {
        _victoryHandler = victoryHandler;
    }

    public void Enter()
    {
        switch (_victoryHandler.Result)
        {
            case GameResults.CrossWin:
                Debug.Log("CrossWin");
                break;
            case GameResults.ZeroWin:
                Debug.Log("ZeroWin");
                break;
            default:
                Debug.Log("Draw");
                break;
        }
    }

    public void Exit() { }

    public void OnCellSelected(ISelectableCell cell) { }
}
