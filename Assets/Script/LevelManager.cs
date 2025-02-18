using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //Всі рівні
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLvl = PlayerPrefs.GetInt("UnlockedLevel", 1);   //1 lvl open at start
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;                        //не активні клавіші
        }
        for (int i = 0; i < unlockedLvl; i++)
        {
            buttons[i].interactable = true;
        }
    }

    private void Start()
    {
        // Додаєм виклик UnlockAllLevels з Finish, для відкр всіх рівнів
        Finish finishScript = FindObjectOfType<Finish>();
        if (finishScript != null)
        {
            finishScript.UnlockAllLevels();
        }
    }
    public void OpenLvl(int lvlID)
    {
        string levelName = "Level " + lvlID;
        SceneManager.LoadScene(levelName);
    }
}
