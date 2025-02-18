using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // ���������� �����
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
        // ��������� ������� �� ����� �����
        SceneManager.LoadScene("Start");
    }
}
