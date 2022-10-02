using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] private CellBaseView _base;

    public float Size => _base.Size;
}
