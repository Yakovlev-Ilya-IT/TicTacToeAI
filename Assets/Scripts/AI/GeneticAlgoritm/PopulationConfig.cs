using System;
using UnityEngine;

[Serializable]
public class PopulationConfig
{
    [SerializeField, Range(2, 128)] private int _personsNumber = 64;
    [SerializeField, Range(0, 1)] private float _crossingProbability = 0.5f;
    [SerializeField, Range(0, 1)] private float _mutationProbability = 0.05f;

    public int PersonsNumber => _personsNumber;
    public float CrossingProbability => _crossingProbability;
    public float MutationProbability => _mutationProbability;
}
