using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonActions2048 : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("main2048");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
