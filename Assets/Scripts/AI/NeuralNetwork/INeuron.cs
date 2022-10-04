public interface INeuron
{
    public float[] Weights { get; }
    public float Offset { get; }
    public float Output { get; }
    public IActivationFunction ActivationFunction { get; set; }
    public float Compute(float[] inputs);
}
