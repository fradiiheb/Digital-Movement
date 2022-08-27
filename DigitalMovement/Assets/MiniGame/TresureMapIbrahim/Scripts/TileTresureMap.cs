using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTresureMap : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] GridManagerTresureMap _gridManagerTresureMap;

    public void Init( bool isOffset)
    {
        
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }
    void Start(){
        _gridManagerTresureMap=FindObjectOfType<GridManagerTresureMap>();
    }
    public void setTransparent ()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        GetComponent<SpriteRenderer>().color = tmp;
    }
    public void ChangeColor(Color color)
    {
        _renderer.color = color;
    }

     void OnMouseEnter()
    {
         if((!_gridManagerTresureMap.GameOver))
        _highlight.SetActive(true);
    }

     void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
    void OnMouseDown()
    {
        if((!_gridManagerTresureMap.GameOver)){
        if(_gridManagerTresureMap.life>0){
        if(this.tag == "Treasure"){
            Debug.Log("gg");
              _gridManagerTresureMap.WinLosepanel.SetActive(true);
              _gridManagerTresureMap.WinLoseText.text="You Won !";
              _gridManagerTresureMap.WinLoseText.color = Color.green;
              _gridManagerTresureMap.GameOver=true;
        }else{
        _gridManagerTresureMap.LoseLife();
        }
        }else{
            _gridManagerTresureMap.WinLosepanel.SetActive(true);
             _gridManagerTresureMap.WinLoseText.text="Game Over !";
            _gridManagerTresureMap.WinLoseText.color = Color.red;
            _gridManagerTresureMap.GameOver=true;
        }
        
        
    }
    }
    
}
