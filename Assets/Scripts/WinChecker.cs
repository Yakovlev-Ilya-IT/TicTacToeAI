public class WinChecker
{
    private int _markedCellsNumberInRowToWin;

    public WinChecker(int markedCellsNumberInRowToWin)
    {
        _markedCellsNumberInRowToWin = markedCellsNumberInRowToWin;
    }

    public bool Check(CounterCellsMarkedPlayer counter)
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
