using System;

[Serializable]
public class Perceptron : IMultiplayerNeuralNetwork
{
    private PerceptronConfig _config;
    private INeuralLayer[] _neuralLayers;

    public INeuralLayer[] NeuralLayers => _neuralLayers;
    public int FirstLayerNumber => 0;
    public int OutputLayerNumber => _neuralLayers.Length - 1;
    public int NeuralLayersCount => _neuralLayers?.Length ?? 0;
    public int InputsCount => _config.IinputsCount;

    public Perceptron(PerceptronConfig config)
    {
        _config = config;
        _neuralLayers = new INeuralLayer[_config.LayersCount];

        CreateLayers();
    }

    private void CreateLayers()
    {
        _neuralLayers[FirstLayerNumber] = new NeuralLayer(_config.HiddenLayersNeuronsCount[FirstLayerNumber], _config.IinputsCount, _config.ActivationFunction);

        for (int i = FirstLayerNumber + 1; i < _neuralLayers.Length; i++)
        {
            INeuralLayer _previousLayer = _neuralLayers[i - 1];

            if (i == OutputLayerNumber)
                _neuralLayers[i] = new NeuralLayer(_config.OutputsCount, _previousLayer.NeuronsCount, _config.ActivationFunction);
            else
                _neuralLayers[i] = new NeuralLayer(_config.HiddenLayersNeuronsCount[i], _previousLayer.NeuronsCount, _config.ActivationFunction);
        }
    }

    public float[] FeedForward(float[] inputs)
    {
        float[] previousLayerOutput = _neuralLayers[FirstLayerNumber].Compute(inputs);

        for (int i = FirstLayerNumber + 1; i < _neuralLayers.Length; i++)
        {
            previousLayerOutput = _neuralLayers[i].Compute(previousLayerOutput);
        }

        return _neuralLayers[OutputLayerNumber].Output;
    }
}
