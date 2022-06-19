using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movements : MonoBehaviour
{
    //private GamePlay_UIManage _gamePlayUIManage;
    //public GameObject _gamePlayUIManage_GO;
    private Rigidbody _rb;

    [Header("Player Movement")]
    [SerializeField] private int _score;
    [SerializeField] private int _speed;

    [Header("Timer")]
    [SerializeField] private float _timeLeft;
    [SerializeField] private bool _timerOn=false;
    [SerializeField] private Text _timerText;

    #region functions Start...... & all
    private void Start()
    {
        //Both are attached on same gameobject
        _rb = GetComponent<Rigidbody>();
      //  _gamePlayUIManage=_gamePlayUIManage_GO.GetComponent<GamePlay_UIManage>();

        _timerOn = true;
    }
    private void Update()
    {
        //Get the input and store it in var
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Add the force to the ball
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        _rb.AddForce(movement * _speed * Time.deltaTime, ForceMode.Impulse);

        //timer
        if (_timerOn )
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimer(_timeLeft);
            }
            else
            {
                Debug.Log("Time End");
                _timeLeft = 0;
                _timerOn=false;
                SceneManager.LoadScene("GameOver");
            }    
        }
        if(horizontal>0 || vertical > 0)
        {
            _timerOn = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("On collision enter");

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("On trigger enter");
        //pickable
        if(other.gameObject.tag=="Pick")
        {
            other.gameObject.SetActive(false);
            ChangeColor();
            AddScore(10);
            GamePlay_UIManage.instance._scoreText.text="Score: "+_score;
        }
    }
    public void AddScore(int points)
    {
        _score += points;
        if (_score >= 100)
        {
            SceneManager.LoadScene("GameWon");
        }
    }
    private void ChangeColor()
    {
        _rb.gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        _timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }


    #endregion
}