using UnityEngine;
using UnityEngine.UI;
using LiquidVolumeFX;
using TMPro;

public class FillAcid : MonoBehaviour
{
    public LiquidVolume liquidVolume;
    
    public Button increaseButton;
    public Button decreaseButton;
    public Button pourButton;  // Add a reference to the Pour button
    public float changeAmount = 0.1f;

    void Start()
    {
        increaseButton.onClick.AddListener(IncreaseLevel);
        decreaseButton.onClick.AddListener(DecreaseLevel);
        pourButton.gameObject.SetActive(false);  // Initially hide the Pour button
    }

    void IncreaseLevel()
    {
        liquidVolume.level = Mathf.Clamp(liquidVolume.level + changeAmount, 0f, 1f);
        CheckButtonVisibility();
    }

    void DecreaseLevel()
    {
        liquidVolume.level = Mathf.Clamp(liquidVolume.level - changeAmount, 0f, 1f);
        CheckButtonVisibility();
    }

    void CheckButtonVisibility()
    {
        if (liquidVolume.level >= 0.7f)
        {
            pourButton.gameObject.SetActive(true);  // Show the Pour button when the level is 0.8 or higher
            increaseButton.gameObject.SetActive(false);  // Hide the Increase button
            decreaseButton.gameObject.SetActive(false);  // Hide the Decrease button
        }
        else
        {
            pourButton.gameObject.SetActive(false);  // Hide the Pour button otherwise
            increaseButton.gameObject.SetActive(true);  // Show the Increase button
            decreaseButton.gameObject.SetActive(true);  // Show the Decrease button
        }
    }
}
