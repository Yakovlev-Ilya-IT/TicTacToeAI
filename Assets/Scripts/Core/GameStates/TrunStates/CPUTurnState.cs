public class CPUTurnState : TurnState
{
    private AIAgent _agent;
    private ISelectableCell[] _boardCells;

    public CPUTurnState(IStationStateSwitcher stateSwitcher, ICellTagger cellTagger, AIAgent agent, ISelectableCell[] boardCells, MarkType mark, CounterCellsMarkedPlayer counterCellsMarkedPlayer, VictoryHandler winChecker) : base(stateSwitcher, cellTagger, mark, counterCellsMarkedPlayer, winChecker)
    {
        _agent = agent;
        _boardCells = boardCells;
    }

    public override void Enter()
    {
        float[] inputBoard = ConvertBoardToInputValues();

        int numberCellForMove = _agent.GetNumberCellForMove(inputBoard);

        MakeMove(_boardCells[numberCellForMove]);
    }

    public override void OnCellSelected(ISelectableCell cell) { }

    private float[] ConvertBoardToInputValues()
    {
        float[] inputValues = new float[_boardCells.Length  + 1];

        for (int i = 0; i < _boardCells.Length; i++)
        {
            if (_boardCells[i].Mark == _mark)
            {
                inputValues[i] = MarkTypeForAI.FriendlyMark;
                continue;
            }
            if(_boardCells[i].Mark == MarkType.Empty)
            {
                inputValues[i] = MarkTypeForAI.EmptyMark;
                continue;
            }

            inputValues[i] = MarkTypeForAI.EnemyMark;
        }

        if(_mark == MarkType.Cross)
        {
            inputValues[_boardCells.Length] = MarkTypeForAI.FriendlyMark;
        }
        else
        {
            inputValues[_boardCells.Length] = -MarkTypeForAI.FriendlyMark;
        }

        return inputValues;
    }

    protected override void FinishTurn()
    {
        _stateSwitcher.SwitchState<PlayerTurnState>();
    }

    protected override void GoToResult()
    {
        _stateSwitcher.SwitchState<PlayerVsCPUResultState>();
    }
}
