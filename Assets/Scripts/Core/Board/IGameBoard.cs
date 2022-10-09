public interface IGameBoard
{
    public int BoardSize { get; }
    public Cell[] Cells { get; }
    public void Build();
    public void Clear();
}