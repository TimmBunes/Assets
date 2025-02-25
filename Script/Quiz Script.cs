using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this directive for TextMeshPro
using UnityEngine.UI; // Add this directive for UI components

public class QuizScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<QandA> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TMP_Text QuestionTxt; // Change Text to TMP_Text
    public Image QuestionImage; // Add this field for the question image

    public void Start()
    {
        genereateQuestion();
    }
    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        genereateQuestion();
    }

    void SetAnswer()
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
    void genereateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);
        QuestionTxt.text = QnA[currentQuestion].Questions;
        QuestionImage.sprite = QnA[currentQuestion].QuestionImage; // Set the question image

        SetAnswer();
        QnA.RemoveAt(currentQuestion);
    }
}