using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BlueInC : MonoBehaviour
{
    public float speed = 1.0f;
    public float upwardDistance = 5.0f;
    public float sidewaysDistance = 5.0f;
    public float downwardDistance = 5.0f;
    public float liftUpwardDistance = 3.0f; // New public float for liftButton upward distance

    public GameObject blueButton;
    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;
    public TextMeshProUGUI textMeshPro3;
    public TextMeshProUGUI textMeshPro4; // Added TextMeshPro4
    public TextMeshProUGUI textMeshPro5;
    public TextMeshProUGUI textMeshPro6;
    public TextMeshProUGUI textMeshPro7;
    public TextMeshProUGUI textMeshPro8;
  
    public TextMeshProUGUI textMeshPro10;
    public TextMeshProUGUI textMeshPro11;
    public TextMeshProUGUI solutionBName;
    public TextMeshProUGUI solutionAName;
    public TextMeshProUGUI remarks;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public GameObject handImage1;
    public GameObject handImage2;
    public GameObject solutionBObject;
    public GameObject solutionAObject;
    public GameObject solutionBTick;
    public GameObject solutionATick;
    public GameObject celebration;

    public Button liftButton;
    public Button finalButton;
    public Button congratulations;
    public Button lastNext;
    
    public Button explanation;
    public Button quiz;
    public Button SolutionBFinalName;
    public Button SolutionAFinalName;
    public Button gameCompleted;
    public Button nextExperiment;
    public Button tryAgainExperiment;
    public Button pauseButton;
    public Button resumeButton;

    public GameObject object3;
    public GameObject object1;
    public GameObject object4;
    public GameObject tick;
    public GameObject neutral;

    private Vector3 startPosition;
    private bool moveUp = false;
    private bool moveSideways = false;
    private bool moveDown = false;
    private bool liftUp = false; // New flag for liftButton upward movement
    private bool finalButtonClicked = false;
    private bool tryAgainExperimentClicked = false;
    private bool isPaused = false;

    void Start()
    {
        startPosition = transform.position;

        // Add listener to blueButton to call OnBlueButtonClick when clicked
        blueButton.GetComponent<Button>().onClick.AddListener(OnBlueButtonClick);

        // Add listener to liftButton to call OnLiftButtonClick when clicked
        liftButton.onClick.AddListener(OnLiftButtonClick);
        finalButton.onClick.AddListener(OnFinalButtonClick);
        lastNext.onClick.AddListener(OnLastNextButtonClick);
        pauseButton.onClick.AddListener(OnPauseButtonClick);
        resumeButton.onClick.AddListener(OnResumeButtonClick);
        tryAgainExperiment.onClick.AddListener(OnTryAgainExperimentClick);
    }

    void Update()
    {
        if (moveUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= startPosition.y + upwardDistance)
            {
                moveUp = false;
                moveSideways = true;
            }
        }
        else if (moveSideways)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= startPosition.x - sidewaysDistance)
            {
                moveSideways = false;
                moveDown = true;
                textMeshPro1.gameObject.SetActive(true); // Ensure textMeshPro1 is visible during the downward movement
            }
        }
        else if (moveDown)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y <= startPosition.y - downwardDistance)
            {
                moveDown = false;
                textMeshPro1.gameObject.SetActive(false); // Hide textMeshPro1 after completing downward movement
                textMeshPro3.gameObject.SetActive(false);
                textMeshPro2.gameObject.SetActive(true);
                handImage1.SetActive(true);
                audioSource2.Play();
                StartCoroutine(OnAudioFinished(audioSource2));
            }
        }
        else if (liftUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= startPosition.y + liftUpwardDistance)
            {
                liftUp = false; // Stop lifting when the desired height is reached
                textMeshPro4.gameObject.SetActive(true); // Show textMeshPro4 when liftUpwardDistance is completed
                textMeshPro5.gameObject.SetActive(true);
                textMeshPro6.gameObject.SetActive(true);
                textMeshPro7.gameObject.SetActive(true);
                object3.SetActive(true);
                audioSource3.Play();
                StartCoroutine(OnAudio3Finished(audioSource3));
                finalButton.gameObject.SetActive(true);
            }
        }
    }

    void OnPauseButtonClick()
    {
        if (finalButtonClicked && !tryAgainExperimentClicked)
        {
            lastNext.gameObject.SetActive(false);
            isPaused = true;
        }
    }
    void OnResumeButtonClick()
    {
        if (isPaused && finalButtonClicked && !tryAgainExperimentClicked)
        {
            lastNext.gameObject.SetActive(true);
            isPaused = false;
        }
    }
    void OnTryAgainExperimentClick()
    {
        tryAgainExperimentClicked = true;
    }
    void OnBlueButtonClick()
    {
        moveUp = true;
        blueButton.SetActive(false);
        audioSource1.Stop();
    }

    void OnLiftButtonClick()
    {
        liftUp = true;
        liftButton.gameObject.SetActive(false); // Optional: Hide the liftButton after it's clicked
        textMeshPro2.gameObject.SetActive(false);
        handImage1.SetActive(false);
    }
    void OnFinalButtonClick()
    {
        finalButtonClicked = true;
        textMeshPro4.gameObject.SetActive(false); // Show textMeshPro4 when liftUpwardDistance is completed
        textMeshPro5.gameObject.SetActive(false);
        textMeshPro6.gameObject.SetActive(false);
        textMeshPro7.gameObject.SetActive(false);
        audioSource3.Stop();
        finalButton.gameObject.SetActive(false);
        handImage2.SetActive(false);
        object1.SetActive(false);
        textMeshPro8.gameObject.SetActive(true);
        
        textMeshPro10.gameObject.SetActive(true);
        textMeshPro11.gameObject.SetActive(true);
        object4.SetActive(true);
        audioSource4.Play();
        tick.SetActive(true);
        neutral.SetActive(true);
        congratulations.gameObject.SetActive(true);
        lastNext.gameObject.SetActive(true);
       
    }
    void OnLastNextButtonClick()
    {
        textMeshPro8.gameObject.SetActive(false);

        textMeshPro10.gameObject.SetActive(false);
        textMeshPro11.gameObject.SetActive(false);
        object4.SetActive(false);
        audioSource4.Stop();
        
        
        
        lastNext.gameObject.SetActive(false);
        
        object3.SetActive(false);
        explanation.gameObject.SetActive(true);
        quiz.gameObject.SetActive(true);
        solutionBName.gameObject.SetActive(true);
        solutionBObject.SetActive(true);
        solutionBTick.gameObject.SetActive(true);
        SolutionBFinalName.gameObject.SetActive(true);
        solutionATick.gameObject.SetActive(true);
        solutionAObject.SetActive(true);
        solutionAName.gameObject.SetActive(true);
        SolutionAFinalName.gameObject.SetActive(true);
        gameCompleted.gameObject.SetActive(true);
        remarks.gameObject.SetActive(true);
        congratulations.gameObject.SetActive(false);
        celebration.gameObject.SetActive(true);
        tryAgainExperiment.gameObject.SetActive(true);
        nextExperiment.gameObject.SetActive(true);
    }

    private IEnumerator OnAudioFinished(AudioSource audioSource)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Show the liftButton
        if (liftButton != null)
        {
            liftButton.gameObject.SetActive(true);
        }
    }
    private IEnumerator OnAudio3Finished(AudioSource audioSource)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Show the liftButton
        if (!finalButtonClicked && handImage2 != null)
        {
            handImage2.SetActive(true);
        }
    }
}
