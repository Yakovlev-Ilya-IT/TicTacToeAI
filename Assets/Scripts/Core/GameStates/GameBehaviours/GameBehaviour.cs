using System.Collections.Generic;
using System.Linq;

public abstract class GameBehaviour : IGameBehaviour
{
    protected List<IState> _states;
    protected IState _currentState;

    public IState CurrentState => _currentState;

    public void Launch()
    {
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(s => s is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
}
