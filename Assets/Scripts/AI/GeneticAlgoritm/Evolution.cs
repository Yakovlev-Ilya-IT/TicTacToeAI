using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Evolution : MonoBehaviour
{
    private EvolutionConfig _config;
    private PerceptronConfig _perceptronConfig;
    private Game _game;
    private VictoryHandler _victoryHandler;
    private ICellTagger _cellTagger;
    private AILearningMediator _mediator;

    private Population _currentPopulation;
    private List<AIAgent> _bestParents;
    private AIAgent _bestAIAgent;

    private int _generationNumber;

    private bool _isStop;

    private int GenerationsNumberBeforeStopLearning => _config.GenerationsNumberBeforeStoppingLearning;
    private float DelayTimeBetweenGames => _config.DelayTimeBetweenGames;
    private float DelayTimeBetweenGenerations => _config.DelayTimeBetweenGenerations;
    public AIAgent BestAIAgent => _bestAIAgent;


    [Inject]
    public void Construct(Game game, ICellTagger cellTagger, EvolutionConfig config, AILearningMediator mediator)
    {
        _config = config;
        _game = game;
        _cellTagger = cellTagger;
        _victoryHandler = new VictoryHandler(_game.GameBoard.BoardSize);

        _mediator = mediator;

        _perceptronConfig = new PerceptronConfig(_game.GameBoard.BoardSize * _game.GameBoard.BoardSize + 1, 1, new SigmoidFunction(), new int[] { 20, 15, 15, 18, 19,10});
    }

    public void Launch()
    {
        _currentPopulation = new Population(_config.PopulationConfig, _perceptronConfig);
        _generationNumber = 0;

        StartCoroutine(ProcessGeneticAlgoritm());
    }

    public void Stop()
    {
        _isStop = true;
    }

    public void Continue()
    {
        _isStop = false;
    }

    private void OnGameEnded(AIAgent agent)
    {
        _bestParents.Add(agent);
    }

    public IEnumerator ProcessGeneticAlgoritm()
    {
        for (int i = 0; i < GenerationsNumberBeforeStopLearning; i++)
        {
            _generationNumber++;

            _mediator.UpdateLearningProgress(_generationNumber);

            _currentPopulation.ClearPersonsResult();

            yield return MakeTournamentForBestPerson();

            while(_isStop)
                yield return null;

            _bestAIAgent = _currentPopulation.DetermineBestPerson();

            _mediator.UpdateBestResult(_bestAIAgent.WinsNumber, _bestAIAgent.DrawsNumber, _bestAIAgent.LoosesNumber);

            yield return MakeQualifyingTournament();

            _currentPopulation = new Population(_config.PopulationConfig, _perceptronConfig, _bestParents.ToArray());

            _currentPopulation.MakeCrossover();
            _currentPopulation.MakeMutation();

            yield return new WaitForSeconds(DelayTimeBetweenGenerations);
        }
    }

    private IEnumerator MakeTournamentForBestPerson()
    {
        for (int i = 0; i < _currentPopulation.Persons.Length; i++)
        {
            for (int j = i + 1; j < _currentPopulation.Persons.Length; j++)
            {
                while (_isStop)
                    yield return null;

                IGameBehaviour gameBehaviour;
                if (Random.Range(0,2) == 0)
                {
                    gameBehaviour = new CPUVsCPUGameBehavior(_game.GameBoard, _cellTagger, _victoryHandler, _currentPopulation.Persons[i], _currentPopulation.Persons[j]);
                }
                else
                {
                    gameBehaviour = new CPUVsCPUGameBehavior(_game.GameBoard, _cellTagger, _victoryHandler, _currentPopulation.Persons[j], _currentPopulation.Persons[i]);

                }

                _game.StartGame(gameBehaviour);
                yield return new WaitForSeconds(DelayTimeBetweenGames);
            }
        }
    }

    private IEnumerator MakeQualifyingTournament()
    {
        _bestParents = new List<AIAgent>();

        AIEventsHolder.GameEnded += OnGameEnded;

        List<AIAgent> agents = new List<AIAgent>();
        for (int i = 0; i < _currentPopulation.Persons.Length; i++)
        {
            agents.Add((AIAgent)_currentPopulation.Persons[i].Clone());
        }

        for (int i = 0; i < _currentPopulation.Persons.Length; i++)
        {
            int firstAgentIndex = Random.Range(0, _currentPopulation.Persons.Length);
            int secondAgentIndex = Random.Range(0, _currentPopulation.Persons.Length);

            while (firstAgentIndex == secondAgentIndex)
                secondAgentIndex = Random.Range(0, _currentPopulation.Persons.Length);

            IGameBehaviour gameBehaviour = new CPUVsCPUGameBehavior(_game.GameBoard, _cellTagger, _victoryHandler, _currentPopulation.Persons[firstAgentIndex], _currentPopulation.Persons[secondAgentIndex]);
            _game.StartGame(gameBehaviour);

            yield return new WaitForSeconds(DelayTimeBetweenGames);
        }

        AIEventsHolder.GameEnded -= OnGameEnded;
    }

    

    //DEBUG ÓÄÀËÈ ÏÎÑËÅ ÓÄÀ×ÍÛÕ ÒÅÑÒÎÂ
    public void PlayWithPlayer()
    {
        _isStop = true;
        IGameBehaviour gameBehaviour = new PlayerVsCPUGameBehaviour(_game.GameBoard, _cellTagger, _victoryHandler, BestAIAgent);
        _game.StartGame(gameBehaviour);
    }
}
