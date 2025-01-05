using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Add this to use TextMesh Pro
using System.Collections;

public class DragPippeteBack2 : MonoBehaviour
{
    public Button button1;  // Reference to the first button
    public Button button2;  // Reference to the second button
    public TextMeshProUGUI textMeshPro;  // Reference to the TextMesh Pro text
    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro3;
    public float delayTime = 2f;  // Delay time in seconds
    public AudioSource audioSource1;  // Reference to the audio source

    void Start()
    {
        // Ensure button2 and TextMesh Pro text are initially inactive
        button2.gameObject.SetActive(false);

        if (textMeshPro != null)
        {
            textMeshPro.gameObject.SetActive(false);
        }

        // Add click listener to button1
        button1.onClick.AddListener(OnButton1Click);

        // Add click listener to button2 to stop the audio
        button2.onClick.AddListener(OnButton2Click);
    }

    void OnButton1Click()
    {
        // Start the coroutine to show button2 and TextMesh Pro text after a delay
        StartCoroutine(ShowButton2AndTextAfterDelay());

    }

    IEnumerator ShowButton2AndTextAfterDelay()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Activate button2
        button2.gameObject.SetActive(true);
        textMeshPro1.gameObject.SetActive(true);

        // Activate TextMesh Pro text only if it's available
        if (textMeshPro != null)
        {
            textMeshPro.gameObject.SetActive(true);
            // Play the audio when TextMesh Pro appears
            if (audioSource1 != null)
            {
                audioSource1.Play();
            }
        }
       
    }

    void OnButton2Click()
    {
        // Stop the audio when button2 is clicked
        if (audioSource1 != null)
        {
            audioSource1.Stop();
        }
        textMeshPro1.gameObject.SetActive(false);
        textMeshPro3.gameObject.SetActive(true);
    }
}
