using UnityEngine;

public class BaseBack : MonoBehaviour
{
    public float sidewaysSpeed = 5f;
    public float downwardSpeed = 5f;
    public float sidewaysDistance = 10f;
    public float downwardDistance = 5f;

    private bool isMovingSideways = false;
    private bool isMovingDownward = false;
    private float sidewaysMoved = 0f;
    private float downwardMoved = 0f;

    void Update()
    {
        if (isMovingSideways)
        {
            float moveAmount = sidewaysSpeed * Time.deltaTime;
            transform.Translate(Vector3.right * moveAmount);
            sidewaysMoved += moveAmount;

            if (sidewaysMoved >= sidewaysDistance)
            {
                isMovingSideways = false;
                isMovingDownward = true;
            }
        }
        else if (isMovingDownward)
        {
            float moveAmount = downwardSpeed * Time.deltaTime;
            transform.Translate(Vector3.down * moveAmount);
            downwardMoved += moveAmount;

            if (downwardMoved >= downwardDistance)
            {
                isMovingDownward = false;
            }
        }
    }

    public void OnBaseBackClicked()
    {
        isMovingSideways = true;
        sidewaysMoved = 0f;
        downwardMoved = 0f;
    }
}
