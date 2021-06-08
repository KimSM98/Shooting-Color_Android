using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public AudioSource BackGroundAudioSource;
    public AudioSource UIAudioSource;
    public AudioClip BackgroundAudio;
    void Awake(){
        instance = this;        
        playBackgroundAudio();
        if(!PlayerPrefs.HasKey("Sound")){
            PlayerPrefs.SetInt("Sound",1);//사운드 데이터 초기화
        }
    }
    void playBackgroundAudio(){
        setAudioSource(BackGroundAudioSource, BackgroundAudio);
        //playAudio(BackGroundAudioSource);
    }
    public void setAudioSource(AudioSource _audioSource, AudioClip audioClip){
        _audioSource.clip = audioClip;
        playAudio(_audioSource);
    }
    public void playAudio(AudioSource _audioSource){
        _audioSource.Play();
    }

    virtual public void muteAudio(bool isMute){
        BackGroundAudioSource.mute = isMute;
        UIAudioSource.mute = isMute;
    }
}
