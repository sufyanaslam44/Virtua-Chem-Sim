using UnityEngine;
using UnityEngine.UI;

public class VisibilityFillAcid : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public Button button1;

    private bool button1Clicked = false;
    private bool isPaused = false;

    void Start()
    {
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
        resumeButton.onClick.AddListener(OnResumeButtonClicked);
        button1.onClick.AddListener(OnButton1Clicked);
    }

    void OnPauseButtonClicked()
    {
        button1.gameObject.SetActive(false);
        isPaused = true;
    }

    void OnResumeButtonClicked()
    {
        if (!button1Clicked)
        {
            button1.gameObject.SetActive(true);
        }
        isPaused = false;
    }

    void OnButton1Clicked()
    {
        button1Clicked = true;
        button1.gameObject.SetActive(false);
    }
}
