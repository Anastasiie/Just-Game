using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // next level
    private AudioSource EndLevelSoundEffect;
    private bool TouchedEnd = false;                                        // натисн фініш чи ні
    private void Start()
    {
        EndLevelSoundEffect = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Kunoichi" && !TouchedEnd)
        {
            EndLevelSoundEffect.Play();
            TouchedEnd = true;
            Invoke("NextLevel", 2f);                                          // ввімкнути наст.рівень через 2 сек
        }
    }
    private void NextLevel()
    {
        UnlockLvl();                                                          //before start new
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //current lvl , + 1 = next level
    }
    private void UnlockLvl()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
    public void UnlockAllLevels()
    {
        int lastLevelIndex = SceneManager.sceneCountInBuildSettings - 1;

        PlayerPrefs.SetInt("ReachedIndex", lastLevelIndex);
        PlayerPrefs.SetInt("UnlockedLevel", lastLevelIndex);
        PlayerPrefs.Save();
    }
}
