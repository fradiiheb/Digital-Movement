using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMasterColorHouse : MonoBehaviour
{

    public GameObject train;
    public int count = 0;
    private new GameObject gameObject = null;
    public float period = 3f;
    public int score =0;
    public int max = 5;
    public GameObject button;
    public TMP_Text scoreText;
    
    private LoadLevelColorHouse loadLevel = null;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnTest());
        
        if(GameObject.FindWithTag("scenemanager") != null)
        {
            
            loadLevel = GameObject.FindGameObjectWithTag("scenemanager").GetComponent<LoadLevelColorHouse>();
        }

    }

    private void Update()
    {
        scoreText.text = "Score : "+score.ToString();
        if (score >= max)
        {
            StopAllCoroutines();
            button.SetActive(true);
            if(loadLevel != null)
            {
                loadLevel.level2 = true;
            }
            

        }
    }


    private IEnumerator SpawnTest()
    {
        yield return new WaitForSeconds(period);
        gameObject = Instantiate(train, Vector3.zero, Quaternion.identity);
        gameObject.GetComponent<WaypointMoverColorHouse>().index = count;
        if (loadLevel.level2)
        {
            gameObject.GetComponent<WaypointMoverColorHouse>().level2 = true;
        }
        count += 1;
        StartCoroutine(SpawnTest());

    }


}
