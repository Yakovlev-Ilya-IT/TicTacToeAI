using System;

public interface ICellSelectionHandler
{
    public event Action<ISelectableCell> CellSelected;
}
