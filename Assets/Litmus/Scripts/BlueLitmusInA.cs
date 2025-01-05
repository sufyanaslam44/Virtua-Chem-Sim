using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlueLitmusInA : MonoBehaviour
{
    public float upwardDistance = 5f;
    public float sidewaysDistance = 3f;
    public float downwardDistance = 5f;
    public float liftUpwardDistance = 5f;
    public float speed = 2f;
    public AudioSource audioSource9;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource6;
    
    public AudioSource audioSource5;
    // References to TextMeshPro objects
    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;
    public TextMeshProUGUI textMeshPro3;
    public TextMeshProUGUI textMeshPro4;
    public TextMeshProUGUI textMeshPro5; // Reference to TextMeshPro5
    public TextMeshProUGUI textMeshPro6; // Reference to TextMeshPro6
    public TextMeshProUGUI textMeshPro7; // Reference to TextMeshPro7
    public TextMeshProUGUI textMeshPro8; // Reference to TextMeshPro8
    public TextMeshProUGUI textMeshPro9;
    public TextMeshProUGUI textMeshPro10;
    public TextMeshProUGUI textMeshPro11;
    public TextMeshProUGUI textMeshPro12;
    public TextMeshProUGUI textMeshPro13;
    public TextMeshProUGUI textMeshPro14;
    public TextMeshProUGUI textMeshPro15;
    public TextMeshProUGUI textMeshPro16;
    public TextMeshProUGUI textMeshPro17;
    public TextMeshProUGUI textMeshPro18;
    public TextMeshProUGUI textMeshPro19;
    // References to additional objects
    public GameObject handImage2;
    public GameObject handImage3;
   
    public GameObject tickA;
    public AudioSource audioSource1;
    public Button liftButton;
    public Button finalResult;
    public Button solutionB;
    public Button finalAlkaline;
    public Button redLitmus;
    public Button nextAlkalineButton;
    public Button congratulations;
    public Button solutionC;
    public Button explanation;
    public Button quiz;
    public Button level3locked;
    public GameObject object2;
    public GameObject object1;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    public GameObject objectA;
    public GameObject objectC;
    public GameObject objectB;
    private Vector3 initialPosition;
    private bool isMoving = false;
    
    
    private bool isNextAlkalineButtonClicked = false;

    void Start()
    {

        initialPosition = transform.position;
       
        liftButton.onClick.AddListener(OnLiftButtonClick);
        finalResult.onClick.AddListener(OnFinalResultClick);
        solutionB.onClick.AddListener(OnSolutionBClick);
        nextAlkalineButton.onClick.AddListener(OnNextAlkalineButtonClick);

        
    }
    public void OnButtonClick()
    {
        if (audioSource9.isPlaying)
        {
            audioSource9.Stop();
        }

        // Update TextMeshPro visibility
        textMeshPro1.gameObject.SetActive(false);
        textMeshPro2.gameObject.SetActive(false);
        textMeshPro3.gameObject.SetActive(true);

        if (!isMoving)
        {
            StartCoroutine(MoveObject());
        }
    }

    private IEnumerator MoveObject()
    {
        isMoving = true;

        // Move upward
        Vector3 targetPosition = initialPosition + Vector3.up * upwardDistance;
        yield return StartCoroutine(MoveToPosition(targetPosition));

        // Move left (negative x axis)
        targetPosition += Vector3.left * sidewaysDistance;
        yield return StartCoroutine(MoveToPosition(targetPosition));

        // Move downward (negative y axis)
        targetPosition += Vector3.down * downwardDistance;
        yield return StartCoroutine(MoveToPosition(targetPosition));

        // Make textMeshPro3 disappear
        textMeshPro3.gameObject.SetActive(false);

        // Make textMeshPro4 appear
        textMeshPro4.gameObject.SetActive(true);

        // Make handImage2 appear
        handImage2.SetActive(true);

        // Play audioSource1
        audioSource1.Play();

        // Make liftButton appear
        liftButton.gameObject.SetActive(true);

        isMoving = false;
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }

    public void OnLiftButtonClick()
    {
        if (!isMoving)
        {
            StartCoroutine(LiftObject());

            // Stop audioSource1
            if (audioSource1.isPlaying)
            {
                audioSource1.Stop();
            }

            // Make textMeshPro4 disappear
            textMeshPro4.gameObject.SetActive(false);

            // Make handImage2 disappear
            handImage2.SetActive(false);

            // Make liftButton disappear
            liftButton.gameObject.SetActive(false);
        }
    }

    private IEnumerator LiftObject()
    {
        isMoving = true;

        // Move upward by liftUpwardDistance
        Vector3 targetPosition = transform.position + Vector3.up * liftUpwardDistance;
        yield return StartCoroutine(MoveToPosition(targetPosition));

        isMoving = false;

        // Make textMeshPro5, textMeshPro6, textMeshPro7, textMeshPro8 appear
        textMeshPro5.gameObject.SetActive(true);
        textMeshPro6.gameObject.SetActive(true);
        textMeshPro7.gameObject.SetActive(true);
        textMeshPro8.gameObject.SetActive(true);
        object2.SetActive(true);
        audioSource2.Play();
        StartCoroutine(OnAudioFinished(audioSource2));


        finalResult.gameObject.SetActive(true);
    }

    private IEnumerator OnAudioFinished(AudioSource audioSource)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Wait for an additional 2 seconds after audioSource8 finishes playing
        yield return new WaitForSeconds(2f);

        // Hide textMeshPro3, textMeshPro4, textMeshPro5, textMeshPro6, object1, and object3
        if (handImage3 != null)
        {
            handImage3.SetActive(true); // Ensure handImage2 is initially hidden
        }
    }

    public void OnFinalResultClick()
    {
        // Make textMeshPro5 disappear
        textMeshPro5.gameObject.SetActive(false);
        textMeshPro6.gameObject.SetActive(false);
        textMeshPro7.gameObject.SetActive(false);
        textMeshPro8.gameObject.SetActive(false);
        object1.SetActive(false);
        object2.SetActive(false);
        finalResult.gameObject.SetActive(false);
        audioSource2.Stop();
        handImage3.SetActive(false);
        textMeshPro9.gameObject.SetActive(true);
        textMeshPro10.gameObject.SetActive(true);
        textMeshPro11.gameObject.SetActive(true);
        textMeshPro12.gameObject.SetActive(true);
        object3.SetActive(true);
        object4.SetActive(true);
        nextAlkalineButton.gameObject.SetActive(true);
        congratulations.gameObject.SetActive(true);
        finalAlkaline.gameObject.SetActive(true);
        tickA.SetActive(true);
        audioSource3.Play();
        CoroutineRunner.Instance.StartCoroutine(OnAudioSource3Finished());
    }

    private IEnumerator OnAudioSource3Finished()
    {
        yield return new WaitWhile(() => audioSource3.isPlaying);
        yield return new WaitForSeconds(2f);

        // Only show handImage4 if nextAlkalineButton has NOT been clicked
        
    }
    public void OnSolutionBClick()
    {
        // Set the flag to true when solutionB is clicked

        textMeshPro13.gameObject.SetActive(true);
        textMeshPro15.gameObject.SetActive(true);
        textMeshPro16.gameObject.SetActive(true);

        object5.SetActive(true);
        object6.SetActive(true);

        redLitmus.gameObject.SetActive(true);
        tickA.SetActive(true);
        audioSource5.Play();

        solutionC.gameObject.SetActive(false);
        objectC.SetActive(false);
        solutionB.gameObject.SetActive(false);

        explanation.gameObject.SetActive(false);
        quiz.gameObject.SetActive(false);
        textMeshPro18.gameObject.SetActive(false);
        textMeshPro19.gameObject.SetActive(false);
        audioSource6.Stop();

        tickA.SetActive(false);
        objectA.SetActive(false);
        textMeshPro17.gameObject.SetActive(false); // Ensure textMeshPro17 is deactivated
        finalAlkaline.gameObject.SetActive(false);
        level3locked.gameObject.SetActive(false);
    }

    public void OnNextAlkalineButtonClick()
    {
        isNextAlkalineButtonClicked = true;  // Track that nextAlkalineButton was clicked

        textMeshPro9.gameObject.SetActive(false);
        textMeshPro10.gameObject.SetActive(false);
        textMeshPro11.gameObject.SetActive(false);
        textMeshPro12.gameObject.SetActive(false);
        textMeshPro14.gameObject.SetActive(false);
        object3.SetActive(false);
        object4.SetActive(false);
        
        audioSource3.Stop();

        // Hide handImage4 if it's active
        

        congratulations.gameObject.SetActive(false);
        nextAlkalineButton.gameObject.SetActive(false);
        solutionB.gameObject .SetActive(true);
      
        
        explanation.gameObject.SetActive(true);
        quiz.gameObject.SetActive(true);
        textMeshPro18.gameObject.SetActive(true);
        textMeshPro19.gameObject.SetActive(true);
        
        level3locked.gameObject.SetActive(true);
    }
}
