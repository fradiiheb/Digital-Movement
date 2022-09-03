using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LoadLevelColorHouse : MonoBehaviour
{
    public bool level2 = false;
    public static LoadLevelColorHouse Instance;
    private void Awake()
    {
        if(Instance == null) { 
        Instance = this;
        DontDestroyOnLoad(gameObject);
        }
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("ColorHouse1");
    }


    public void LoadLevel2()
    {
        if (level2)
        {
            SceneManager.LoadScene("ColorHouse2");
        }
    }
    public void loadaSceen(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
