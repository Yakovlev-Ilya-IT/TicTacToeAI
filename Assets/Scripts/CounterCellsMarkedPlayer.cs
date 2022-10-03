public class CounterCellsMarkedPlayer 
{
    private int[] _numberMarkedCellsInRow;
    private int[] _numberMarkedCellsInColumn;
    private int _numberMarkedCellsInMainDiagonal;
    private int _numberMarkedCellsInReverseDiagonal;

    private int _gridSize;

    public int[] NumberMarkedCellsInRow => _numberMarkedCellsInRow;
    public int[] NumberMarkedCellsInColumn => _numberMarkedCellsInColumn;
    public int NumberMarkedCellsInMainDiagonal => _numberMarkedCellsInMainDiagonal;
    public int NumberMarkedCellsInReverseDiagonal => _numberMarkedCellsInReverseDiagonal;

    public CounterCellsMarkedPlayer(int GridSize)
    {
        _gridSize = GridSize;
        _numberMarkedCellsInRow = new int[GridSize];
        _numberMarkedCellsInColumn = new int[GridSize];
    }

    public void Count(int rowNumber, int columnNumber)
    {
        _numberMarkedCellsInRow[rowNumber]++;
        _numberMarkedCellsInColumn[columnNumber]++;

        if(rowNumber == columnNumber)
            _numberMarkedCellsInMainDiagonal++;

        if(rowNumber + columnNumber == _gridSize - 1)
            _numberMarkedCellsInReverseDiagonal++;
    }

}
