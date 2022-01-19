using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    public static GameSound instance;

    public AudioClip gameClearSound;
    public AudioClip gameOverSound;
    public AudioClip bossAppearSound;

    public AudioClip monsterDeadSound;

    private AudioSource _AudioSource;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    // Setter
    void setAudioClip(AudioClip audioClip)
    {
        _AudioSource.clip = audioClip;        
    }

    // Play Sound
    public void playGameClearSound()
    {
        setAudioClip(gameClearSound);
        _AudioSource.Play();
    }

    public void playGameOverSound()
    {
        setAudioClip(gameOverSound);
        _AudioSource.Play();
    }

    public void playBossAppearSound()
    {
        setAudioClip(bossAppearSound);
        _AudioSource.Play();
    }

    public void playMonsterDeadSound()
    {
        setAudioClip(monsterDeadSound);
        _AudioSource.Play();
    }
}

