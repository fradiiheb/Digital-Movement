using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonLevel2ColorHouse : MonoBehaviour
{

    LoadLevelColorHouse loadLevel;
   
    
    void Start()
    {
        loadLevel = GameObject.FindGameObjectWithTag("scenemanager").GetComponent<LoadLevelColorHouse>();

        if (!loadLevel.level2 )
        {
            GetComponent<Button>().interactable = false;
        }
        else {

            GetComponent<Button>().onClick.AddListener( () => loadLevel.LoadLevel2()) ;
        }


    }
   
    
}
