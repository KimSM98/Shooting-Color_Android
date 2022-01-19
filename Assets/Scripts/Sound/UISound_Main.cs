using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound_Main : MonoBehaviour
{
    public AudioClip OKButtonSound;
    public AudioClip directionButtonSound;

    private AudioSource _AudioSource;

    // Start is called before the first frame update
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
    public void playOkButtonSound()
    {
        setAudioClip(OKButtonSound);
        _AudioSource.Play();
    }

    public void playDirectionButtonSound()
    {
        setAudioClip(directionButtonSound);
        _AudioSource.Play();
    }

}
