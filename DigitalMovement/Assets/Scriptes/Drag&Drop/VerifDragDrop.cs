using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifDragDrop : MonoBehaviour
{
    public DragDrop[] DragDrops;
    public int numberInPlace;
    public GameObject MascotObject;
    public ButtonBehaviour nextExercice;
    public GameObject ExCorrector;
    void Awake(){
        DragDrops=FindObjectsOfType<DragDrop>();
    }
    public void verif(){
        foreach (DragDrop it in DragDrops)
            {
                if (it.InAHolder==false)
                {
                    return;
                }
            }
            Debug.LogError("allInHolder");
            nextExercice.Exercice2Corrector(ExCorrector);
            foreach (DragDrop it in DragDrops)
            {
                if (it.inPos==false)
                {
                    return;
                }
            }
            MascotObject.SetActive(true);
            MascotObject.GetComponent<WinLoseAnimation>().WinAnimation();
            Debug.LogError("AllInPos");
    }
}
