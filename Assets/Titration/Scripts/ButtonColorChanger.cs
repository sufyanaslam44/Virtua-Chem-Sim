using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour
{
    public Button button1; // Reference to Button1
    public Button button2; // Reference to Button2

    void Start()
    {
        // Add a listener to Button1 to call ChangeButton2Color method when clicked
        button1.onClick.AddListener(ChangeButton2Color);
    }

    void ChangeButton2Color()
    {
        // Change the color of Button2 to green
        ColorBlock colorBlock = button2.colors;
        colorBlock.normalColor = Color.green;
        colorBlock.highlightedColor = Color.green;
        colorBlock.pressedColor = Color.green;
        button2.colors = colorBlock;
    }
}
