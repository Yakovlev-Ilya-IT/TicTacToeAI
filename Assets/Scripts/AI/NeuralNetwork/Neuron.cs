using System;
using UnityEngine;

[Serializable]
public class Neuron : INeuron
{
    private float[] _weights;
    private float _offset;
    private float _output;
    private IActivationFunction _activationFunction;

    public float[] Weights => _weights;
    public float Offset => _offset;
    public float Output => _output;
    public IActivationFunction ActivationFunction { get => _activationFunction; set => _activationFunction = value; }

    public Neuron(int inputCount)
    {
        _weights = new float[inputCount];

        InitializeWeights(inputCount);
        InitializeOffset();
    }
    public Neuron(int inputCount, IActivationFunction acticationFunction) : this(inputCount)
    {
        _activationFunction = acticationFunction;
    }

    private void InitializeOffset()
    {
        _offset = UnityEngine.Random.Range(-1f, 1f);
    }


    private void InitializeWeights(int inputCount)
    {
        for (int i = 0; i < inputCount; i++)
        {
            _weights[i] = UnityEngine.Random.Range(-1f, 1f);
        }
    }

    public float Compute(float[] inputs)
    {
        float sumResult = 0;

        for (int i = 0; i < inputs.Length; i++)
        {
            sumResult += inputs[i] * _weights[i];
        }

        sumResult -= _offset;

        _output = _activationFunction.Compute(sumResult);

        return _output;
    }

    public void SetWeight(float weight, int weightIndex)
    {
        _weights[weightIndex] = weight;
    }

    public void SetOffset(float offset)
    {
        _offset = offset;
    }
}
