using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnUnlockAllLevel : MonoBehaviour
{
    public void OnStarButtonClick()
    {
        Finish finishScript = FindObjectOfType<Finish>();
        if (finishScript != null)
        {
            finishScript.UnlockAllLevels();
        }
    }
}
