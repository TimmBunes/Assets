using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this directive for TextMeshPro
using UnityEngine.UI; // Add this directive for UI components
using UnityEngine.SceneManagement; // Add this directive for SceneManagement

public class QuizScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<QandA> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TMP_Text QuestionTxt; // Change Text to TMP_Text
    public Image QuestionImage; // Add this field for the question image

    private List<int> questionIndices; // List to keep track of question indices

    public GameObject Quizpanel;
    public GameObject GoPanel;
    
    public TMP_Text scoreTxt; // Change Text to TMP_Text

    int totalQuestions = 0;

    public int score;

    // Add a public field for the main menu scene name
    public string mainMenuSceneName;

    public void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);

        questionIndices = new List<int>();
        for (int i = 0; i < QnA.Count; i++)
        {
            questionIndices.Add(i);
        }
        genereateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        scoreTxt.text = score + "/" + totalQuestions;
    }

    public void wrong()
    {
        if (QnA.Count > 0)
        {
            score += 0;
            QnA.RemoveAt(currentQuestion);
            questionIndices.RemoveAt(currentQuestion);
            if (QnA.Count > 0)
            {
                genereateQuestion();
            }
            else
            {
                // Handle the case where there are no more questions left
                Debug.Log("No more questions available.");
                GameOver();
            }
        }
    }

    public void correct()
    {
        if (QnA.Count > 0)
        {
            score += 1;
            QnA.RemoveAt(currentQuestion);
            questionIndices.RemoveAt(currentQuestion);
            if (QnA.Count > 0)
            {
                genereateQuestion();
            }
            else
            {
                // Handle the case where there are no more questions left
                Debug.Log("No more questions available.");
                GameOver();
            }
        }
    }

    void SetAnswer()
    {
        if (currentQuestion < QnA.Count)
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i]; // Change Text to TMP_Text

                if (QnA[currentQuestion].CorrectAnswer == i + 1)
                {
                    options[i].GetComponent<AnswerScript>().isCorrect = true;
                }
            }
        }
    }

    void genereateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = 0; // Always take the first question in the list
            QuestionTxt.text = QnA[currentQuestion].Questions;
            QuestionImage.sprite = QnA[currentQuestion].QuestionImage; // Set the question image

            SetAnswer();
        }
        else
        {
            // Handle the case where there are no more questions left
            Debug.Log("No more questions available.");
            GameOver();
        }
    }

    // Method to handle the back button press
    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}