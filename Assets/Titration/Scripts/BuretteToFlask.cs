using UnityEngine;
using LiquidVolumeFX;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro; // Import TextMesh Pro namespace
using System.Collections;

public class BuretteToFlask : MonoBehaviour
{
    public LiquidVolume liquidVolumeObject1;
    public LiquidVolume liquidVolumeObject2;
    public float changeRate = 0.1f; // Adjust this value to control the speed of change
    public Button pourButton; // Reference to the PourButton
    public Button dropWiseButton; // Reference to the DropWise Button
    public TextMeshProUGUI textMeshPro1; // Reference to the first TextMesh Pro object
    public TextMeshProUGUI textMeshPro2; // Reference to the second TextMesh Pro object
    public TextMeshProUGUI textMeshPro3;
    public AudioSource audioSource1; // Reference to the AudioSource
    public AudioSource audioSource2;

    private bool isChanging = false;
    private Coroutine holdCoroutine;

    void Update()
    {
        if (isChanging)
        {
            liquidVolumeObject1.level -= changeRate * Time.deltaTime;
            liquidVolumeObject2.level += changeRate * Time.deltaTime;

            // Clamp the levels to ensure they stay within valid range
            liquidVolumeObject1.level = Mathf.Clamp01(liquidVolumeObject1.level);
            liquidVolumeObject2.level = Mathf.Clamp01(liquidVolumeObject2.level);

            // Check if the level has reached the target value
            if (liquidVolumeObject1.level <= 0.6610753f)
            {
                DisablePourButton();
            }
        }
    }

    public void StartChanging(BaseEventData eventData)
    {
        isChanging = true;
    }

    public void StopChanging(BaseEventData eventData)
    {
        isChanging = false;
    }

    private void DisablePourButton()
    {
        pourButton.gameObject.SetActive(false);
        textMeshPro1.gameObject.SetActive(false); // Hide TextMesh Pro 1 when pourButton disappears
        isChanging = false; // Set isChanging to false after the button disappears
        audioSource2.Stop();

        // Change the color of the liquid in the flask to light pink
        Color lightPink = new Color(1.0f, 0.7f, 0.7f); // Define the light pink color
        liquidVolumeObject2.liquidColor1 = lightPink; // Set the liquid color to light pink

        // Show the DropWise Button and TextMesh Pro 2
        dropWiseButton.gameObject.SetActive(true);
        textMeshPro2.gameObject.SetActive(true); // Show TextMesh Pro 2 when dropWiseButton appears
        textMeshPro3.gameObject.SetActive(true);
        audioSource1.Play(); // Play the audio when textMeshPro2 appears
    }
}
