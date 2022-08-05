using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifDragDrop : MonoBehaviour
{
    public DragDrop[] DragDrops;
    public int numberInPlace;
    public GameObject MascotObject;
    public ButtonBehaviour nextExercice;
    public GameObject ExCorrector;
    public ExerciceScore ExerciceScore;
    public bool allInPosition = true;

    public bool AllInAHolder =true;
    void Awake(){
        DragDrops=FindObjectsOfType<DragDrop>();
    }
    public void verif(Button btn){
        foreach (DragDrop it in DragDrops)
            {
                if (it.InAHolder==false)
                {
                AllInAHolder = false;
                  //  return;
                }
            }
            Debug.LogError("allInHolder");
            nextExercice.Exercice2Corrector(ExCorrector);
            foreach (DragDrop it in DragDrops)
            {
            if (it.inPos == true)
            {
                ExerciceScore.Score++;
            }else
                {
                allInPosition = false;
                  //  return;
                }
            
            }
        if (allInPosition)
        {
            MascotObject.SetActive(true);
            MascotObject.GetComponent<WinLoseAnimation>().WinAnimation();
            Debug.LogError("AllInPos");
        }
            
            
        btn.interactable = false;
    }
}
