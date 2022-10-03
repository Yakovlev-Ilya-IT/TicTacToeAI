using System;

public interface ICellSelectionHandler
{
    public event Action<Cell> CellSelected;
}
