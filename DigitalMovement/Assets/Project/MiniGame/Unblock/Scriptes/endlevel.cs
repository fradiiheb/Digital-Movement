using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endlevel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Player")
        {
            Debug.Log("End Level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
        }*/
        if(collision.gameObject.layer==3){
              Debug.Log("End Level");
            Debug.Log(collision.gameObject.layer);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
        }
        
    }  
    public void LoadLevel(string LevelName){
        SceneManager.LoadScene(LevelName);
    }
}
