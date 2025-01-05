using UnityEngine;
using UnityEngine.UI;

public class AudioPauseAndResume : MonoBehaviour
{
    private AudioSource[] allAudioSources;

    void Start()
    {
        // Find all audio sources in the scene
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    public void PauseAllAudio()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
    }

    public void ResumeAllAudio()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.time > 0) // Check if the audio was playing before being paused
            {
                audioSource.UnPause();
            }
        }
    }
}
