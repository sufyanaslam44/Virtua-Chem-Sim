using UnityEngine;
using UnityEngine.UI;
using LiquidVolumeFX;
using TMPro;
using System.Collections;

public class DropWiseBurette : MonoBehaviour
{
    public LiquidVolume liquidVolume;
    public Button dropWiseButton;
    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;
    public TextMeshProUGUI textMeshPro3;
    public TextMeshProUGUI textMeshPro4;
    public TextMeshProUGUI textMeshPro6;
    public Button calculateButton;
    public TextMeshProUGUI textMeshPro5;
    public Image image1; // Reference to Image1
    public Image image2; // Reference to Image2
    public AudioSource audioSource1; // Reference to AudioSource1
    public AudioSource audioSource2; // Reference to AudioSource2
    public AudioSource audioSource3; // Reference to AudioSource3

    private int clickCount = 0;
    private Color[] colors = new Color[]
    {
        new Color(1.0f, 0.75f, 0.8f), // Light Pink
        new Color(1.0f, 0.6f, 0.7f),  // Pink
        
    };

    void Start()
    {
        dropWiseButton.onClick.AddListener(ChangeColor);
        textMeshPro2.gameObject.SetActive(false);
        textMeshPro3.gameObject.SetActive(false);
        textMeshPro4.gameObject.SetActive(false);
        calculateButton.gameObject.SetActive(false);
        textMeshPro5.gameObject.SetActive(false);
        image1.gameObject.SetActive(false); // Ensure Image1 is initially hidden
        image2.gameObject.SetActive(false); // Ensure Image2 is initially hidden
    }

    void ChangeColor()
    {
        clickCount++;
        if (clickCount >= colors.Length)
        {
            clickCount = 0; // Reset to start from very light pink again
        }

        liquidVolume.liquidColor1 = colors[clickCount];

        if (clickCount == 1)
        {
            dropWiseButton.gameObject.SetActive(false);
            textMeshPro6.gameObject.SetActive(false);
            textMeshPro1.gameObject.SetActive(false);
            textMeshPro2.gameObject.SetActive(true);
            image1.gameObject.SetActive(true); // Show Image1 along with textMeshPro2
            audioSource1.Play(); // Play the audio when textMeshPro2 appears
            StartCoroutine(HideTextMeshPro2AfterDelay(5.0f));
        }
    }

    IEnumerator HideTextMeshPro2AfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        textMeshPro2.gameObject.SetActive(false);
        image1.gameObject.SetActive(false); // Hide Image1 along with textMeshPro2
        textMeshPro3.gameObject.SetActive(true);
        image2.gameObject.SetActive(true); // Show Image2 along with textMeshPro3
        audioSource2.Play(); // Play the audio when textMeshPro3 appears
        textMeshPro4.gameObject.SetActive(true);
        StartCoroutine(HideTextMeshPro3AfterDelay(5.0f));
    }

    IEnumerator HideTextMeshPro3AfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        textMeshPro3.gameObject.SetActive(false);
        image2.gameObject.SetActive(false); // Hide Image2 along with textMeshPro3
        calculateButton.gameObject.SetActive(true);
        textMeshPro5.gameObject.SetActive(true);
        audioSource3.Play(); // Play the audio when calculateButton appears
    }
}
