using UnityEngine;
using UnityEngine.UI;
using TMPro; // If using TextMeshPro

public class CountingIncrease : MonoBehaviour
{
    public Button myButton; // Reference to the Button
    public TextMeshProUGUI counterText; // Reference to the Text (use TextMeshProUGUI if using TextMeshPro)

    private float counter = 0f;

    void Start()
    {
        // Initialize the counter text
        UpdateCounterText();

        // Add a listener to the button to call the IncreaseCounter method when clicked
        myButton.onClick.AddListener(IncreaseCounter);
    }

    void IncreaseCounter()
    {
        counter += 2.5f; // Increment the counter by 2.5
        UpdateCounterText();
    }

    void UpdateCounterText()
    {
        counterText.text = "V<sub>2</sub> = " + counter.ToString("F1") + " mL (Volume of HCl)";
    }
}
