using UnityEngine;
using UnityEngine.UI; // Include the UI namespace

public class MoveLiquidObject : MonoBehaviour
{
    public float upwardSpeed = 2f;
    public float sidewaysSpeed = 2f;
    public float upwardDistance = 5f;
    public float sidewaysDistance = 5f;
    public Button minusButton; // Reference to the minus button

    private Vector3 initialPosition;
    private bool moveUp = false;
    private bool moveSideways = false;
    private bool buttonShown = false; // Flag to track if button is shown

    void Start()
    {
        initialPosition = transform.position;
        minusButton.gameObject.SetActive(false); // Ensure the button is inactive initially
    }

    void Update()
    {
        if (moveUp)
        {
            if (transform.position.y < initialPosition.y + upwardDistance)
            {
                transform.Translate(Vector3.up * upwardSpeed * Time.deltaTime);
            }
            else
            {
                moveUp = false;
                moveSideways = true;
            }
        }

        if (moveSideways)
        {
            if (transform.position.x > initialPosition.x - sidewaysDistance)
            {
                transform.Translate(Vector3.left * sidewaysSpeed * Time.deltaTime);

                
            }
            else
            {
                moveSideways = false;
            }
        }
    }

    public void StartMoving()
    {
        moveUp = true;
    }
}
