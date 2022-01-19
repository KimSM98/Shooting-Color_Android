using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton_GameScene : PowerButton
{
    private float previousTimeScale = 1f;

    public override void powerButtonFunc()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0;
        quitGameUIGroup.SetActive(true);
    }

    public override void quitGame_No()
    {
        if(previousTimeScale != 0f)
            Time.timeScale = 1f;
        quitGameUIGroup.SetActive(false);
    }
}
