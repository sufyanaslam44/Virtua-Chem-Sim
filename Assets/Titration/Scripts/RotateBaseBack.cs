using UnityEngine;
using UnityEngine.UI;

public class RotateBaseBack : MonoBehaviour
{
    public GameObject objectToRotate; // The object you want to rotate
    public Button rotateBackBaseButton; // The button to trigger the rotation

    private void Start()
    {
        // Assign the OnClick listener to the button
        rotateBackBaseButton.onClick.AddListener(RotateToZero);
    }

    private void RotateToZero()
    {
        // Check if the objectToRotate is assigned
        if (objectToRotate != null)
        {
            // Set the rotation of the object to zero on the z-axis
            objectToRotate.transform.rotation = Quaternion.Euler(objectToRotate.transform.rotation.eulerAngles.x,
                                                                  objectToRotate.transform.rotation.eulerAngles.y,
                                                                  0f);
        }
    }
}
