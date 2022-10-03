using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private CellView _view;

    private int _row;
    private int _column;
    private MarkType _mark;

    public float Size => _view.Size;
    public int Row => _row;
    public int Column => _column;
    public MarkType Mark => _mark;

    public void Initialize(int row, int column)
    {
        _row = row;
        _column = column;
        _mark = MarkType.Empty;
        _view.Initialize();
    }

    public bool TrySetMark(MarkType mark)
    {
        if (_mark != MarkType.Empty)
            return false;
        
        _mark = mark;
        _view.SetMark(mark);

        return true;
    }
}
