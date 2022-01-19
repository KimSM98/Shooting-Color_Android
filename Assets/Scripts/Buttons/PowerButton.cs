using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
    public GameObject quitGameUIGroup;

    public virtual void powerButtonFunc()
    {
        quitGameUIGroup.SetActive(true);
    }

    public void quitGame_Yes()
    {
        PlayerPrefs.SetInt("isPlaying", 0);
        
        Application.Quit();
    }

    public virtual void quitGame_No()
    {
        quitGameUIGroup.SetActive(false);
    }
}
