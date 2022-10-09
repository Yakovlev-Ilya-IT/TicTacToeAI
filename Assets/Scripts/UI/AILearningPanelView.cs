using TMPro;
using UnityEngine;

public class AILearningPanelView : MonoBehaviour
{
    [SerializeField] TMP_Text _bestWinsResult;
    [SerializeField] TMP_Text _bestDrawsResult;
    [SerializeField] TMP_Text _bestLoosesResult;
    [SerializeField] TMP_Text _populationNumber;

    public void UpdateBestResult(int bestWinsResult, int bestDrawsResult, int bestLoosesResult)
    {
        _bestWinsResult.text = bestWinsResult.ToString();
        _bestDrawsResult.text = bestDrawsResult.ToString();
        _bestLoosesResult.text = bestLoosesResult.ToString();
    }

    public void UpdateLearningProgress(int populationNumber)
    {
        _populationNumber.text = populationNumber.ToString();
    }
}
