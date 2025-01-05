using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlueInB : MonoBehaviour
{
    public float speed = 1.0f;
    public float upwardDistance = 5.0f;
    public float sidewaysDistance = 5.0f;
    public float downwardDistance = 5.0f;

    public GameObject blueButton;
    public GameObject handImage1;
    public GameObject handImage2;
    public GameObject handImage3;

    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;
    public TextMeshProUGUI textMeshPro3;
    public TextMeshProUGUI textMeshPro4;
    public TextMeshProUGUI textMeshPro5;
    public TextMeshProUGUI textMeshPro6;
    public TextMeshProUGUI textMeshPro7;
    public TextMeshProUGUI textMeshPro8;
    public TextMeshProUGUI textMeshPro9;
    public TextMeshProUGUI textMeshPro10;
    public TextMeshProUGUI textMeshPro11;
    public TextMeshProUGUI textMeshPro12;
    public TextMeshProUGUI textMeshPro13;
    public TextMeshProUGUI textMeshPro14;
    public TextMeshProUGUI textMeshPro15;
    public TextMeshProUGUI textMeshPro17;
    public TextMeshProUGUI solutionName;
    public TextMeshProUGUI solutionAName;
    public TextMeshProUGUI solutionBName;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioSource audioSource5;
    public AudioSource audioSource6;
    public AudioSource audioSource7;
    public Button liftButton;
    public Button finalButton;
    public Button solutionC;
    public Button redLitmusButton;
    public Button congratulationB;
    public Button nextLevelB;
    public Button explnation;
    public Button quiz;
    public GameObject object1;
    public GameObject object2; // Reference to object2
    public GameObject object3; // Reference to object3

    public GameObject tickB;
    public GameObject acidFinal;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    public GameObject object7;
    public GameObject object8;
    public GameObject object8FinalName;
    public GameObject tickA;
    public GameObject neutral;
    public GameObject objectB;

    public float liftUpwardDistance = 2.0f; // Public float for lift upward distance

    private Vector3 startPosition;
    private bool moveUp = false;
    private bool moveSideways = false;
    private bool moveDown = false;
    private bool lift = false; // Track lift movement
   

    void Start()
    {
        startPosition = transform.position;

        // Add listener to blueButton to call OnBlueButtonClick when clicked
        blueButton.GetComponent<Button>().onClick.AddListener(OnBlueButtonClick);

        // Add listener to liftButton to call OnLiftButtonClick when clicked
        liftButton.GetComponent<Button>().onClick.AddListener(OnLiftButtonClick);
        solutionC.GetComponent<Button>().onClick.AddListener(OnSolutionCButtonClick);
        nextLevelB.GetComponent<Button>().onClick.AddListener(OnNextLevelBButtonClick);

        // Initially hide textMeshPro3 and object3
        textMeshPro3.gameObject.SetActive(false);
        object3.SetActive(false);
        if (finalButton != null)
        {
            finalButton.onClick.AddListener(OnFinalButtonClick);
        }
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
            }
        }
        else if (moveDown)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y <= startPosition.y - downwardDistance)
            {
                moveDown = false;
                // Stop moving after completing the downward movement
                textMeshPro3.gameObject.SetActive(true);
                handImage2.SetActive(true);
                audioSource2.Play();
                StartCoroutine(OnAudioFinished(audioSource2));
                // Change the color of object2 to red
                object2.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else if (lift)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= startPosition.y + liftUpwardDistance)
            {
                lift = false;
                object3.SetActive(true); // Show object3 when lift movement is complete
                textMeshPro4.gameObject.SetActive(true);
                textMeshPro5.gameObject.SetActive(true);
                textMeshPro6.gameObject.SetActive(true);
                textMeshPro7.gameObject.SetActive(true);
                audioSource3.Play();
                StartCoroutine(OnAudio3Finished(audioSource3));
                finalButton.gameObject.SetActive(true);
            }
            textMeshPro3.gameObject.SetActive(false);
            handImage2.SetActive(false);
            audioSource2.Stop();
        }
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
        if (audioSource4 != null)
        {
            audioSource4.Play();
            StartCoroutine(OnAudio4Finished(audioSource4));
        }
    }
    private IEnumerator OnAudio4Finished(AudioSource audioSource)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Show the liftButton
        if (audioSource4 != null)
        {
            handImage3.SetActive(true);
        }
    }

    void OnBlueButtonClick()
    {
        moveUp = true;
        blueButton.SetActive(false);
        handImage1.SetActive(false);
        textMeshPro1.gameObject.SetActive(false);
        textMeshPro2.gameObject.SetActive(false);
        audioSource1.Stop();
    }

    void OnLiftButtonClick()
    {
        lift = true;
        liftButton.gameObject.SetActive(false); // Hide lift button after clicking
    }
    void OnFinalButtonClick()
    {
        object3.SetActive(false); // Show object3 when lift movement is complete
        textMeshPro4.gameObject.SetActive(false);
        textMeshPro5.gameObject.SetActive(false);
        textMeshPro6.gameObject.SetActive(false);
        textMeshPro7.gameObject.SetActive(false);
        audioSource3.Stop();
        audioSource4.Stop();
        object1.SetActive(false);
        finalButton.gameObject.SetActive(false);
        handImage3.SetActive(false);

        congratulationB.gameObject.SetActive(true);
        textMeshPro9.gameObject.SetActive(true);
        textMeshPro10.gameObject.SetActive(true);
        textMeshPro11.gameObject.SetActive(true);
        tickB.SetActive(true);
        acidFinal.SetActive(true);
        object4.SetActive(true);
        object5.SetActive(true);
        audioSource5.Play();
        CoroutineRunner.Instance.StartCoroutine(OnAudio5Finished(audioSource5));

        nextLevelB.gameObject.SetActive(true);

    }
    private IEnumerator OnAudio5Finished(AudioSource audioSource)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Show handImage4 only if nextLevelB was not clicked
        
    }
    void OnSolutionCButtonClick()
    {
        
        textMeshPro8.gameObject.SetActive(false);
        textMeshPro9.gameObject.SetActive(false);
        textMeshPro10.gameObject.SetActive(false);
        textMeshPro11.gameObject.SetActive(false);
        object4.SetActive(false);
        object5.SetActive(false);
        audioSource5.Stop();
        solutionC.gameObject.SetActive(false);
        
        textMeshPro13.gameObject.SetActive(true);
        textMeshPro14.gameObject.SetActive(true);
        redLitmusButton.gameObject.SetActive(true);
        object6.SetActive(true);
        solutionName.gameObject.SetActive(true);
        object7.SetActive(true);

        audioSource6.Play();

        textMeshPro15.gameObject.SetActive(false);
        textMeshPro17.gameObject.SetActive(false); // Forcefully activate textMeshPro17

        Debug.Log("textMeshPro17 active state: " + textMeshPro17.gameObject.activeSelf);

        solutionC.gameObject.SetActive(false);
        audioSource7.Stop();

        object8.SetActive(false);
        solutionAName.gameObject.SetActive(false);
        object8FinalName.SetActive(false);
        tickA.SetActive(false);
        explnation.gameObject.SetActive(false);
        quiz.gameObject.SetActive(false);
        tickB.SetActive(false);
        acidFinal.SetActive(false);
        solutionBName.gameObject.SetActive(false);
        objectB.SetActive(false);
    }
    void OnNextLevelBButtonClick()
    {
        // Indicate that nextLevelB has been clicked
      

        // Deactivate previous objects and audio
        congratulationB.gameObject.SetActive(false);
        textMeshPro9.gameObject.SetActive(false);
        textMeshPro10.gameObject.SetActive(false);
        textMeshPro11.gameObject.SetActive(false);
        object4.SetActive(false);
        object5.SetActive(false);
        audioSource5.Stop();
        nextLevelB.gameObject.SetActive(false);
       

        // Ensure textMeshPro17 is active, regardless of its previous state
        textMeshPro15.gameObject.SetActive(true);
        textMeshPro17.gameObject.SetActive(true); // Forcefully activate textMeshPro17

        Debug.Log("textMeshPro17 active state: " + textMeshPro17.gameObject.activeSelf);

        solutionC.gameObject.SetActive(true);


        object8.SetActive(true);
        solutionAName.gameObject.SetActive(true);
        object8FinalName.SetActive(true);
        tickA.SetActive(true);
        explnation.gameObject.SetActive(true);
        quiz.gameObject.SetActive(true);
    }

}