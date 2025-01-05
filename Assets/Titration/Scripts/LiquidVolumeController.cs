using UnityEngine;
using LiquidVolumeFX;

public class LiquidVolumeController : MonoBehaviour
{
    public LiquidVolume liquidVolume;
    public float Turbulence1;
    public float Turbulence2;
    public float frecuency;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (liquidVolume == null)
        {
            liquidVolume = GetComponent<LiquidVolume>();
        }
    }

    // This method will be called when the button is clicked
    public void ChangeLiquidProperties()
    {
        if (liquidVolume != null)
        {
            liquidVolume.turbulence1 = Turbulence1;
            liquidVolume.turbulence2 = Turbulence2;
            liquidVolume.frecuency = frecuency;
            liquidVolume.speed = speed;

        }
    }
}