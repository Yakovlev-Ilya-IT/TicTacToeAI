using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private GameBoardConfig _data;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CellSelectionHandler>().FromNew().AsSingle();
        Container.Bind<GameBoardConfig>().FromInstance(_data).AsSingle();
        Container.Bind<GameBoard>().FromInstance(_gameBoard).AsSingle();
        Container.BindInterfacesAndSelfTo<GameBehaviour>().FromNew().AsSingle().NonLazy();
    }
}
