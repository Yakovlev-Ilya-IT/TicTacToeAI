using System;
using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] private CellBaseView _base;
    [SerializeField] private GameObject _cross;
    [SerializeField] private GameObject _zero;


    public float Size => _base.Size;

    public void Initialize()
    {
        SetMark(MarkType.Empty);
    }

    public void SetMark(MarkType mark)
    {
        switch (mark)
        {
            case MarkType.Empty:
                _cross.SetActive(false);
                _zero.SetActive(false);
                break;
            case MarkType.Cross:
                _cross.SetActive(true);
                break;
            case MarkType.Zero:
                _zero.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void Clear()
    {
        SetMark(MarkType.Empty);
    }
}
