using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class RedLitmusInA : MonoBehaviour
{
    public float upwardDistance = 5f;
    public float sidewaysDistance = 3f;
    public float downwardDistance = 5f;
    public float liftUpwardDistance = 2f;
    public float speed = 2f;
    public GameObject object2; // Reference to Object2
    public GameObject object3; // Reference to Object3
    public GameObject object1; // Reference to Object1
    public GameObject object4; // Reference to Object4 
    public GameObject object5;
    public GameObject object6;
    public GameObject handImage2;
    public GameObject handImage3;
    public GameObject handImage4;
    // Reference to handImage2
    public TextMeshProUGUI textMeshPro1; // Reference to TextMeshPro1
    public TextMeshProUGUI textMeshPro2; // Reference to TextMeshPro2
    public TextMeshProUGUI textMeshPro3; // Reference to TextMeshPro3
    public TextMeshProUGUI textMeshPro4; // Reference to TextMeshPro4
    public TextMeshProUGUI textMeshPro5; // Reference to TextMeshPro5
    public TextMeshProUGUI textMeshPro6; // Reference to TextMeshPro6
    public TextMeshProUGUI textMeshPro7; // Reference to TextMeshPro7
    public TextMeshProUGUI textMeshPro8; // Reference to TextMeshPro8
    public TextMeshProUGUI textMeshPro9;
    public TextMeshProUGUI textMeshPro10;
    public TextMeshProUGUI textMeshPro11;
    public AudioSource audioSource5; // Reference to AudioSource5
    public AudioSource audioSource6; // Reference to AudioSource6
    public AudioSource audioSource7; // Reference to AudioSource7
    public AudioSource audioSource8; // Reference to AudioSource8
    public AudioSource audioSource9; // Reference to AudioSource9
    public Button liftButton; // Change type to Button
    public Button nextButton;
    public Button blueButton; // Reference to BlueButton
   

    private Vector3 initialPosition;
    private bool isMoving = false;
    private bool colorChanged = false;

    void Start()
    {
        initialPosition = transform.position;
       
        

        if (handImage2 != null)
        {
            handImage2.SetActive(false); // Ensure handImage2 is initially hidden
        }

        if (textMeshPro2 != null)
        {
            textMeshPro2.gameObject.SetActive(false); // Ensure textMeshPro2 is initially hidden
        }

        if (liftButton != null)
        {
            liftButton.gameObject.SetActive(false); // Ensure liftButton is initially hidden
            liftButton.onClick.AddListener(OnLiftButtonClick); // Register OnLiftButtonClick to the button's onClick event
        }

        if (textMeshPro3 != null)
        {
            textMeshPro3.gameObject.SetActive(false); // Ensure textMeshPro3 is initially hidden
        }

        if (textMeshPro4 != null)
        {
            textMeshPro4.gameObject.SetActive(false); // Ensure textMeshPro4 is initially hidden
        }

        if (textMeshPro5 != null)
        {
            textMeshPro5.gameObject.SetActive(false); // Ensure textMeshPro5 is initially hidden
        }

        if (textMeshPro6 != null)
        {
            textMeshPro6.gameObject.SetActive(false); // Ensure textMeshPro6 is initially hidden
        }

        if (object3 != null)
        {
            object3.SetActive(false); 
        }

        if (textMeshPro7 != null)
        {
            textMeshPro7.gameObject.SetActive(false); // Ensure textMeshPro7 is initially hidden
        }

        if (textMeshPro8 != null)
        {
            textMeshPro8.gameObject.SetActive(false); // Ensure textMeshPro8 is initially hidden
        }

        if (object4 != null)
        {
            object4.SetActive(false); // Ensure object4 is initially hidden
        }

        if (blueButton != null)
        {
            blueButton.gameObject.SetActive(false); // Ensure blueButton is initially hidden
        }

        if (nextButton != null)
        {
            nextButton.onClick.AddListener(OnNextButtonClick); // Register OnNextButtonClick to the button's onClick event
        }
        
    }

    public void OnButtonClick()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveObject());
        }
    }
 

    public void OnLiftButtonClick()
    {
        if (!isMoving)
        {
            StartCoroutine(LiftObject());
            // Deactivate textMeshPro2, handImage2, and liftButton
            if (textMeshPro2 != null)
            {
                textMeshPro2.gameObject.SetActive(false);
            }
            if (handImage2 != null)
            {
                handImage2.SetActive(false);
            }
            if (liftButton != null)
            {
                liftButton.gameObject.SetActive(false);
            }
            if (nextButton != null)
            {
                nextButton.gameObject.SetActive(true);
            }
        }
    }

    public void OnNextButtonClick()
    {
        if (textMeshPro3 != null)
        {
            textMeshPro3.gameObject.SetActive(false);
        }
        if (textMeshPro4 != null)
        {
            textMeshPro4.gameObject.SetActive(false);
        }
        if (textMeshPro5 != null)
        {
            textMeshPro5.gameObject.SetActive(false);
        }
        if (textMeshPro6 != null)
        {
            textMeshPro6.gameObject.SetActive(false);
        }
        if (object3 != null)
        {
            object3.SetActive(false);
        }
        if (object1 != null)
        {
            object1.SetActive(false);
        }
        if (object4 != null)
        {
            object4.SetActive(true);
        }
        if (blueButton != null)
        {
            blueButton.gameObject.SetActive(true);
        }
        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(false);
        }
        if (textMeshPro7 != null)
        {
            textMeshPro7.gameObject.SetActive(true);
        }
        if (textMeshPro8 != null)
        {
            textMeshPro8.gameObject.SetActive(true);
        }
        if (audioSource9 != null)
        {
            audioSource9.Play();
        }
        if (handImage4 != null)
        {
            handImage4.SetActive(false);
        }
        if (audioSource6 != null)
        {
            audioSource6.Stop();
        }
        if (audioSource7 != null)
        {
            audioSource7.Stop();
        }
        if (audioSource8 != null)
        {
            audioSource8.Stop();
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
        yield return StartCoroutine(MoveToPositionWithColorChange(targetPosition));

        isMoving = false;
    }

    private IEnumerator LiftObject()
    {
        isMoving = true;
        Vector3 initialLiftPosition = transform.position;
        Vector3 targetPosition = transform.position + Vector3.up * liftUpwardDistance;
        float distanceToReach = liftUpwardDistance * 0.7f;

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, initialLiftPosition) >= distanceToReach)
            {
                // Make objects appear and play audio
                if (textMeshPro3 != null)
                {
                    textMeshPro3.gameObject.SetActive(true);
                }

                if (textMeshPro4 != null)
                {
                    textMeshPro4.gameObject.SetActive(true);
                }

                if (textMeshPro5 != null)
                {
                    textMeshPro5.gameObject.SetActive(true);
                }

                if (textMeshPro6 != null)
                {
                    textMeshPro6.gameObject.SetActive(true);
                }

                if (object3 != null)
                {
                    object3.SetActive(true);
                }

                if (audioSource6 != null && !audioSource6.isPlaying)
                {
                    audioSource6.Play();
                    StartCoroutine(PlayNextAudio());
                }

                break;
            }

            yield return null;
        }
        transform.position = targetPosition;

        isMoving = false;
    }

    private IEnumerator PlayNextAudio()
    {
        if (audioSource6 != null)
        {
            yield return new WaitForSeconds(audioSource6.clip.length + 1f);
        }

        if (audioSource7 != null)
        {
            audioSource7.Play();
            yield return new WaitForSeconds(audioSource7.clip.length + 0f); // Wait for audioSource7 to finish and an additional second
        }

        if (audioSource8 != null)
        {
            audioSource8.Play();
            StartCoroutine(OnAudioFinished(audioSource8));
        }
    }

    private IEnumerator OnAudioFinished(AudioSource audioSource)
    {
        
        // Wait for an additional 2 seconds after audioSource8 finishes playing
        yield return new WaitForSeconds(2f);

        // Hide textMeshPro3, textMeshPro4, textMeshPro5, textMeshPro6, object1, and object3
        if (handImage4 != null)
        {
            handImage4.SetActive(true); // Ensure handImage2 is initially hidden
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

    private IEnumerator MoveToPositionWithColorChange(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;

        // Change the color of object2 to color2
        Renderer objectRenderer = object2.GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            objectRenderer.material.color = Color.blue; // Change this to your desired color
            colorChanged = true; // Set colorChanged to true when the color change occurs
            // Perform actions based on color change
            if (colorChanged)
            {
                // Hide textMeshPro1
                if (textMeshPro1 != null)
                {
                    textMeshPro1.gameObject.SetActive(false);
                }

                // Show textMeshPro2
                if (textMeshPro2 != null)
                {
                    textMeshPro2.gameObject.SetActive(true);
                }

                // Play audioSource5
                if (audioSource5 != null && !audioSource5.isPlaying)
                {
                    audioSource5.Play();
                }

                // Show handImage2
                if (handImage2 != null)
                {
                    handImage2.SetActive(true);
                }

                // Show liftButton after a 3-second delay
                if (liftButton != null)
                {
                    StartCoroutine(ShowLiftButtonAfterDelay(3f));
                }
            }
        }
    }

    private IEnumerator ShowLiftButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (liftButton != null)
        {
            liftButton.gameObject.SetActive(true);
        }
    }
    
}
