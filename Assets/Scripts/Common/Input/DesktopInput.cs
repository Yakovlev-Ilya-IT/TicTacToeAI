using System;
using UnityEngine;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    public event Action<Vector3> ClickDown;
    public event Action<Vector3> ClickUp;
    public event Action<Vector3> Move;

    private const int LeftMouseButton = 0;

    public void Tick()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
            ClickDown?.Invoke(Input.mousePosition);

        if (Input.GetMouseButtonUp(LeftMouseButton))
            ClickUp?.Invoke(Input.mousePosition);

        Move?.Invoke(Input.mousePosition);
    }

}
