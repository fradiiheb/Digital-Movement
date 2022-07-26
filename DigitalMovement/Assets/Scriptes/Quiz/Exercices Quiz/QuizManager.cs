using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuizManager : MonoBehaviour
{
    public List<QuizEntity> QnA;

    [Space(120)]
    public int currentQuestion;
    public ArabicText QuestionTxt;
    public GameObject[] options;
    public GameObject CurrentQuestText;
    // public GameObject QuizPanel;
    // public GameObject GOPanel;
    public GameObject MascotObject;

    public GameObject NextQuestionBTN;
    // public Text scoreTxt;
    int totalQuestions;
    int questionsCount;
    //  public int score = 0 ;


    private void Start()
    {
        
        totalQuestions = QnA.Count;
        //    GOPanel.SetActive(false);
        //   GifPanel.SetActive(false);
        // QuizPanel.SetActive(true);
        generateQuestion();
    }

    public void correct()
    {
        //   score += 1 ;
        QnA.RemoveAt(currentQuestion);
        MascotObject.SetActive(true);
        MascotObject.GetComponent<WinLoseAnimation>().WinAnimation();
        //    GifPanel.SetActive(true);
        //QuizSoundManager.PlaySound("firework");
        // generateQuestion();
    }

    public void wrong()
    {
        MascotObject.SetActive(true);
        MascotObject.GetComponent<WinLoseAnimation>().LoseAnimation();
        QnA.RemoveAt(currentQuestion);
        // generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        //    GOPanel.SetActive(true);

        //  QuizPanel.SetActive(false);
        //   scoreTxt.text= score + "/" + totalQuestions;
        //WinPanel.SetActive(true);
        FindObjectOfType<ButtonBehaviour>().LoadExercice("Exercice2");
    }

    void SetAnswers()
    {
        for (int i = 0; i < QnA[currentQuestion].Answers.Count; i++)
        {
            options[i].GetComponent<QuizAnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<ArabicText>().Text = QnA[currentQuestion].Answers[i];
            options[i].SetActive(true);
            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<QuizAnswerScript>().isCorrect = true;
               
            }

        }


    }

    public void generateQuestion()
    {
        MascotObject.SetActive(false);
        //   GifPanel.SetActive(false);
        
        
        foreach (GameObject option in options)
        {
            if (option.GetComponent<Image>().color != Color.white)
                
            option.SetActive(false);
            option.GetComponent<Button>().enabled = true;
            option.GetComponent<Image>().color = Color.white;
        }
        


            if (QnA.Count > 0)
            {
                currentQuestion = Random.Range(0, QnA.Count);
                QuestionTxt.Text = QnA[currentQuestion].Question;
                SetAnswers();
            }
            else
            {
                QuizSoundManager.PlaySound("endlevel");
                Debug.Log("Out of questions");
                GameOver();
            }
            if (questionsCount < totalQuestions)
                questionsCount++;
            CurrentQuestText.GetComponent<Text>().text = "" + (questionsCount) + "/" + totalQuestions;
           NextQuestionBTN.SetActive(false);
    }


    public void DeasctivateAll()
    {
        foreach (GameObject option in options)
        {
            option.GetComponent<Button>().enabled = false;
        }
        NextQuestionBTN.SetActive(true);
    }
}
