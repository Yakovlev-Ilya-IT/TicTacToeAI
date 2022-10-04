public class PerceptronConfig
{
    private int _inputsCount;
    private int _outputsCount;
    private int[] _hiddenLayersNeuronsCount;
    private IActivationFunction _activationFunction;

    public int IinputsCount => _inputsCount;
    public int OutputsCount => _outputsCount;
    public int[] HiddenLayersNeuronsCount => _hiddenLayersNeuronsCount;
    public IActivationFunction ActivationFunction => _activationFunction;
    public int LayersCount => _hiddenLayersNeuronsCount.Length + 1;

    public PerceptronConfig(int inputsCount, int outputsCount, IActivationFunction activationFunction, params int[] hiddenLayersNeuronsCount)
    {
        _inputsCount = inputsCount;
        _outputsCount = outputsCount;
        _hiddenLayersNeuronsCount = hiddenLayersNeuronsCount;
        _activationFunction = activationFunction;
    }
}
