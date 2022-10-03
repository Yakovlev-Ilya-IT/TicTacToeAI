using System;
using UnityEngine;
using Zenject;

public class MobileInput : IInput, ITickable
{
    public event Action<Vector3> ClickDown;
    public event Action<Vector3> ClickUp;
    public event Action<Vector3> Move;

    public void Tick()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    ClickDown?.Invoke(touch.position);
                    break;
                case TouchPhase.Moved:
                    Move?.Invoke(touch.position);
                    break;
                case TouchPhase.Ended:
                    ClickUp?.Invoke(touch.position);
                    break;
            }
        }
    }
}
