using System.Collections.Generic;

public class PlayerVsCPUGameBehaviour : GameBehaviour
{
    public PlayerVsCPUGameBehaviour(IGameBoard gameBoard, ICellTagger cellTagger, VictoryHandler victoryHandler, AIAgent agent)
    {
        _states = new List<IState>
        {
            new PlayerTurnState(this, cellTagger, MarkType.Cross, new CounterCellsMarkedPlayer(gameBoard.BoardSize), victoryHandler),
            new CPUTurnState(this, cellTagger, agent, gameBoard.Cells, MarkType.Zero, new CounterCellsMarkedPlayer(gameBoard.BoardSize), victoryHandler),
            new PlayerVsCPUResultState(victoryHandler)
        };

        _currentState = _states[0];
    }
}
