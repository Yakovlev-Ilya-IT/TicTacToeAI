using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private CellView _view;

    public float Size => _view.Size;
}
