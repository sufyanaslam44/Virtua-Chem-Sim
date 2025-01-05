using UnityEngine;
using LiquidVolumeFX; // Make sure you have the correct namespace for Liquid Volume Pro
using UnityEngine.UI; // Make sure you have the correct namespace for UI elements

public class AcidTransfer : MonoBehaviour
{
    public LiquidVolume liquidVolume1;
    public LiquidVolume liquidVolume2;
    public float transferAmount1;
    public float transferAmount2;
    public Button liquidTransferButton;
    public Button dragBackButton; // Add a reference to the DragBackButton

    private int clickCount = 0; // Counter to track the number of clicks

    void Start()
    {
        if (liquidTransferButton != null)
        {
            liquidTransferButton.onClick.AddListener(OnLiquidTransferButtonClicked);
        }

        // Initially, make sure the DragBackButton is not visible
        if (dragBackButton != null)
        {
            dragBackButton.gameObject.SetActive(false);
        }
    }

    void OnLiquidTransferButtonClicked()
    {
        clickCount++; // Increment the click counter

        if (liquidVolume1 != null && liquidVolume2 != null)
        {
            float liquidLevel1 = liquidVolume1.level;
            float liquidLevel2 = liquidVolume2.level;

            // Calculate the new levels
            liquidLevel1 = Mathf.Clamp(liquidLevel1 - transferAmount1, 0f, 1f);
            liquidLevel2 = Mathf.Clamp(liquidLevel2 + transferAmount2, 0f, 1f);

            // Apply the new levels
            liquidVolume1.level = liquidLevel1;
            liquidVolume2.level = liquidLevel2;
        }

        // Check if the click count has reached 4
        if (clickCount == 4)
        {
            if (liquidTransferButton != null)
            {
                liquidTransferButton.gameObject.SetActive(false); // Hide the LiquidTransferButton
            }
            if (dragBackButton != null)
            {
                dragBackButton.gameObject.SetActive(true); // Show the DragBackButton
            }
        }
    }
}
