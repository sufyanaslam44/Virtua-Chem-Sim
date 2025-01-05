using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AudioArrangement : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public float delayTime;
    public Button fillAcidButton;

    private Coroutine playAudioCoroutine;

    void Start()
    {
        // Start playing audio1 and audio2 with delay
        playAudioCoroutine = StartCoroutine(PlayAudioWithDelay());

        // Add listener to the button click event
        fillAcidButton.onClick.AddListener(OnFillAcidButtonClick);
    }

    IEnumerator PlayAudioWithDelay()
    {
        // Play the first audio
        audioSource1.Play();

        // Wait for the length of the first audio plus the delay time
        yield return new WaitForSeconds(audioSource1.clip.length + delayTime);

        // Play the second audio
        audioSource2.Play();
    }

    void OnFillAcidButtonClick()
    {
        // Stop audioSource1 if it's playing
        if (audioSource1.isPlaying)
        {
            audioSource1.Stop();
        }

        // Stop audioSource2 if it's playing
        if (audioSource2.isPlaying)
        {
            audioSource2.Stop();
        }

        // Stop the coroutine if it's running
        if (playAudioCoroutine != null)
        {
            StopCoroutine(playAudioCoroutine);
        }

        // Play audioSource3
        audioSource3.Play();
    }
}
