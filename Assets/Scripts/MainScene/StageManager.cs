using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public Image[] StageButton;
    public Image[] DirectionPivot;
    public Image[] Star;//StageScoreImg
    public int lastStageNum;

    bool IsStageScreen;

    private int pivotNum;
    private int temp_PivotNum;
    void Start()
    {
        IsStageScreen = false;
        if(!PlayerPrefs.HasKey("RecentStage")){
            PlayerPrefs.SetInt("RecentStage", 0);
        }
        pivotNum = PlayerPrefs.GetInt("RecentStage");
        
        //ErrorText.text = "" + pivotNum.ToString();
        SetStage();
    }
    
    void SetStage(){
        temp_PivotNum = pivotNum;    
        SetScoreStar();

        if(pivotNum==0){
            StageButton[0].gameObject.SetActive(false);
            DirectionPivot[0].gameObject.SetActive(false);
        }
        else if(pivotNum==lastStageNum){
            StageButton[2].gameObject.SetActive(false);            
            DirectionPivot[1].gameObject.SetActive(false);
        }
        else{
            StageButton[0].gameObject.SetActive(true);
            StageButton[2].gameObject.SetActive(true);
            DirectionPivot[0].gameObject.SetActive(true);
            DirectionPivot[1].gameObject.SetActive(true);
        }

        for(int i=0; i<3; i++){
            StageButton[i].GetComponent<Stage>().SetStageNum(temp_PivotNum);
            temp_PivotNum++;
        }
        
    }
    void SetScoreStar(){
        int stageScore = StageController.instance.GetStageScore(pivotNum);
        
        for(int i=0; i<3; i++){            
            if(i < stageScore)
                Star[i].GetComponent<DifficultyStar>().OnStar();
            else
                Star[i].GetComponent<DifficultyStar>().OffStar();
        }
    }

    public void MoveNext(){
        if(IsStageScreen == true && pivotNum < lastStageNum){
            pivotNum++;
            SetStage();
        }
    }
    public void MovePrevious(){
        if(IsStageScreen == true && pivotNum > 0){
            pivotNum--;
            SetStage();
        }
    }

    public void SetIsStage(bool state){
        IsStageScreen = state;
    }
    public void SelectStage(){
        int gameSceneNum = PlayerPrefs.GetInt("MainScene");

        if(gameSceneNum > 0){
            if(IsStageScreen == true){
                PlayerPrefs.SetInt("RecentStage", pivotNum);
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
