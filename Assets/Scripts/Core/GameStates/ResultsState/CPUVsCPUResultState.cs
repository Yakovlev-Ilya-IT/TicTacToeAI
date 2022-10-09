using UnityEngine;

public class CPUVsCPUResultState : IState
{
    private AIAgent _crossAgent;
    private AIAgent _zeroAgent;

    private VictoryHandler _victoryHandler;

    public CPUVsCPUResultState(AIAgent crossAgent, AIAgent zeroAgent, VictoryHandler victoryHandler)
    {
        _crossAgent = crossAgent;
        _zeroAgent = zeroAgent;
        _victoryHandler = victoryHandler;
    }

    public void Enter()
    {
        switch (_victoryHandler.Result)
        {
            case GameResults.CrossWin:
                _crossAgent.IncreaseSuccessValue();
                _zeroAgent.ReduceSuccessValue();
                AIEventsHolder.SendGameEnded(_crossAgent);
                break;
            case GameResults.ZeroWin:
                _crossAgent.ReduceSuccessValue();
                _zeroAgent.IncreaseSuccessValue();
                AIEventsHolder.SendGameEnded(_zeroAgent);
                break;
            default:
                _crossAgent.IncreaseDraw();
                _zeroAgent.IncreaseDraw();
                AIEventsHolder.SendGameEnded(GetRandomAgent());
                break;
        }
    }

    private AIAgent GetRandomAgent()
    {
        return Random.Range(0, 2) == 0 ? _crossAgent : _zeroAgent;
    }

    public void Exit() { }

    public void OnCellSelected(ISelectableCell cell) { }
}
