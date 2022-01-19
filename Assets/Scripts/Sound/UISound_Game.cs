using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound_Game : MonoBehaviour
{
    public AudioClip attackButtonSound;
    public AudioClip colorButtonSound;
    public AudioClip specialAttackSound;

    private AudioSource _AudioSource;

    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    // Setter
    void setAudioClip(AudioClip audioClip)
    {
        _AudioSource.clip = audioClip;        
    }

    // Play sound
    public void playAttackButtonSound()
    {
        setAudioClip(attackButtonSound);
        _AudioSource.Play();
    }

    public void playColorButtonSound()
    {
        setAudioClip(colorButtonSound);
        _AudioSource.Play();
    }

    public void playSpecialAttackSound()
    {
        setAudioClip(specialAttackSound);
        _AudioSource.Play();
    }

}
