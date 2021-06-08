using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneSound : SoundManager
{
    //public AudioSource BackgroundAudioSource;
    //public AudioClip BackgroundAudio;
    public AudioClip MiddleButtonAudio;
    public AudioClip OuterButtonAudio;

    void Start(){
        //playBackgroundAudio();
    }
    /*void playBackgroundAudio(){
        setAudioSource(BGaudioSource, BackgroundAudio);
        playAudio(BGaudioSource);
    }*/
    public void playMidButtonAudio(){
        setAudioSource(UIAudioSource, MiddleButtonAudio);
        //audioSource.loop = false;
        //playAudio(UIAudioSource);
    }
    public void playOuterButtonAudio(){
       setAudioSource(UIAudioSource, OuterButtonAudio);
       //audioSource.loop = false;
       //playAudio(UIAudioSource);
    }
}
