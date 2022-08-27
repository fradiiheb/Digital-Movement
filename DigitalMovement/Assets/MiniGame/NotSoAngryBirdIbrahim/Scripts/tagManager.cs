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
    // Start is called before the first frame update
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
