using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manage : MonoBehaviour
{
    [SerializeField] public GameObject PauseBtn;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    #region OnClick Methods


    public void OnClick_PlayButton()
    {
        SceneManager.LoadScene("Lv1");
    }

    public void OnClick_Pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        PauseBtn.SetActive(false);
    }
    
    public void OnClick_Rsume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        PauseBtn.SetActive(true);
    }
    public void OnClick_MainMenu()
    {
        SceneManager.LoadScene("Home");
    }

    public void QuitGame()
    {
        Debug.Log("QUITING....");
        Application.Quit();
    }
    #endregion
}
