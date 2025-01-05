using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class RedInB : MonoBehaviour
{
    public float upwardDistance = 5f;
    public float sidewaysDistance = 3f;
    public float downwardDistance = 5f;
    public float liftUpwardDistance = 3f; // New public float for lift button
    public float speed = 2f;
    public Button redLitmus; // Reference to the redLitmus button
    public Button liftButton;
    public Button nextButton;
    public Button blueButton;
    public Button pauseButton;
    public Button resumeButton;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public TextMeshProUGUI textMeshPro1; // Reference to the TextMeshPro object
    public TextMeshProUGUI textMeshPro2;
    public TextMeshProUGUI textMeshPro3;
    public TextMeshProUGUI textMeshPro4; // New TextMeshPro objects
    public TextMeshProUGUI textMeshPro5;
    public TextMeshProUGUI textMeshPro6;
    public TextMeshProUGUI textMeshPro7;
    public TextMeshProUGUI textMeshPro8;
    public TextMeshProUGUI textMeshPro9;

    public GameObject handImage1;
    public GameObject handImage2; // Reference to the new hand image
    public GameObject handImage3;
    public GameObject object2; // New GameObject reference
    public GameObject object1;
    public GameObject blueObject;

    private Vector3 initialPosition;
    private bool isMoving = false;
    private bool isPaused = false; // New boolean for pause state
    private Coroutine audioCoroutine; // Store the coroutine reference

    void Start()
    {
        initialPosition = transform.position;

        // Add listeners to buttons
        if (redLitmus != null) redLitmus.onClick.AddListener(OnRedLitmusClick);
        if (liftButton != null) liftButton.onClick.AddListener(OnLiftButtonClick);
        if (nextButton != null) nextButton.onClick.AddListener(OnNextButtonClick);
        if (pauseButton != null) pauseButton.onClick.AddListener(OnPauseButtonClick);
        if (resumeButton != null) resumeButton.onClick.AddListener(OnResumeButtonClick);
    }

    public void OnRedLitmusClick()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveObject());
        }
        audioSource1.Stop();
        redLitmus.gameObject.SetActive(false);
    }

    public void OnLiftButtonClick()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveUpward(liftUpwardDistance));
        }
        handImage1.SetActive(false);
        textMeshPro3.gameObject.SetActive(false);
        liftButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
        audioSource2.Stop();
    }

    public void OnNextButtonClick()
    {
        textMeshPro4.gameObject.SetActive(false);
        textMeshPro5.gameObject.SetActive(false);
        textMeshPro6.gameObject.SetActive(false);
        textMeshPro7.gameObject.SetActive(false);
        object2.SetActive(false);
        handImage2.SetActive(false);
        object1.SetActive(false);
        nextButton.gameObject.SetActive(false);
        audioSource3.Stop();
        textMeshPro8.gameObject.SetActive(true);
        textMeshPro9.gameObject.SetActive(true);
        blueButton.gameObject.SetActive(true);
        blueObject.SetActive(true);
        handImage3.SetActive(true);
        audioSource4.Play();
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

        // Disable TextMeshPro when downward movement is completed
        if (textMeshPro1 != null)
        {
            textMeshPro1.gameObject.SetActive(false);
            textMeshPro2.gameObject.SetActive(false);
            textMeshPro3.gameObject.SetActive(true);
            handImage1.SetActive(true);
            audioSource2.Play();
            if (audioCoroutine == null)
            {
                audioCoroutine = StartCoroutine(OnAudioFinished(audioSource2));
            }
        }

        isMoving = false;
    }

    private IEnumerator MoveUpward(float distance)
    {
        isMoving = true;

        Vector3 targetPosition = transform.position + Vector3.up * distance;

        // Move to the target position
        yield return StartCoroutine(MoveToPosition(targetPosition));

        // Show the TextMeshPro objects and object2 when the target position is reached
        ShowTextMeshAndObject();

        isMoving = false;
    }

    private void ShowTextMeshAndObject()
    {
        if (textMeshPro4 != null) textMeshPro4.gameObject.SetActive(true);
        if (textMeshPro5 != null) textMeshPro5.gameObject.SetActive(true);
        if (textMeshPro6 != null) textMeshPro6.gameObject.SetActive(true);
        if (textMeshPro7 != null) textMeshPro7.gameObject.SetActive(true);
        if (object2 != null) object2.SetActive(true);
        if (audioSource3 != null)
        {
            audioSource3.Play();
            StartCoroutine(OnAudio3Finished(audioSource3));
        }
    }

    private IEnumerator OnAudioFinished(AudioSource audioSource)
    {
        while (audioSource.isPlaying || isPaused)
        {
            yield return null; // Wait while the audio is playing or the game is paused
        }

        // Ensure downwardDistance is completed and liftButton is not clicked
        if (!isMoving && liftButton != null && !liftButton.gameObject.activeSelf)
        {
            liftButton.gameObject.SetActive(true);
        }
    }

    private IEnumerator OnAudio3Finished(AudioSource audioSource)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Show handImage2 when audioSource3 finishes playing
        if (handImage2 != null)
        {
            handImage2.SetActive(true);
        }
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

    public void OnPauseButtonClick()
    {
        isPaused = true;
    }

    public void OnResumeButtonClick()
    {
        isPaused = false;
    }
}
