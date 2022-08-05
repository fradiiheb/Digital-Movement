using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGameManager : MonoBehaviour
{
    //public TMP_Text end;
    public List<bool> test = new List<bool>();
    public GameObject[] gameObjects = null;
    public List<ArrowSlot> itemSlots = new List<ArrowSlot>();
    public ExerciceScore exerciceScore;

    private bool win = true;

    private void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("ArrowSlot");
        foreach (GameObject g in gameObjects)
        {
            if (g != null)
            {
                itemSlots.Add(g.GetComponent<ArrowSlot>());
            }
        }
    }


    public void OnClick()
    {

        foreach (ArrowSlot t in itemSlots)
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

        }

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
