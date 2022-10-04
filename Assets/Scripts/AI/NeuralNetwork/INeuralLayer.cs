using System.Collections.Generic;

public interface INeuralLayer
{
    public List<INeuron> Neurons { get; }
    public int NeuronsCount { get; }
    public float[] Output { get; }
    public float[] Compute(float[] inputs);
}
