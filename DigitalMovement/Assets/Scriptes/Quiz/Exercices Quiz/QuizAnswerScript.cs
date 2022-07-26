using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuizAnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Color startColor;

    public void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            QuizSoundManager.PlaySound("right");
            quizManager.correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            QuizSoundManager.PlaySound("wrong");
            quizManager.wrong();
        }

        quizManager.DeasctivateAll();
    }
    public void Nextquest()
    {
        GetComponent<Image>().color = Color.black;
    }
}