using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    Camera maincamera;
    public float zoomAMT = 60f;
    // Start is called before the first frame update
    void Start()
    {
        maincamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        maincamera.fieldOfView= zoomAMT;
    }
    public void sliderZoom(float zoom)
    {
        zoomAMT= zoom; 
    }
}
