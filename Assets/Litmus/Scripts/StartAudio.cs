using TMPro;
using UnityEngine;
using UnityEngine.UI;  // Include this for UI elements

public class StartAudio : MonoBehaviour
{
    public AudioSource audioSource1;

    public AudioSource audioSource4;
    public Button solutionAButton;
    public Button level2Locked;
    public Button level3Locked;

    private bool buttonClicked = false;  // Flag to track if the button has been clicked
    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;
    public TextMeshProUGUI textMeshPro3;
    public TextMeshProUGUI textMeshPro4;


    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject redLitmus;
    
    public Button solutionB;
    public Button solutionC;
    public Button redButton;
    public GameObject explanation;
    public GameObject quiz;
    private void Start()
    {
        // Start playing the first audio source at the beginning of the scene
        if (audioSource1 != null)
        {
            audioSource1.Play();
            // Register event handler for when the first audio finishes
            Invoke(nameof(OnAudioSource1Finished), audioSource1.clip.length);
        }

        // Register the button click event
        if (solutionAButton != null)
        {
            solutionAButton.onClick.AddListener(OnSolutionAButtonClicked);
        }
        if (solutionB != null)
        {
            solutionB.onClick.AddListener(OnSolutionBClicked);
        }

    }

    private void OnAudioSource1Finished()
    {
        // Check if the button has been clicked
        if (buttonClicked) return;

     // Play the second audio source when the first one finishes

    }

    

   

    private void OnSolutionAButtonClicked()
    {
        // Set the flag to true to indicate the button has been clicked
        buttonClicked = true;

        // Stop all current audio sources
        if (audioSource1.isPlaying) audioSource1.Stop();
      
       

        // Play the fourth audio source after 0.5 seconds
        if (audioSource4 != null)
        {
            Invoke(nameof(PlayAudioSource4), 0.5f);
        }
        textMeshPro1.gameObject.SetActive(false);
        textMeshPro2.gameObject.SetActive(false);
        object1.SetActive(false);
        object2.SetActive(false);
        solutionB.gameObject.SetActive(false);
        solutionC.gameObject.SetActive(false);
        solutionAButton.gameObject.SetActive(false);
        explanation.SetActive(false);
        quiz.SetActive(false);
        textMeshPro3.gameObject.SetActive(true);
        textMeshPro4.gameObject.SetActive(true);
        redLitmus.SetActive(true);
        redButton.gameObject.SetActive(true);
        level2Locked.gameObject.SetActive(false);
        level3Locked.gameObject.SetActive(false);
        object3.SetActive(true);
    }
    private void OnSolutionBClicked()
    {
        if (audioSource1.isPlaying) audioSource1.Stop();


        textMeshPro1.gameObject.SetActive(false);
        textMeshPro2.gameObject.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(false);
        
        solutionB.gameObject.SetActive(false);
        solutionC.gameObject.SetActive(false);
        solutionAButton.gameObject.SetActive(false);
        explanation.SetActive(false);
        quiz.SetActive(false);
    }

    private void PlayAudioSource4()
    {
        audioSource4.Play();
    }
}
