using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RedInC : MonoBehaviour
{
    public float speed = 1.0f;
    public float upwardDistance = 5.0f;
    public float sidewaysDistance = 5.0f;
    public float downwardDistance = 5.0f;
    public float liftUpwardDistance = 5.0f; // New public float

    public GameObject redButton;
    public Button liftButton;
    public Button nextButton;
    public Button blueButton;

    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;
    public TextMeshProUGUI textMeshPro3;
    public TextMeshProUGUI textMeshPro4;
    public TextMeshProUGUI textMeshPro5;
    public TextMeshProUGUI textMeshPro6;
    public TextMeshProUGUI textMeshPro7;
    public TextMeshProUGUI textMeshPro8;
    public TextMeshProUGUI textMeshPro9;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;

    public GameObject handImage1;
    public GameObject handImage2;

    public GameObject object3;
    public GameObject object1;
    public GameObject object4;

    private Vector3 startPosition;
    private bool moveUp = false;
    private bool moveSideways = false;
    private bool moveDown = false;
    private bool liftUp = false; // New flag for liftButton

    void Start()
    {
        startPosition = transform.position;

        redButton.GetComponent<Button>().onClick.AddListener(OnRedButtonClick);
        liftButton.onClick.AddListener(OnLiftButtonClick); // Listener for liftButton
        nextButton.onClick.AddListener(OnNextButtonClick);

        textMeshPro3.gameObject.SetActive(false);
        liftButton.gameObject.SetActive(false); // Ensure liftButton starts inactive
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

                textMeshPro3.gameObject.SetActive(true);
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
                liftUp = false;
                textMeshPro4.gameObject.SetActive(true);
                textMeshPro5.gameObject.SetActive(true);
                textMeshPro6.gameObject.SetActive(true);
                textMeshPro7.gameObject.SetActive(true);
                object3.SetActive(true);
                audioSource3.Play();
                StartCoroutine(OnAudio3Finished(audioSource3));
                nextButton.gameObject.SetActive(true);
            }
        }
    }

    void OnRedButtonClick()
    {
        moveUp = true;
        redButton.SetActive(false);
        textMeshPro1.gameObject.SetActive(false);
        textMeshPro2.gameObject.SetActive(false);
        audioSource1.Stop();
    }

    void OnLiftButtonClick()
    {
        liftUp = true;
        liftButton.gameObject.SetActive(false); // Hide liftButton when used
        textMeshPro3.gameObject.SetActive(false);
        handImage1.SetActive(false);
        
    }
    void OnNextButtonClick()
    {
        textMeshPro4.gameObject.SetActive(false);
        textMeshPro5.gameObject.SetActive(false);
        textMeshPro6.gameObject.SetActive(false);
        textMeshPro7.gameObject.SetActive(false);
        object3.SetActive(false);
        audioSource3.Stop();
        nextButton.gameObject.SetActive(false);
        handImage2.SetActive(false);
        object1.SetActive(false);
        object4.SetActive(true);
        textMeshPro8.gameObject.SetActive(true);
        textMeshPro9.gameObject.SetActive(true);
        blueButton.gameObject.SetActive(true);
        audioSource4.Play();
    }

    private IEnumerator OnAudioFinished(AudioSource audioSource)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);

        if (liftButton != null)
        {
            liftButton.gameObject.SetActive(true);
        }
    }
    private IEnumerator OnAudio3Finished(AudioSource audioSource)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);

        if (handImage2 != null)
        {
            handImage2.SetActive(true);
        }
    }
}
