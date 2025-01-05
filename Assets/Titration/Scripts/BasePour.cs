using UnityEngine;
using LiquidVolumeFX;
using UnityEngine.UI;

public class BasePour : MonoBehaviour
{
    public LiquidVolume object1;
    public LiquidVolume object2;
    public Button pourButton;
    public Button RotateBackBase;
    public Button DragBackBase; // Added Drag Back Button reference
    public float pourAmountObject1 = 0.1f; // Adjust the amount of liquid to pour from Object1
    public float pourAmountObject2 = 0.1f; // Adjust the amount of liquid to pour into Object2

    private int pourClickCount = 0; // Counter for pour button clicks

    void Start()
    {
        // Ensure the buttons are assigned
        if (pourButton != null)
        {
            pourButton.onClick.AddListener(OnPourButtonClicked);
        }

        // Ensure Rotate Back Button is initially hidden
        if (RotateBackBase != null)
        {
            RotateBackBase.gameObject.SetActive(false);
        }

        // Ensure Drag Back Button is initially hidden
        if (DragBackBase != null)
        {
            DragBackBase.gameObject.SetActive(false);
        }
    }

    void OnPourButtonClicked()
    {
        // Increment the pour button click counter
        pourClickCount++;

        // Check if the pour button has been clicked 4 times
        if (pourClickCount == 5)
        {
            // Show the Rotate Back Button
            if (RotateBackBase != null)
            {
                RotateBackBase.gameObject.SetActive(true);
            }

            // Hide the Pour Button
            if (pourButton != null)
            {
                pourButton.gameObject.SetActive(false);
            }

            return; // Exit the method to prevent further pouring
        }

        // Check if there's enough liquid in Object1 to pour
        if (object1.level > 0)
        {
            // Decrease the liquid level in Object1
            object1.level -= pourAmountObject1;
            // Ensure the level doesn't go below 0
            object1.level = Mathf.Clamp(object1.level, 0, 1);

            // Increase the liquid level in Object2
            object2.level += pourAmountObject2;
            // Ensure the level doesn't go above 1
            object2.level = Mathf.Clamp(object2.level, 0, 1);
        }
    }
}
