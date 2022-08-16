using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrowGameManager : MonoBehaviour
{
    //public TMP_Text end;
    public List<bool> test = new List<bool>();
    public GameObject[] gameObjects = null;
    public List<ArrowSlot> itemSlots = new List<ArrowSlot>();
    public ExerciceScore exerciceScore;
    public List<ArrowDragDrop> arrowDragDrops = new List<ArrowDragDrop>();
    private bool win = true;

    private void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("ArrowDrag");
        foreach (GameObject g in gameObjects)
        {
            if (g != null)
            {
                arrowDragDrops.Add(g.GetComponent<ArrowDragDrop>());
                
            }
        }
    }


    public void OnClick(Button btn)
    {
        exerciceScore.Score = 0;

        foreach(ArrowDragDrop t in arrowDragDrops)
        {
            if (t.arrowSlot != null)
            {
                if (t.answer == t.arrowSlot.answer)
                {
                    exerciceScore.Score++;
                    Debug.Log(t.name);
                }
                else
                {
                    win = false;
                }
            }
            
        }
        btn.interactable = false;

        /*  foreach (ArrowSlot t in itemSlots)
          {
              test.Add(t.answertest);
          }
          foreach (bool t in test)
          {
              if (t)
              {
                  exerciceScore.Score++;
              }
              else
              {
                  win = false;
              }

          }*/

        if (win)
        {
            // end.gameObject.SetActive(true);
            //  end.text = "You Win!";
            Debug.Log("Win");
        }
        else
        {
            Debug.Log("Lose");
         //   end.gameObject.SetActive(true);
         //   end.text = "You Lost!";
        }
    }

}
