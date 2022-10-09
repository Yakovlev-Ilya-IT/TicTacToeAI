using UnityEngine;

[CreateAssetMenu(fileName = "EvolutionConfig", menuName = "Configs/EvolutionConfig")]
public class EvolutionConfig : ScriptableObject
{
    [SerializeField, Range(10, 400)] private int _generationsNumber = 64;
    [SerializeField, Range(0, 10)] private float _delayTimeBetweenGames = 0;
    [SerializeField, Range(0, 10)] private float _delayTimeBetweenGenerations = 0;

    [SerializeField] PopulationConfig _populationConfig;

    public int GenerationsNumberBeforeStoppingLearning => _generationsNumber;
    public float DelayTimeBetweenGames => _delayTimeBetweenGames;
    public float DelayTimeBetweenGenerations => _delayTimeBetweenGenerations;
    public PopulationConfig PopulationConfig => _populationConfig;

}
