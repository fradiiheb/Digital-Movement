using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Random = UnityEngine.Random;
public class tagManager : MonoBehaviour
{
    
    public string correctvalue;
    public string[] AnswersTexts;
    GameObject TheCorrectOne;
    public List<GameObject> _Myanswers;
    int i = 0;

    //
    public int firstValue, secondValue;
    public List<string> operateurs;
    public string operateur;
    public float result;
    public int hidden;
    public TMP_Text firstValueText, secondValueText, OperatorText, ResultText;
    // Start is called before the first frame update

    private void Awake()
    {
        firstValue = Random.Range(0, 100);
        secondValue = Random.Range(0, 100);
        hidden = Random.Range(0, 3);
        operateurs.Add("+");
        operateurs.Add("-");
        operateurs.Add("*");
        //operateurs.Add("/");
        operateurs=operateurs.OrderBy(b => Random.value).ToList();
        operateur = operateurs.First();
        result = CalculatePair(firstValue, secondValue, operateur);
        firstValueText.text = firstValue + "";
        secondValueText.text = secondValue + "";
        OperatorText.text = operateur + "";
        ResultText.text = result + "";
        logic(hidden);
    }
    public void logic(int thehidden)
    {
        switch (thehidden)
        {
            case 0:
                firstValueText.text="?";
                correctvalue = firstValue+"";
                AnswersTexts[0] = firstValue + "";
                AnswersTexts[1] = Random.Range(firstValue-10,firstValue+10) + "";
                AnswersTexts[2] = Random.Range(firstValue - 10, firstValue + 10) + "";
                break;
            case 1:
                OperatorText.text = "?";
                correctvalue = operateur + "";
                AnswersTexts[0] = operateur + "";
                AnswersTexts[1] = operateurs.ElementAt(1) + "";
                AnswersTexts[2] = operateurs.ElementAt(2) + "";
                break;
            case 2:
                secondValueText.text = "?";
                correctvalue = secondValue + "";
                AnswersTexts[0] = secondValue + "";
                AnswersTexts[1] = Random.Range(secondValue - 10, secondValue + 10) + "";
                AnswersTexts[2] = Random.Range(secondValue - 10, secondValue + 10) + "";
                break;
            case 3:
                ResultText.text = "?";
                correctvalue = result + "";
                AnswersTexts[0] = result + "";
                AnswersTexts[1] = Random.Range(result - 10, result + 10) + "";
                AnswersTexts[2] = Random.Range(result - 10, result + 10) + "";
                break;
        }
    }
    private float CalculatePair(float x, float y, string op)
    {
        float result = 0.0f;

        switch (op)
        {
            case "+":
                result = x + y;
                break;
            case "-":
                result = x - y;
                break;
            case "*":
                result = x * y;
                break;
            case "/":
                result = x / y;
                break;
        }

        return result;
    }

    void Start()
    {
       
        _Myanswers = _Myanswers.OrderBy(b => Random.value).ToList();
        foreach(GameObject answer in _Myanswers)
        {
            answer.GetComponentInChildren<TMP_Text>().text =AnswersTexts[i];
            i++;
        }


        TheCorrectOne = _Myanswers.Where(n => n.GetComponentInChildren<TMP_Text>().text == correctvalue).First();
        TheCorrectOne.gameObject.tag = "Correct Answer";
    }

    
}
