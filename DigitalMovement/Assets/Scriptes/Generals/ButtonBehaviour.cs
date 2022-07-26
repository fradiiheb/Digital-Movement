using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{

    public void openHome() {
        SceneManager.LoadScene("Home");
    }

    public void openChapters() {
        SceneManager.LoadScene("Chapters");
    }

    public void openGames() {
        SceneManager.LoadScene("Games");
    }
    
    public void openShop() {
        SceneManager.LoadScene("Shop");
    }

    public void openCustomization () {
        SceneManager.LoadScene("Customization");
    }

    public void openProfile() {
        SceneManager.LoadScene("Profile");
    }

    public void openSettings() {
        SceneManager.LoadScene("Settings");
    }
    public void LoadPuzzle()
    {
        SceneManager.LoadScene("Menu");
    } 
    public void LoadSubjects()
    {
        SceneManager.LoadScene("subjects");
    }public void LoadLevels()
    {
        SceneManager.LoadScene("levels");
    }
    public void LoadExercice1()
    {
        SceneManager.LoadScene("Exercice1");
    }
    public void LoadExercice2()
    {
        SceneManager.LoadScene("Exercice2");
    }
    public void LoadExercice3()
    {
        SceneManager.LoadScene("Exercice3");
    }
    public void Exercice2Corrector(GameObject Ex2Corrector)
    {
        Ex2Corrector.SetActive(true);
    }
    public void DeasactivatePanel(GameObject Panel){
        Panel.SetActive(false);
    }
    public void ActivatePanel(GameObject Panel){
        Panel.SetActive(true);
    }


}
