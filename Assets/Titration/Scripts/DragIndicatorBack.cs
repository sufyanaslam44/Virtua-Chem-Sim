using UnityEngine;

public class DragIndicatorBack : MonoBehaviour
{
    public float sidewaysSpeed = 2.0f;
    public float downwardSpeed = 2.0f;
    public float sidewaysDistance = 5.0f;
    public float downwardDistance = 5.0f;

    private Vector3 initialPosition;
    private bool isMovingSideways = false;
    private bool isMovingDownward = false;
    private float movedSideways = 0.0f;
    private float movedDownward = 0.0f;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isMovingSideways)
        {
            float moveAmount = sidewaysSpeed * Time.deltaTime;
            if (movedSideways + moveAmount > sidewaysDistance)
            {
                moveAmount = sidewaysDistance - movedSideways;
            }
            transform.Translate(Vector3.left * moveAmount);
            movedSideways += moveAmount;

            if (movedSideways >= sidewaysDistance)
            {
                isMovingSideways = false;
                isMovingDownward = true;
            }
        }
        else if (isMovingDownward)
        {
            float moveAmount = downwardSpeed * Time.deltaTime;
            if (movedDownward + moveAmount > downwardDistance)
            {
                moveAmount = downwardDistance - movedDownward;
            }
            transform.Translate(Vector3.down * moveAmount);
            movedDownward += moveAmount;

            if (movedDownward >= downwardDistance)
            {
                isMovingDownward = false;
            }
        }
    }

    public void OnDragButtonClick()
    {
        isMovingSideways = true;
        movedSideways = 0.0f;
        movedDownward = 0.0f;
    }
}
