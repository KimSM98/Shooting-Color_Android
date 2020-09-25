using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIButton : MonoBehaviour
{
    public GameObject QuitGroup;
    public Button SoundButton;
    public Sprite[] SoundSpr;
    public Button PauseButton;
    public Sprite[] PauseSpr;
    private int soundvalue;
    private int isPause = 1;

    void Start()
    {
        soundvalue = 0;
        SoundButtonFunc();        
        //Sound = 사운드 데이터
        PauseButtonFunc();
        //isPause = 0;
    }
    public void QuitButtonYes(){
        PlayerPrefs.SetInt("GameScene", 0);//?존재의 의미?
        Application.Quit();
    }
    public void PowerButton(){
        Time.timeScale = 0;
        QuitGroup.SetActive(true);
    }
    public void QuitButtonNo(){
        Time.timeScale = 1;
        QuitGroup.SetActive(false);
    }

    public void SoundButtonFunc(){
        if(soundvalue == 0){
            soundvalue = 1;
            SoundButton.image.sprite = SoundSpr[1];
        }
        else{
            soundvalue = 0;
            SoundButton.image.sprite = SoundSpr[0];    
        } 
    }
    public void MainButtonFunc(){
        SceneManager.LoadScene("MainScene");
    }

    public void RestartButtonFunc(){
        SceneManager.LoadScene("GameScene");
    }

    public void PauseButtonFunc(){
        if(isPause == 0){
            isPause = 1;
            Time.timeScale = 0;
        }
        else{
            isPause = 0;
            Time.timeScale = 1;
        }
        PauseButton.image.sprite = PauseSpr[isPause];
    }

}
