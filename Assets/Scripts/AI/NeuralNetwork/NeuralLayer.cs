using System.Collections.Generic;

public class NeuralLayer : INeuralLayer
{
    private List<INeuron> _neurons;
    private float[] _output;

    public List<INeuron> Neurons => _neurons;
    public int NeuronsCount => Neurons?.Count ?? 0;
    public float[] Output => _output;

    public NeuralLayer(int neuronsCount, int inputsCountPerNeuron, IActivationFunction activationFunction)
    {
        _neurons = new List<INeuron>();
        CreateNeurons(neuronsCount, inputsCountPerNeuron, activationFunction);
    }

    private void CreateNeurons(int neuronsCount, int inputsCountPerNeuron, IActivationFunction activationFunction)
    {
        for (int i = 0; i < neuronsCount; i++)
        {
            INeuron neuron = new Neuron(inputsCountPerNeuron, activationFunction);
            _neurons.Add(neuron);
        }
    }

    public float[] Compute(float[] inputs)
    {
        _output = new float[NeuronsCount];

        for (int i = 0; i < NeuronsCount; i++)
            _output[i] = _neurons[i].Compute(inputs);

        return _output;
    }
}
