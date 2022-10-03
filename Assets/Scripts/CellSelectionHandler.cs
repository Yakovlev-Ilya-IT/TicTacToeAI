using System;
using UnityEngine;
using Zenject;

public class CellSelectionHandler: ICellSelectionHandler, IInitializable, IDisposable
{
    private IInput _input;
    private Camera _camera;

    public event Action<Cell> CellSelected;

    [Inject]
    public void Construct(IInput input)
    {
        _input = input;
        _camera = Camera.main;
    }

    public void Initialize()
    {
        _input.ClickDown += OnClickDown;
    }

    public void Dispose()
    {
        _input.ClickDown -= OnClickDown;
    }

    private void OnClickDown(Vector3 clickPosition)
    {
        Ray ray = _camera.ScreenPointToRay(clickPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.TryGetComponent(out Cell cell))
            {
                if (cell.Mark == MarkType.Empty)
                    CellSelected?.Invoke(cell);
                //иначе покажи что клетка уже занята
            }
        }
    }
}
