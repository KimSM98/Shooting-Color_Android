using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    bool isSave;
    void Start()
    {
        isSave = PlayerPrefs.HasKey("RecentStage");
        //isSave = false; //Reset
        if(!isSave){//처음 실행
            Debug.Log("처음 실행");
            StageController.instance.SetStage();

            for(int i=1; i < 11; i++){//사용x
                PlayerPrefs.SetInt(i.ToString(), 0);
            }
            PlayerPrefs.SetInt("RecentStage", 0);
        }   
        
        Time.timeScale = 1;    
        
    }    

}
