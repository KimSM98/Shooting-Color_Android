using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void restartButtonFunc()
    {
        if(Time.timeScale == 0f)
            Time.timeScale = 1f;
            
        SceneManager.LoadScene("GamePlayScene");
    }
}
