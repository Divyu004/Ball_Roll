using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay_UIManage : MonoBehaviour
{
    
    public static GamePlay_UIManage instance;
    public Text _scoreText;


    
    private void Awake()
    {
        if(instance!=null && instance!=this)
            Destroy(this);
        else
            instance = this;

    }
    private void Start()
    {
        _scoreText.text = "Score: " + 0;
    }


     

}
