using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    // pause in levels
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);   //disable pause menu
        Time.timeScale = 1f;            //normal mode game
        GameIsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);    //active pause menu
        Time.timeScale = 0f;            //freeze game
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }
    public void QuitGame()
    {
        Debug.Log("Exit game ...");
        Application.Quit();
    }
}
