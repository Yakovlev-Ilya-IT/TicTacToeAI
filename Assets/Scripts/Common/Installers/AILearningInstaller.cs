using UnityEngine;
using Zenject;

public class AILearningInstaller : MonoInstaller
{
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private GameBoardConfig _data;
    [SerializeField] private Evolution _evolution;
    [SerializeField] private EvolutionConfig _evolutionConfig;
    [SerializeField] private AILearningMediator _learningMediator;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CellSelectionHandler>().FromNew().AsSingle();

        Container.Bind<GameBoardConfig>().FromInstance(_data).AsSingle();
        Container.Bind<EvolutionConfig>().FromInstance(_evolutionConfig).AsSingle();
        Container.Bind<AILearningMediator>().FromInstance(_learningMediator).AsSingle();

        Container.BindInterfacesAndSelfTo<GameBoard>().FromInstance(_gameBoard).AsSingle();
        Container.BindInterfacesAndSelfTo<Game>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<Evolution>().FromInstance(_evolution).AsSingle().NonLazy();
    }
}
