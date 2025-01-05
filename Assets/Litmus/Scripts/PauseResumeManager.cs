using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseResumeManager : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public List<GameObject> uiElements;  // Assign all UI elements you want to hide/show in the Inspector
    public List<AudioSource> audioSources;  // Assign all AudioSources in the Inspector

    private List<GameObject> activeUIElements = new List<GameObject>();
    private List<AudioSource> activeAudioSources = new List<AudioSource>();

    void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    void PauseGame()
    {
        // Hide all active UI elements
        foreach (GameObject uiElement in uiElements)
        {
            if (uiElement.activeSelf)
            {
                activeUIElements.Add(uiElement);
                uiElement.SetActive(false);
            }
        }

        // Pause all active audio
        foreach (AudioSource audio in audioSources)
        {
            if (audio.isPlaying)
            {
                activeAudioSources.Add(audio);
                audio.Pause();
            }
        }
    }

    void ResumeGame()
    {
        // Show all previously active UI elements
        foreach (GameObject uiElement in activeUIElements)
        {
            uiElement.SetActive(true);
        }
        activeUIElements.Clear();

        // Resume all previously active audio
        foreach (AudioSource audio in activeAudioSources)
        {
            audio.Play();
        }
        activeAudioSources.Clear();
    }
}
