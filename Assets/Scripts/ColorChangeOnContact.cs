using UnityEngine;

public class ColorChangeOnContact1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Liquid1")
        {
            // Change the material color to red when interacting with the liquid volume
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
