using UnityEngine;

public class ColorChangeOnContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Liquid2")
        {
            // Change the material color to red when interacting with the liquid volume
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
