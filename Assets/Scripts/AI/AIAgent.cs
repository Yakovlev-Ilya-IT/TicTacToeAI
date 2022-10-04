using System.Collections.Generic;

public class AIAgent
{
    private IMultiplayerNeuralNetwork _neuralNetwork;

    private Dictionary<float, int> _evaluationMoveToNumberCell;

    public AIAgent(IMultiplayerNeuralNetwork neuralNetwork)
    {
        _neuralNetwork = neuralNetwork;

        _evaluationMoveToNumberCell = new Dictionary<float, int>();
    }

    public int GetNumberCellForMove(float[] table)
    {
        float maxEvaluation = 0;
        for (int i = 0; i < table.Length; i++)
        {
            if(table[i] == MarkTypeForAI.EmptyMark)
            {
                table[i] = MarkTypeForAI.FriendlyMark;
                float[] result = _neuralNetwork.FeedForward(table);

                _evaluationMoveToNumberCell.Add(result[0], i); //обозначь ноль не цифрой

                if (result[0] > maxEvaluation)
                    maxEvaluation = result[0]; //обозначь ноль не цифрой
            }
        }

        return _evaluationMoveToNumberCell[maxEvaluation];
    }
}
