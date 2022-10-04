public interface IMultiplayerNeuralNetwork : INeuralNetwork
{
    INeuralLayer[] NeuralLayers { get; }
    public int FirstLayerNumber { get; }
    public int OutputLayerNumber { get; }
}
