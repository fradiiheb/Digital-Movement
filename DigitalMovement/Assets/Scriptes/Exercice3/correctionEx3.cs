using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correctionEx3 : MonoBehaviour
{
    [SerializeField] private Exercice3[] btns;
    void Awake(){
        btns=FindObjectsOfType<Exercice3>();
        Debug.Log("find");
    }
    public void correction()
    {
        foreach (Exercice3 btn in btns)
        {
            btn.verification();
        }
        Debug.Log("verif");
    }
}
