using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float upwardSpeed = 1f; // Speed at which the object moves upward
    public float sidewaysSpeed = 1f; // Speed at which the object moves sideways
    public float upwardDistance = 5f; // Distance the object moves upward
    public float sidewaysDistance = 5f; // Distance the object moves sideways

    private Vector3 startPosition;
    private bool moveUp = false;
    private bool moveSideways = false;
    private float upwardTraveled = 0f;
    private float sidewaysTraveled = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (moveUp)
        {
            MoveUpward();
        }
        else if (moveSideways)
        {
            MoveSideways();
        }
    }

    public void OnButtonClick()
    {
        moveUp = true;
    }

    private void MoveUpward()
    {
        if (upwardTraveled < upwardDistance)
        {
            float step = upwardSpeed * Time.deltaTime;
            transform.position += new Vector3(0, step, 0);
            upwardTraveled += step;
        }
        else
        {
            moveUp = false;
            moveSideways = true;
        }
    }

    private void MoveSideways()
    {
        if (sidewaysTraveled < sidewaysDistance)
        {
            float step = sidewaysSpeed * Time.deltaTime;
            transform.position += new Vector3(step, 0, 0);
            sidewaysTraveled += step;
        }
        else
        {
            moveSideways = false;
        }
    }
}
