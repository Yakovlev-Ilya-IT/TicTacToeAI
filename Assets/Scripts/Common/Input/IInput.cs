using System;
using UnityEngine;

public interface IInput
{
    public event Action<Vector3> ClickDown;
    public event Action<Vector3> ClickUp;
    public event Action<Vector3> Move;
}

