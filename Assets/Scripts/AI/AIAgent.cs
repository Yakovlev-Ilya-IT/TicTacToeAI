using System;
using System.Collections.Generic;

public class AIAgent: ICloneable
{
    private IMultiplayerNeuralNetwork _neuralNetwork;
    private const int ResultOutputNumber = 0;

    private Dictionary<float, int> _evaluationMoveToNumberCell;

    private float _successValue;
    private int _loosesNumber;
    private int _winsNumber;
    private int _drawsNumber;

    public float SuccessValue => _successValue;
    public int LoosesNumber => _loosesNumber;
    public int WinsNumber => _winsNumber;
    public int DrawsNumber => _drawsNumber;
    public IMultiplayerNeuralNetwork NeuralNetwork => _neuralNetwork;

    public AIAgent(IMultiplayerNeuralNetwork neuralNetwork)
    {
        _neuralNetwork = neuralNetwork;
    }

    public AIAgent(IMultiplayerNeuralNetwork neuralNetwork, int winsNumber, int loosesNumber, int drawsNumber)
    {
        _neuralNetwork = neuralNetwork;
        _winsNumber = winsNumber;
        _loosesNumber = loosesNumber;
        _drawsNumber = drawsNumber;
    }

    public int GetNumberCellForMove(float[] table)
    {
        _evaluationMoveToNumberCell = new Dictionary<float, int>();

        float maxEvaluation = 0;
        for (int i = 0; i < table.Length - 1; i++)
        {
            if(table[i] == MarkTypeForAI.EmptyMark)
            {
                table[i] = MarkTypeForAI.FriendlyMark;
                float[] result = _neuralNetwork.FeedForward(table);

                if (_evaluationMoveToNumberCell.ContainsKey(result[0]))
                    continue;

                _evaluationMoveToNumberCell.Add(result[ResultOutputNumber], i);

                if (result[0] > maxEvaluation)
                    maxEvaluation = result[ResultOutputNumber];
            }
        }

        return _evaluationMoveToNumberCell[maxEvaluation];
    }

    public void IncreaseSuccessValue()
    {
        _successValue++;
        _winsNumber++;
    }

    public void ReduceSuccessValue()
    {
        _successValue--;
        _loosesNumber++;
    }

    public void IncreaseDraw()
    {
        _successValue += 0.5f;
        _drawsNumber++;
    }

    public void ClearResult()
    {
        _successValue = 0;
        _loosesNumber = 0;
        _drawsNumber = 0;
        _winsNumber = 0;
    }

    public object Clone()
    {
        return new AIAgent(_neuralNetwork, _winsNumber, _loosesNumber, _drawsNumber);
    }
}
