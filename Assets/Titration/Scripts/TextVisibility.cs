using UnityEngine;
using TMPro; // Make sure you have using statement for TextMeshPro
using UnityEngine.UI; // Make sure you have using statement for UI

public class TextVisibility : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public TextMeshProUGUI textMeshPro1; // Ensure this is the correct type for your TextMeshPro component

    private bool textMeshPro1WasActive;

    void Start()
    {
        // Ensure buttons and TextMeshPro are assigned
        if (pauseButton == null || resumeButton == null || textMeshPro1 == null)
        {
           
            return;
        }

        // Add listeners to buttons
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
        resumeButton.onClick.AddListener(OnResumeButtonClicked);
    }

    void OnPauseButtonClicked()
    {
        // Save the active state of textMeshPro1
        textMeshPro1WasActive = textMeshPro1.gameObject.activeSelf;

        // Hide textMeshPro1
        textMeshPro1.gameObject.SetActive(false);
    }

    void OnResumeButtonClicked()
    {
        // Show textMeshPro1 only if it was active before the pause button was clicked
        if (textMeshPro1WasActive)
        {
            textMeshPro1.gameObject.SetActive(true);
        }
    }
}
