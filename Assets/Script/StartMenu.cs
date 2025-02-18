using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Початковий екран
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // +1 bcse next scene
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        // Здійснюємо перехід на першу сцену
        SceneManager.LoadScene("Start");
    }
}
