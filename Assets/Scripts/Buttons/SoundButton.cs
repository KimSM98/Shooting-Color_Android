using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    private ChangeButtonSprite _SoundButtonSprite;

    void Start()
    {
        _SoundButtonSprite = GetComponent<ChangeButtonSprite>();
        initializeSoundButtonSprite();
    }

    void initializeSoundButtonSprite()
    {
        bool isSoundOn = (PlayerPrefs.GetInt("isSoundOn") == 1) ? true : false;

        if(isSoundOn)
            _SoundButtonSprite.changeSprite(1);
        else
            _SoundButtonSprite.changeSprite(0);
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
}
