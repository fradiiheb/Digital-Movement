using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exercice3 : MonoBehaviour
{
    [SerializeField] private bool cheked;
    [SerializeField] private Image selected;
    [SerializeField] private bool Correct;
    public void check()
    {
        cheked = !cheked;
        selected.enabled = !selected.enabled;
    }
    public void verification()
    {
        if (cheked&&Correct)
        {
            Color greencoller = Color.green;
            greencoller.a = 0.5f;
            selected.color = greencoller;
        }
        else if ((cheked&&(!Correct))||(Correct&&(!cheked)))
        {
            Color redcoller = Color.red;
            redcoller.a = 0.5f;
            selected.color = redcoller;
        }
    }
}