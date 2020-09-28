                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using UnityEngine.UI;
public class StageController : MonoBehaviour
{  
    public static StageController instance;
    public StageData stageData;
    bool isSave;
    void Awake()
    {
        instance = this;        

        isSave = PlayerPrefs.HasKey("RecentStage");
        //isSave = false; //Reset
        if(!isSave){//처음 실행
            Debug.Log("처음 실행");
            SetStage();//create save data 
        }   
        else stageData = loadData<StageData>("stageData");

        if(PlayerPrefs.HasKey("CurrentScore")){
            Debug.Log("전 스테이지의 점수가 있습니다.");
            int stageNum = PlayerPrefs.GetInt("RecentStage");
            int score = PlayerPrefs.GetInt("CurrentScore");
            SaveStageScore(stageNum, score);
            PlayerPrefs.DeleteKey("CurrentScore");//key지워줌
        }
        Time.timeScale = 1;  
    }

    [ContextMenu("To Json Data")]
    public void saveData<T>(T dataToSave, string dataFileName)
    {
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".json");

        //Convert To Json then to bytes
        string jsonData = JsonUtility.ToJson(dataToSave, true);
        byte[] jsonByte = Encoding.ASCII.GetBytes(jsonData);

        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        }
        //Debug.Log(path);

        try
        {
            File.WriteAllBytes(tempPath, jsonByte);
            Debug.Log("Saved Data to: " + tempPath.Replace("/", "\\"));
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To PlayerInfo Data to: " + tempPath.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }
    }

    [ContextMenu("From Json Data")]
    public T loadData<T>(string dataFileName)
    {
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".json");

        //Exit if Directory or File does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Debug.LogWarning("Directory does not exist");
            return default(T);
        }

        if (!File.Exists(tempPath))
        {
            Debug.Log("File does not exist");
            return default(T);
        }

        //Load saved Json
        byte[] jsonByte = null;
        try
        {
            jsonByte = File.ReadAllBytes(tempPath);
            Debug.Log("Loaded Data from: " + tempPath.Replace("/", "\\"));
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To Load Data from: " + tempPath.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }

        //Convert to json string
        string jsonData = Encoding.ASCII.GetString(jsonByte);

        //Convert to Object
        object resultValue = JsonUtility.FromJson<T>(jsonData);
        return (T)Convert.ChangeType(resultValue, typeof(T));
    }
    
    public int GetStageScore(int stageNum){
        return stageData.GetScore(stageNum);
    }
    public void SaveStageScore(int stageNum, int score){
        if(score > stageData.GetScore(stageNum)){
            stageData.Save(stageNum, score);
            saveData(stageData, "stageData");
            stageData = loadData<StageData>("stageData");
        }
    }

    public void SetStage(){
        stageData = new StageData();
        stageData.SetStageScore();
        saveData(stageData, "stageData");
    }
   
}
[System.Serializable]
public class StageData
{
    public int[] StageScores = new int[11];//0925이쪽이 현재 문제
    
    public void Save(int stageNum, int score){
        StageScores[stageNum] = score;
    }
    public int GetScore(int stageNum){
        return StageScores[stageNum];
    }
    public void SetStageScore(){
        for(int i=0; i < StageScores.Length; i++)
            StageScores[i] = 0;
    }
}
