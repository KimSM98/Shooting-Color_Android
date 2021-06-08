using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonUI : MonoBehaviour
{
    public GameObject quitGameUIGroup;
    public Button soundButton;

    private ChangeButtonSprite _SoundButtonSprite;


    void Start()
    {
        _SoundButtonSprite = soundButton.GetComponent<ChangeButtonSprite>();

        initializeSoundButtonSprite();
    }
    public void powerButtonFunc()
    {
        quitGameUIGroup.SetActive(true);
    }

    public void quitGame_Yes()
    {
        PlayerPrefs.SetInt("isPlaying", 0);
        
        Application.Quit();
    }

    public void quitGame_No()
    {
        quitGameUIGroup.SetActive(false);
    }

    public void SoundButtonFunc()
    {
        bool isSoundOn = (PlayerPrefs.GetInt("isSoundOn") == 1) ? true : false;

        if(isSoundOn)
        {
            PlayerPrefs.SetInt("isSoundOn", 0);
            _SoundButtonSprite.changeSprite(0);
        }
        else
        {
            PlayerPrefs.SetInt("isSoundOn", 1);
            _SoundButtonSprite.changeSprite(1);
        }
    }

    void initializeSoundButtonSprite()
    {
        bool isSoundOn = (PlayerPrefs.GetInt("isSoundOn") == 1) ? true : false;

        if(isSoundOn)
            _SoundButtonSprite.changeSprite(1);
        else
            _SoundButtonSprite.changeSprite(0);
    }

}
