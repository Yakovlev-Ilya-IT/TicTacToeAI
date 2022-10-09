public class VictoryHandler
{
    private int _markedCellsNumberInRowToWin;
    private GameResults _result;

    public GameResults Result => _result;
    public int MarkedCellsNumberForDraw => _markedCellsNumberInRowToWin * _markedCellsNumberInRowToWin;

    public VictoryHandler(int markedCellsNumberInRowToWin)
    {
        _markedCellsNumberInRowToWin = markedCellsNumberInRowToWin;
    }

    public bool CheckWin(CounterCellsMarkedPlayer counter)
    {
        if(CheckLines(counter.NumberMarkedCellsInRow))
            return true;
        if(CheckLines(counter.NumberMarkedCellsInColumn))
            return true;
        if(CheckDiagonal(counter.NumberMarkedCellsInMainDiagonal))
            return true;
        if (CheckDiagonal(counter.NumberMarkedCellsInReverseDiagonal))
            return true;

        return false;
    }

    public void SetResult(GameResults result)
    {
        _result = result;
    }

    private bool CheckDiagonal(int numberMarkedCellsInDiagonal) => numberMarkedCellsInDiagonal >= _markedCellsNumberInRowToWin;

    private bool CheckLines(int[] numberMarkedCellsInLine)
    {
        for (int i = 0; i < numberMarkedCellsInLine.Length; i++)
        {
            if(numberMarkedCellsInLine[i] >= _markedCellsNumberInRowToWin)
                return true;
        }

        return false;
    }
}
