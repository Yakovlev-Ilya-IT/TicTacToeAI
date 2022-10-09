public interface IMultiplayerNeuralNetwork : INeuralNetwork
{
    INeuralLayer[] NeuralLayers { get; }
    public int InputsCount { get; }
    public int NeuralLayersCount { get; }
    public int FirstLayerNumber { get; }
    public int OutputLayerNumber { get; }
}
