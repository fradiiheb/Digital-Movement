using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{

    public GameObject train;
    public int count = 0;
    private new GameObject gameObject;
    public float period = 3f;
    public  int life=3;
    public  int score;
    public Text lifetext, scoretext;
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTest());

    }
    public  void UpdateScoreandLife()
    {
        lifetext.text = "Life " + life;
        scoretext.text = "Score " + score;
        if (life <= 0)
        {
            GameOverPanel.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }


    private void Spawn()
    {

        
            
            Instantiate(train, Vector3.zero, transform.rotation);
        

    }

    private IEnumerator SpawnTest()
    {
        yield return new WaitForSeconds(period);
        gameObject = Instantiate(train, Vector3.zero, Quaternion.identity);
        gameObject.GetComponent<WaypointMover>().index = count;
        count += 1;
        if(life>0)
        StartCoroutine(SpawnTest());

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        SceneManager.LoadScene("Home");
    }
    
}
