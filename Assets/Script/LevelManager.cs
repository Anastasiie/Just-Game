using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //�� ���
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLvl = PlayerPrefs.GetInt("UnlockedLevel", 1);   //1 lvl open at start
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;                        //�� ������ ������
        }
        for (int i = 0; i < unlockedLvl; i++)
        {
            buttons[i].interactable = true;
        }
    }

    private void Start()
    {
        // ����� ������ UnlockAllLevels � Finish, ��� ���� ��� ����
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
