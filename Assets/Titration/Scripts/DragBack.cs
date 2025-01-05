using UnityEngine;
using UnityEngine.UI;

public class DragBack : MonoBehaviour
{
    public float sidewaysSpeed = 1f;
    public float downwardSpeed = 1f;
    public float sidewaysDistance = 2f;
    public float downwardDistance = 2f;
    public Button DragButton;

    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float elapsedTime;

    void Start()
    {
        if (DragButton != null)
        {
            DragButton.onClick.AddListener(OnDragButtonClick);
        }
    }

    void OnDragButtonClick()
    {
        if (!isMoving)
        {
            isMoving = true;
            startPosition = transform.position;
            endPosition = startPosition + new Vector3(sidewaysDistance, -downwardDistance, 0);
            elapsedTime = 0;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime < sidewaysDistance / sidewaysSpeed)
        {
            // Move object along the x-axis
            transform.position = Vector3.Lerp(startPosition, startPosition + new Vector3(sidewaysDistance, 0, 0), elapsedTime * sidewaysSpeed / sidewaysDistance);
        }
        else if (elapsedTime < sidewaysDistance / sidewaysSpeed + downwardDistance / downwardSpeed)
        {
            // Move object along the y-axis
            float t = (elapsedTime - sidewaysDistance / sidewaysSpeed) * downwardSpeed / downwardDistance;
            transform.position = Vector3.Lerp(startPosition + new Vector3(sidewaysDistance, 0, 0), endPosition, t);
        }
        else
        {
            // End of movement
            transform.position = endPosition;
            isMoving = false;
        }
    }
}
