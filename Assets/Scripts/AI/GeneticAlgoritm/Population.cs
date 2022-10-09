using MathNet.Numerics.Distributions;
using System;
using UnityEngine;

public class Population 
{
    private PopulationConfig _config;
    private PerceptronConfig _perceptronConfig;
    private AIAgent[] _persons;
    private AIAgent _bestAgent;

    private int Size => _config.PersonsNumber;
    private float CrossingProbability => _config.CrossingProbability;
    private float MutationProbability => _config.MutationProbability;

    public AIAgent[] Persons => _persons;
    public AIAgent BestAgent => _bestAgent;

    public Population(PopulationConfig config, PerceptronConfig perceptronConfig)
    {
        _config = config;
        _perceptronConfig = perceptronConfig;
        Create();
    }

    public Population(PopulationConfig config, PerceptronConfig perceptronConfig, AIAgent[] persons)
    {
        _config = config;
        _perceptronConfig = perceptronConfig;
        _persons = new AIAgent[persons.Length];

        for (int i = 0; i < _persons.Length; i++)
        {
            _persons[i] = (AIAgent)persons[i].Clone();
        }
    }

    public void ClearPersonsResult()
    {
        for (int i = 0; i < _persons.Length; i++)
            _persons[i].ClearResult();
    }

    private void Create()
    {
        _persons = new AIAgent[Size];

        for (int i = 0; i < _persons.Length; i++)
        {
            IMultiplayerNeuralNetwork neuralNetwork = new Perceptron(_perceptronConfig);
            _persons[i] = new AIAgent(neuralNetwork);
        }
    }

    public void MakeCrossover()
    {
        for (int i = 0; i < _persons.Length; i += 2)
        {
            IMultiplayerNeuralNetwork firstPersonNeuralNetwork = _persons[i].NeuralNetwork;
            IMultiplayerNeuralNetwork secondPersonNeuralNetwork = _persons[i + 1].NeuralNetwork;

            for (int j = 0; j < firstPersonNeuralNetwork.NeuralLayersCount; j++)
            {
                for (int k = 0; k < firstPersonNeuralNetwork.NeuralLayers[j].NeuronsCount; k++)
                {
                    if (UnityEngine.Random.Range(0f, 1f) <= CrossingProbability)
                    {
                        INeuron buffer = firstPersonNeuralNetwork.NeuralLayers[j].Neurons[k];
                        firstPersonNeuralNetwork.NeuralLayers[j].Neurons[k] = secondPersonNeuralNetwork.NeuralLayers[j].Neurons[k];
                        secondPersonNeuralNetwork.NeuralLayers[j].Neurons[k] = buffer;
                    }
                }
            }
        }
    }

    public void MakeMutation()
    {
        for (int i = 0; i < _persons.Length; i++)
        {
            IMultiplayerNeuralNetwork personNeuralNetwork = _persons[i].NeuralNetwork;

            for (int j = 0; j < personNeuralNetwork.NeuralLayersCount; j++)
            {
                for (int k = 0; k < personNeuralNetwork.NeuralLayers[j].NeuronsCount; k++)
                {
                    for (int l = 0; l < personNeuralNetwork.NeuralLayers[j].Neurons[k].Weights.Length; l++)
                    {
                        if (UnityEngine.Random.Range(0f, 1f) <= MutationProbability)
                        {
                            float weight = personNeuralNetwork.NeuralLayers[j].Neurons[k].Weights[l];
                            Normal normalWeightDist = new Normal(weight, 1);
                            personNeuralNetwork.NeuralLayers[j].Neurons[k].SetWeight((float)normalWeightDist.Sample(), l);
                        }
                    }

                    float offset = personNeuralNetwork.NeuralLayers[j].Neurons[k].Offset;
                    Normal normalOffsetlDist = new Normal(offset, 1);
                    personNeuralNetwork.NeuralLayers[j].Neurons[k].SetOffset((float)normalOffsetlDist.Sample());
                }
            }
        }
    }

    public AIAgent DetermineBestPerson()
    {
        _bestAgent = _persons[0];
        for (int i = 0; i < _persons.Length; i++)
        {
            if(_bestAgent.SuccessValue < _persons[i].SuccessValue)
                _bestAgent = _persons[i];
        }

        return (AIAgent)_bestAgent.Clone();
    }
}
