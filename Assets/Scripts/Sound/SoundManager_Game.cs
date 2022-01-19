using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_Game : SoundManager
{
    public AudioSource gameSound;

    public override void setAudioVolume()
    {
        base.setAudioVolume();
        gameSound.mute = isMute;
    }
}
