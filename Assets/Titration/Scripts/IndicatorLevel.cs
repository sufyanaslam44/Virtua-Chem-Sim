using UnityEngine;
using UnityEngine.UI;
using LiquidVolumeFX;

public class IndicatorLevel : MonoBehaviour
{
    public LiquidVolume liquidVolume; // Reference to the Liquid Volume component
    public Button decreaseButton; // Reference to the Decrease Button
    public Button dragButton; // Reference to the Drag Button

    private int clickCount = 0; // Counter for the number of clicks
    private const int maxClicks = 3; // Maximum number of clicks before changing buttons

    void Start()
    {
        // Ensure the DragButton is inactive initially
        dragButton.gameObject.SetActive(false);

        // Add a listener to the DecreaseButton
        decreaseButton.onClick.AddListener(OnDecreaseButtonClick);
    }

    void OnDecreaseButtonClick()
    {
        // Decrease the liquid level
        liquidVolume.level -= 0.1f; // Adjust the decrement value as needed

        // Increment the click counter
        clickCount++;

        // Check if the click count has reached the maximum
        if (clickCount >= maxClicks)
        {
            // Hide the DecreaseButton and show the DragButton
            decreaseButton.gameObject.SetActive(false);
            dragButton.gameObject.SetActive(true);
        }
    }
}
