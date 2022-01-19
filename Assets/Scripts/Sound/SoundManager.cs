using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{    
    public AudioSource BackGroundAudioSource;
    public AudioSource UIAudioSource;

    protected bool isMute = false;

    void Start()
    {
        checkIsMute();
    }

    public void checkIsMute()
    {
        if(PlayerPrefs.HasKey("isSoundOn"))
            isMute = (PlayerPrefs.GetInt("isSoundOn") == 0) ? true : false;
        
        setAudioVolume();
    }
    
    public virtual void setAudioVolume(){
        BackGroundAudioSource.mute = isMute;
        UIAudioSource.mute = isMute;
    }
}
