using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneSound : SoundManager
{
    //public static GameSceneSound instance;
    public AudioClip ColorButtonAudio;
    public AudioClip StarButtonAudio;
    public AudioClip PlayerAttackAudio;
    public AudioClip EnemyDeadAudio;
    public AudioClip BossAppearAudio;
    public AudioClip GameOverAudio;
    public AudioClip GameClearAudio;

    void Awake()
    {
        //instance = this;
    }
    
    public void playColorButtonAudio(){
        setAudioSource(UIAudioSource, ColorButtonAudio);
        //playAudio(UIAudioSource);
    }

    public void playStarButtonAudio(){
        setAudioSource(UIAudioSource, StarButtonAudio);
    }

    public void playPlayerAttackAudio(){
        setAudioSource(UIAudioSource, PlayerAttackAudio);
    }

    public void playEnemyDeadAudio(){
        setAudioSource(UIAudioSource, EnemyDeadAudio);
    }

    public void playBossAppearAudio(){
        setAudioSource(UIAudioSource, BossAppearAudio);
    }

    public void playGameOverAudio(){
        setAudioSource(UIAudioSource, GameOverAudio);
    }

    public void playGameClearAudio(){
        setAudioSource(UIAudioSource, GameClearAudio);
    }
}
