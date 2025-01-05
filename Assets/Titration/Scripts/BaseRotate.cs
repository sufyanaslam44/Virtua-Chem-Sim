using UnityEngine;
using UnityEngine.UI;

public class BaseRotate : MonoBehaviour
{
    public float rotationSpeed = 90f; // Degrees per second
    public float rotationAngle = 90f; // Total rotation angle
    public Button rotationButton; // Reference to the rotation button
    public Button pourButton; // Reference to the pour button

    private float currentRotation = 0f;
    private bool isPourButtonVisible = false;

    void Start()
    {
        // Ensure the initial visibility states of the buttons
        if (rotationButton != null) rotationButton.gameObject.SetActive(false);
        if (pourButton != null) pourButton.gameObject.SetActive(false);
    }

    public void Rotate()
    {
        float rotationStep = rotationSpeed * Time.deltaTime;

        // Check if the remaining rotation is less than the step to avoid overshooting
        if (Mathf.Abs(currentRotation + rotationStep) > Mathf.Abs(rotationAngle))
        {
            rotationStep = rotationAngle - currentRotation;
        }

        // Rotate the object around the Z-axis
        transform.Rotate(Vector3.forward, rotationStep);
        currentRotation += rotationStep;

        // Check if the current rotation has reached or exceeded 55.314 degrees
        if (currentRotation >= 55.314f && !isPourButtonVisible)
        {
            ToggleButtons();
        }
    }

    private void ToggleButtons()
    {
        if (rotationButton != null) rotationButton.gameObject.SetActive(false);
        if (pourButton != null) pourButton.gameObject.SetActive(true);
        isPourButtonVisible = true;
    }

    // Method to reset the rotation (if needed)
    public void ResetRotation()
    {
        currentRotation = 0f;
        isPourButtonVisible = false;

        // Reset the visibility of the buttons
        if (rotationButton != null) rotationButton.gameObject.SetActive(true);
        if (pourButton != null) pourButton.gameObject.SetActive(false);
    }
}
