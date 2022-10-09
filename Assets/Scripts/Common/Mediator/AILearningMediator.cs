using UnityEngine;

public class AILearningMediator : MonoBehaviour
{
    [SerializeField] private Evolution _evolution;
    [SerializeField] private AILearningPanel _learningPanel;

    public void UpdateBestResult(int bestWinsResult, int bestDrawsResult, int bestLoosesResult) => _learningPanel.UpdateBestResult(bestWinsResult, bestDrawsResult, bestLoosesResult);
    public void UpdateLearningProgress(int populationNumber) => _learningPanel.UpdateLearningProgress(populationNumber);
    public void LaunchAILearning() => _evolution.Launch();
    public void StopAILearning() => _evolution.Stop();
    public void ContinueAILearning() => _evolution.Continue();
} 
