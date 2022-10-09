public interface ICellTagger
{
    public bool TryMarkCell(int cellNumberOnBoard, MarkType mark);
    public int NumberMarkedCells { get; }
}