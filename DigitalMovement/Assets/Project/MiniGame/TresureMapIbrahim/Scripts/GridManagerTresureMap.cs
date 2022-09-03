using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GridManagerTresureMap : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private TileTresureMap _tilePrefab;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject _flagPrefab;
    [SerializeField] private GameObject _treasurePrefab;
    [SerializeField] private Transform _cam;
    [SerializeField] public GameObject WinLosepanel;
    [SerializeField] public Text WinLoseText;
    [SerializeField] private GameObject background;
    private int treasure;
    private int start;
    private Vector3 treasure_location;
    private Vector3 start_location;
    private Vector3 treasureLoc;
    private Dictionary<Vector2 ,TileTresureMap> _tiles;
    private int _length =0;
    private Vector2 worldPoint;
    public RaycastHit2D hit;
    public int life;
    public Text LifeLeftText;
    public InputField widthheight;
    [SerializeField]
    GameObject inputPanel;
    [SerializeField] Text Instruction;
    public bool GameOver=false;
    private void Start()
    {
        

    }
    public void loadTheSceen(string TheSceen){
          SceneManager.LoadScene(TheSceen);
    }
    public void buttonStart(){
        int.TryParse(widthheight.text, out _width);
        int.TryParse(widthheight.text, out _height);
        if(_width>=5 &&_width<=15){
            StartGame();
        }else{
            Instruction.color = Color.red;
        }
    }

    private void StartGame(){
       
        LifeLeftText.text="Life : "+life;
        inputPanel.SetActive(false);
        start = Random.Range(0, _width * _height);
        if ( _width - _height <=3f)
            Camera.main.orthographicSize = 2*_width / 2.7f + _height / 20f - (_width-_height)/2.7f;
        else
            Camera.main.orthographicSize = _width / 2.7f + _height / 20f;

        GenerateGrid();
        CreatePath();
        background.transform.localScale = new Vector3(Camera.main.orthographicSize/3.33f, Camera.main.orthographicSize/3.33f, 0);
    }
    public void LoseLife(){
        life--;
        LifeLeftText.text="Life : "+life;

    }
    private void Update()
    {
       /* worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);       
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(worldPoint, Vector2.down);
            if (hit.collider != null)
            {
                Vector2 treasure = hit.collider.transform.position;
                //Debug.Log(treasure);
                if (hit.collider.tag =="Treasure")
                {
                    foreach (KeyValuePair<Vector2, TileTresureMap> tile in _tiles)
                    {
                        if (tile.Key == treasure)
                        {
                            tile.Value.GetComponent<SpriteRenderer>().color = Color.yellow;
                        }
                    }
                    //Debug.Log("Well Played");
                    panel.SetActive(true);
                }
            }
        }*/
    }
    void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            _tiles = new Dictionary<Vector2, TileTresureMap>();
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedTile.name = $"Tile {x}{y}";
                var isOffset = (x+y) % 2 == 1;
                if (start == _length)
                {
                    spawnedTile.ChangeColor(Color.green);
                    spawnedTile.tag = "Start";
                    start_location = spawnedTile.transform.position;
                }
                else 
                    spawnedTile.Init(isOffset);
                _length++;

                _tiles[new Vector2(x,y)] = spawnedTile;
               // Debug.Log(_tiles.Values);                          
            }
        }
        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }

    void CreatePath()
    {
        //Debug.Log("Start Location :  " + start_location);
        //Debug.Log(treasure_location);
        treasureLoc = start_location;
        int i = 0;
        var spawnarrow = arrow;
        do
        {        
            loop:
            int step = Random.Range(1, 9);
            switch (step)
            {
                case 6:
                    if (treasureLoc.x + 1 >= _width)
                        goto loop;
                    else
                    {
                        treasureLoc.x = treasureLoc.x + 1;
                        spwanArrow(i, 0);
                       // spawnarrow = Instantiate(arrow, new Vector2(i, _height), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
                       // spawnarrow.name = $"Tile {i}";
                    }
                    //Debug.Log("Move Right");
                    break;
                case 4:
                    if (treasureLoc.x - 1 <= 0)
                        goto loop;
                    else
                    {
                        treasureLoc.x = treasureLoc.x - 1;
                        spwanArrow(i, 180);
                    }
                    //Debug.Log("Move Left");
                    break;
                case 8:
                    if (treasureLoc.y + 1 >= _height)
                        goto loop;
                    else
                    {
                        treasureLoc.y = treasureLoc.y + 1;
                        spwanArrow(i, 90);
                    }
                    //Debug.Log("Move Up");
                    break;
                case 2:
                    if (treasureLoc.y - 1 <= 0)
                        goto loop;
                    else
                    {
                        treasureLoc.y = treasureLoc.y - 1;
                        spwanArrow(i, 270);
                    }

                    //Debug.Log("Move Down");
                    break;
                case 9:
                    if (treasureLoc.y + 1 >= _height || treasureLoc.x + 1 >= _width)
                        goto loop;
                    else
                        { 
                            treasureLoc.y = treasureLoc.y + 1;
                            treasureLoc.x = treasureLoc.x + 1;
                        spwanArrow(i, 45);
                    }
                    //Debug.Log("Move RightUp");
                    break;
                case 3:
                    if (treasureLoc.y - 1 <= 0 || treasureLoc.x + 1 >= _width)
                        goto loop;
                    else
                    {
                        treasureLoc.y = treasureLoc.y - 1;
                        treasureLoc.x = treasureLoc.x + 1;
                        spwanArrow(i, 315);
                    }
                    //Debug.Log("Move RightDown");
                    break;
                case 7:
                    if (treasureLoc.y + 1 >= _height || treasureLoc.x - 1 <= 0)
                        goto loop;
                    else
                    {
                        treasureLoc.y = treasureLoc.y + 1;
                        treasureLoc.x = treasureLoc.x - 1;
                        spwanArrow(i, 135);
                    }
                    //Debug.Log("Move LeftUp");
                    break;
                case 1:
                    if (treasureLoc.y - 1 <= 0 || treasureLoc.x - 1 <= 0)
                        goto loop;
                    else
                    {
                        treasureLoc.y = treasureLoc.y - 1;
                        treasureLoc.x = treasureLoc.x - 1;
                        spwanArrow(i, 225);
                    }
                    //Debug.Log("Move LeftDown");
                    break;
                default: 
                    goto loop;
            }
            i++;
        }
        while (i < (_height + _width)/2);

        var spawnTreasure = Instantiate(_treasurePrefab, new Vector2(i, _height+0.3f), Quaternion.identity);

        var spawnflag = Instantiate(_flagPrefab, new Vector2(-1, _height), Quaternion.identity);

        //if (treasureLoc == start_location)
        //    CreatePath();

        var spawnedTile = Instantiate(_tilePrefab, treasureLoc, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
            spawnedTile.name = $"Tile Treasure";
            spawnedTile.tag = "Treasure";
            spawnedTile.setTransparent();
            _tiles[new Vector2(treasureLoc.x, treasureLoc.y)] = spawnedTile;
        //Debug.Log("Treasure location is :  "+ treasureLoc);
    }

    public TileTresureMap GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos,out var tile))
        {
            return tile;
        }
        return null;
    }
    private void spwanArrow ( int i, float deg )
    {
        var spawnarrow = arrow;
        spawnarrow = Instantiate(arrow, new Vector2(i, _height+0.2f), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        spawnarrow.name = $"Tile {i}";
        spawnarrow.transform.eulerAngles = new Vector3(0, 0, deg);
    }
}
