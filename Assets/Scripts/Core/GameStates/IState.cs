public interface IState
{
    public void Enter();
    public void OnCellSelected(ISelectableCell cell);
    public void Exit();
}
