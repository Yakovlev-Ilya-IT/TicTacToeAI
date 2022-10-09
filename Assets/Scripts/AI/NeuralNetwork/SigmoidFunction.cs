using System;

public class SigmoidFunction : IActivationFunction
{
    public float Compute(float x) => (float)(1 / (1 + MathF.Exp(-1 * x)));

    public float ComputeFirstDerivative(float x) => Compute(x) * (1 - Compute(x));
}
