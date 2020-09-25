using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameEnding : MonoBehaviour
{
    public Image GameOverImg;
    public Image GameClearImg;
    //public Image BlackPanel;
    public Image[] ScoreStar;
    public Image[] NormalImg;
    void Start()
    {
        GameOverImg.gameObject.SetActive(false);
        GameClearImg.gameObject.SetActive(false);
        //BlackPanel.gameObject.SetActive(false);
        for(int i=0; i<NormalImg.Length; i++)
            NormalImg[i].gameObject.SetActive(false);

        for(int i=0; i<ScoreStar.Length; i++){
            //ScoreStar[i].GetComponent<DifficultyStar>().OffStar();
            ScoreStar[i].gameObject.SetActive(false);
        }

    }
    public void OnGameEndingUI(int score){
        //BlackPanel.gameObject.SetActive(true);
        OnScoreStar(score);
        for(int i=0; i<NormalImg.Length; i++)
            NormalImg[i].gameObject.SetActive(true);

        if(GameManager.instance.isGameOver){
            GameOverImg.gameObject.SetActive(true);
        }
        else GameClearImg.gameObject.SetActive(true);
    }
    void OnGameOverImg(){
        GameOverImg.gameObject.SetActive(true);
    }
    void OnGameClearImg(){
        GameClearImg.gameObject.SetActive(true);
    }
    void OnScoreStar(int score){
        for(int i=0; i<3; i++){
            ScoreStar[i].gameObject.SetActive(true);
        }
        for(int i=0; i<score; i++){
            ScoreStar[i].GetComponent<DifficultyStar>().OnStar();
        }
    }
}
