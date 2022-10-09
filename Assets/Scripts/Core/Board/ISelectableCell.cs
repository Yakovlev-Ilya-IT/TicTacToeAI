public interface ISelectableCell
{
    public int NumberOnBoard { get; }
    public int Row { get; }
    public int Column { get; }
    public MarkType Mark { get; }
}