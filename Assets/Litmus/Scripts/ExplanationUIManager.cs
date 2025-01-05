using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ExplanationUIManager : MonoBehaviour
{
    public Button explanationButton;
    public Button backExplanation;

    private List<GameObject> activeUIElements = new List<GameObject>();

    void Start()
    {
        explanationButton.onClick.AddListener(HideActiveUIElements);
        backExplanation.onClick.AddListener(ShowActiveUIElements);
    }

    void HideActiveUIElements()
    {
        activeUIElements.Clear();

        // Find all active UI elements and store them
        foreach (GameObject uiElement in GameObject.FindGameObjectsWithTag("UIElement"))
        {
            if (uiElement.activeSelf)
            {
                activeUIElements.Add(uiElement);
                uiElement.SetActive(false);
            }
        }
    }

    void ShowActiveUIElements()
    {
        // Re-enable the UI elements that were active before
        foreach (GameObject uiElement in activeUIElements)
        {
            uiElement.SetActive(true);
        }
    }
}
