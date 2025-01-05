using UnityEngine;
using UnityEngine.UI;

public class Eone: MonoBehaviour
{
    public Button letStart;
    public Button lessCo2Question;
    public Button performExperiment;
    public GameObject introPanel;
    public GameObject questionPanel;
    public GameObject lessCo2HypothesesPanel;
    public GameObject experimentPanel;



    void Start()
    {
        letStart.onClick.AddListener(LetStart);
        lessCo2Question.onClick.AddListener(LessCo2Question);
        performExperiment.onClick.AddListener(ExperimentPanel);
        questionPanel.gameObject.SetActive(false);
        lessCo2HypothesesPanel.gameObject.SetActive(false);
        experimentPanel.gameObject.SetActive(false);

    }
    private void LetStart()
    {
        introPanel.SetActive(false);
        questionPanel.SetActive(true);
    }
    private void LessCo2Question()
    {
        questionPanel.SetActive(false);
        lessCo2HypothesesPanel.SetActive(true);
    }
    private void ExperimentPanel()
    {
        experimentPanel.SetActive(true);
    }
}