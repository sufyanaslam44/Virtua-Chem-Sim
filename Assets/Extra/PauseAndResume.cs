using UnityEngine;

public class PauseAndResume : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject resumeButton;
    private bool isPaused = false;

    void Start()
    {
        // Ensure the resume button is hidden at the start
        
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;  // Pauses the game by setting the time scale to 0
            isPaused = true;
            pauseButton.SetActive(false);  // Hide the pause button
            resumeButton.SetActive(true);  // Show the resume button
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;  // Resumes the game by setting the time scale back to 1
            isPaused = false;
            pauseButton.SetActive(true);  // Show the pause button
            resumeButton.SetActive(false);  // Hide the resume button
        }
    }
}
