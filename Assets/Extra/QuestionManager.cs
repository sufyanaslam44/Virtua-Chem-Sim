using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Text questionText;
    public Text scoreText;
    public Text FinalScore;
    public Text explanationText;
    public Button[] replyButtons;
    public QtsData qtsData;
    public GameObject Right;
    public GameObject Wrong;
    public GameObject GameFinished;
    public Button nextButton;
    public Button explanationButton;

    private int currentQuestion = 0;
    private static int score = 0;
    private int selectedReplyIndex;

    void Start()
    {
        SetQuestion(currentQuestion);
        Right.gameObject.SetActive(false);
        Wrong.gameObject.SetActive(false);
        GameFinished.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        explanationButton.gameObject.SetActive(false);
        explanationText.gameObject.SetActive(false);
        nextButton.onClick.AddListener(NextQuestion);
        explanationButton.onClick.AddListener(ShowExplanation);
    }

    void SetQuestion(int questionIndex)
    {
        questionText.text = qtsData.questions[questionIndex].questionText;
        foreach (Button r in replyButtons)
        {
            r.onClick.RemoveAllListeners();
            r.GetComponent<Image>().color = Color.white; // Reset button color to white
        }
        for (int i = 0; i < replyButtons.Length; i++)
        {
            replyButtons[i].GetComponentInChildren<Text>().text = qtsData.questions[questionIndex].replies[i];
            int replyIndex = i;
            replyButtons[i].onClick.AddListener(() =>
            {
                CheckReply(replyIndex);
            });
        }
    }

    void CheckReply(int replyIndex)
    {
        selectedReplyIndex = replyIndex;

        // Change the selected reply button background color to light yellow
        replyButtons[selectedReplyIndex].GetComponent<Image>().color = new Color(1f, 1f, 0.8f); // Light Yellow (RGB: 255, 255, 204)

        if (replyIndex == qtsData.questions[currentQuestion].correctReplyIndex)
        {
            score++;
            scoreText.text = "" + score;
            Right.gameObject.SetActive(true);
        }
        else
        {
            Wrong.gameObject.SetActive(true);
        }

        foreach (Button r in replyButtons)
        {
            r.interactable = false;
        }

        explanationButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
    }

    void ShowExplanation()
    {
        string allExplanations = "";
        foreach (string explanation in qtsData.questions[currentQuestion].explanations)
        {
            allExplanations += explanation + "\n\n";
        }
        explanationText.text = allExplanations.Trim();
        explanationText.gameObject.SetActive(true);
        explanationButton.gameObject.SetActive(false);
    }

    void NextQuestion()
    {
        Right.SetActive(false);
        Wrong.SetActive(false);
        nextButton.gameObject.SetActive(false);
        explanationText.gameObject.SetActive(false);
        explanationButton.gameObject.SetActive(false);

        currentQuestion++;
        if (currentQuestion < qtsData.questions.Length)
        {
            Reset();
        }
        else
        {
            GameFinished.SetActive(true);
            float scorePercentage = (float)score / qtsData.questions.Length * 100;
            FinalScore.text = "Your Score: " + scorePercentage.ToString("F0") + "%";
            if (scorePercentage < 50)
            {
                FinalScore.text += "\nGame Over";
            }
            else if (scorePercentage < 60)
            {
                FinalScore.text += "\nKeep Trying";
            }
            else if (scorePercentage < 70)
            {
                FinalScore.text += "\nGood Job";
            }
            else if (scorePercentage < 80)
            {
                FinalScore.text += "\nWell Done";
            }
            else
            {
                FinalScore.text += "\nYou're a genius!";
            }
        }
    }

    public void Reset()
    {
        foreach (Button r in replyButtons)
        {
            r.interactable = true;
            r.GetComponent<Image>().color = Color.white; // Reset button color to white
        }
        SetQuestion(currentQuestion);
    }

    public void ResetScore()
    {
        score = 0; // Reset score
        scoreText.text = "0"; // Update score display
        currentQuestion = 0; // Reset question index
        Reset(); // Reset game to initial state
    }
}
