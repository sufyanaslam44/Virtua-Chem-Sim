using UnityEngine;
using UnityEngine.UI;

public class ExplanationAndQuiz : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button explanationButton;
    public Button quizButton;
    public Button calculateConcButton;
    public Button backExplanation;
    public Button backQuiz;
    public Button hintsBackground;
    public Button pauseButton; // Added pauseButton
    public Button resumeButton; // Added resumeButton

    private bool isCalculateConcButtonClicked = false;
    private bool isButton3Clicked = false;

    void Start()
    {
        calculateConcButton.onClick.AddListener(OnCalculateConcButtonClick);
        explanationButton.onClick.AddListener(OnExplanationOrQuizButtonClick);
        quizButton.onClick.AddListener(OnExplanationOrQuizButtonClick);

        backExplanation.onClick.AddListener(OnBackExplanationOrQuizButtonClick);
        backQuiz.onClick.AddListener(OnBackExplanationOrQuizButtonClick);

        pauseButton.onClick.AddListener(OnPauseButtonClick); // Added listener for pauseButton
        resumeButton.onClick.AddListener(OnResumeButtonClick); // Added listener for resumeButton

        button3.onClick.AddListener(OnButton3Click);
    }

    void OnCalculateConcButtonClick()
    {
        isCalculateConcButtonClicked = true;
    }

    void OnButton3Click()
    {
        isButton3Clicked = true;
        HideButtons();
    }

    void OnPauseButtonClick()
    {
        if (isCalculateConcButtonClicked)
        {
            HideButtons();
        }
    }

    void OnResumeButtonClick()
    {
        if (!isCalculateConcButtonClicked)
        {
            ShowHintsBackground();
        }
        if (isCalculateConcButtonClicked && !isButton3Clicked)
        {
            ShowButtons();
        }
    }

    void OnExplanationOrQuizButtonClick()
    {
        if (isCalculateConcButtonClicked)
        {
            HideButtons();
        }
    }

    void OnBackExplanationOrQuizButtonClick()
    {
        if (isCalculateConcButtonClicked && !isButton3Clicked)
        {
            ShowButtons();
        }
        else if (!isCalculateConcButtonClicked)
        {
            ShowHintsBackground();
        }
    }

    void HideButtons()
    {
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
    }

    void ShowButtons()
    {
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);
    }

    void ShowHintsBackground()
    {
        hintsBackground.gameObject.SetActive(true);
    }
}
