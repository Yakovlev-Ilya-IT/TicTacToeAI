public interface IState
{
    public void Enter();
    public void MakeMove(Cell cell);
    public void Exit();
}
