using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = GetTouchWorldPosition();

            touchPosition.x = transform.position.x;


            switch (touch.phase)
            {
                case TouchPhase.Began:
                    transform.position = touchPosition;
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime * 10f);
                    break;

            }

        }
    }

    Vector3 GetTouchWorldPosition()
    {
        Vector3 touchPosScreen = Input.GetTouch(0).position;

        Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(new Vector3(touchPosScreen.x,
        touchPosScreen.y,
        Mathf.Abs(transform.position.x - Camera.main.transform.position.x)));

        return touchPosWorld;
    }


}