using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ButtonV1 : MonoBehaviour
{
    public Button calculateButton;
    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;
    public TextMeshProUGUI textMeshPro3;
    public TextMeshProUGUI textMeshPro4;
    public Button concButton;
    public AudioSource audioSource1; // Add this line
    public AudioSource audioSource2; // Add this line

    void Start()
    {
        // Ensure the TextMeshPro objects are initially hidden
        textMeshPro1.gameObject.SetActive(false);
        textMeshPro2.gameObject.SetActive(false);
        textMeshPro3.gameObject.SetActive(true);
        textMeshPro4.gameObject.SetActive(false);
        concButton.gameObject.SetActive(false);

        // Add a listener to the button to call the ShowText function when clicked
        calculateButton.onClick.AddListener(ShowText);

        // Add a listener to the concButton to stop the audio when clicked
        concButton.onClick.AddListener(StopAudioAndPlayAnother);
    }

    void ShowText()
    {
        // Show the TextMeshPro objects
        textMeshPro1.gameObject.SetActive(true);
        textMeshPro2.gameObject.SetActive(true);

        // Start coroutine to hide objects after 4 seconds and then show the next objects
        StartCoroutine(HideAndShowObjectsAfterDelay(4f));
    }

    IEnumerator HideAndShowObjectsAfterDelay(float hideDelay)
    {
        // Wait for the specified hide delay
        yield return new WaitForSeconds(hideDelay);

        // Hide the calculateButton, textMeshPro1, and textMeshPro3
        calculateButton.gameObject.SetActive(false);
        textMeshPro1.gameObject.SetActive(false);
        textMeshPro3.gameObject.SetActive(false);

        // Log to confirm that first objects are hidden
        Debug.Log("First set of objects hidden. Showing next set immediately.");

        // Show the textMeshPro4 and concButton immediately
        textMeshPro4.gameObject.SetActive(true);
        concButton.gameObject.SetActive(true);

        // Play the audio when textMeshPro4 appears
        if (audioSource1 != null)
        {
            audioSource1.Play();
        }

        // Log to confirm that next objects are shown
        Debug.Log("Next set of objects shown.");
    }

    void StopAudioAndPlayAnother()
    {
        // Stop the first audio and play the second audio when concButton is clicked
        if (audioSource1 != null && audioSource1.isPlaying)
        {
            audioSource1.Stop();
        }

        if (audioSource2 != null)
        {
            audioSource2.Play();
        }
    }
}
