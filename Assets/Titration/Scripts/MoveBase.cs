using UnityEngine;

public class MoveBase : MonoBehaviour
{
    public float upwardSpeed = 2f;
    public float sidewaysSpeed = 2f;
    public float upwardDistance = 5f;
    public float sidewaysDistance = 5f;

    private Vector3 startPosition;
    private bool moveUp = false;
    private bool moveSideways = false;
    private float upwardMoved = 0f;
    private float sidewaysMoved = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (moveUp)
        {
            float moveAmount = upwardSpeed * Time.deltaTime;
            transform.position += Vector3.up * moveAmount;
            upwardMoved += moveAmount;

            if (upwardMoved >= upwardDistance)
            {
                moveUp = false;
                moveSideways = true;
            }
        }

        if (moveSideways)
        {
            float moveAmount = sidewaysSpeed * Time.deltaTime;
            transform.position += Vector3.left * moveAmount;
            sidewaysMoved += moveAmount;

            if (sidewaysMoved >= sidewaysDistance)
            {
                moveSideways = false;
            }
        }
    }

    public void OnDragButtonClick()
    {
        if (!moveUp && !moveSideways)
        {
            // Reset positions if needed
            upwardMoved = 0f;
            sidewaysMoved = 0f;
            transform.position = startPosition;

            // Start moving upward
            moveUp = true;
        }
    }
}
