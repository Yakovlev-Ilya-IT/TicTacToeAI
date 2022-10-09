using UnityEngine;
using Zenject;

public class GameLevelInstaller : MonoInstaller
{
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private GameBoardConfig _data;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CellSelectionHandler>().FromNew().AsSingle();

        Container.Bind<GameBoardConfig>().FromInstance(_data).AsSingle();

        Container.BindInterfacesAndSelfTo<GameBoard>().FromInstance(_gameBoard).AsSingle();
        Container.BindInterfacesAndSelfTo<Game>().FromNew().AsSingle();
    }
}