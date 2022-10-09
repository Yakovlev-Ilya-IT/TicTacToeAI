using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AILearningPanel : MonoBehaviour
{
    [SerializeField] private AILearningPanelView _view;

    private AILearningMediator _mediator;
    [SerializeField] private Button _launchButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private Button _continueButton;

    [Inject]
    private void Construct(AILearningMediator mediator)
    {
        _mediator = mediator;
    }

    private void OnEnable()
    {
        _launchButton.onClick.AddListener(OnLaunchButtonClick);
        _stopButton.onClick.AddListener(OnStopButtonClick);
        _continueButton.onClick.AddListener(OnContinueButtonClick);
    }

    private void OnLaunchButtonClick()
    {
        _mediator.LaunchAILearning();
        _launchButton.gameObject.SetActive(false);
        _stopButton.gameObject.SetActive(true);
    }

    private void OnStopButtonClick()
    {
        _mediator.StopAILearning();
        _stopButton.gameObject.SetActive(false);
        _continueButton.gameObject.SetActive(true);
        //_saveButton.gameObject.SetActive(true);
    }

    private void OnContinueButtonClick()
    {
        _mediator.ContinueAILearning();
        _stopButton.gameObject.SetActive(true);
        _continueButton.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _launchButton.onClick.RemoveListener(OnLaunchButtonClick);
        _stopButton.onClick.RemoveListener(OnStopButtonClick);
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
    }

    public void UpdateBestResult(int bestWinsResult, int bestDrawsResult, int bestLoosesResult)
    {
        _view.UpdateBestResult(bestWinsResult, bestDrawsResult, bestLoosesResult);
    }

    public void UpdateLearningProgress(int populationNumber)
    {
        _view.UpdateLearningProgress(populationNumber);
    }
}
