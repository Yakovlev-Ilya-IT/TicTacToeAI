using System.Collections.Generic;

public class CPUVsCPUGameBehavior : GameBehaviour
{
    public CPUVsCPUGameBehavior(IGameBoard gameBoard, ICellTagger cellTagger, VictoryHandler victoryHandler, AIAgent firstAgent, AIAgent secondAgent)
    {
        _states = new List<IState>
        {
            new FirstCPUTurnState(this, cellTagger, firstAgent, gameBoard.Cells, MarkType.Cross, new CounterCellsMarkedPlayer(gameBoard.BoardSize), victoryHandler),
            new SecondCPUTurnState(this, cellTagger, secondAgent, gameBoard.Cells, MarkType.Zero, new CounterCellsMarkedPlayer(gameBoard.BoardSize), victoryHandler),
            new CPUVsCPUResultState(firstAgent, secondAgent, victoryHandler)
        };

        _currentState = _states[0];
    }
}
