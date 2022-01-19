using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Json file name : stageData.json
    // 0: 무한모드, 
    public int NumOfStages = 12;
    public StageData _StageData;
    
    private bool needsToSaveScore = false;

    void Awake()
    {
        //PlayerPrefs.DeleteAll();

        bool hasPlayedGame = PlayerPrefs.HasKey("recentStage");
        if(!hasPlayedGame)
        {
            initializeGameSetting();
            initializeStageData();
        }
        
        loadStageData();

        if(PlayerPrefs.HasKey("needsToSaveScore"))
        {
            needsToSaveScore = (PlayerPrefs.GetInt("needsToSaveScore") == 1) ? true : false;
            if(needsToSaveScore)
                savePreviousScore();
        }        
    }

    void savePreviousScore()
    {
        int stageNum = PlayerPrefs.GetInt("recentStage");
        int score = PlayerPrefs.GetInt("score");    

        if(_StageData.getStageScore(stageNum) < score)
        {
            _StageData.setStageScore(stageNum, score);
            saveStageData();  
            
            PlayerPrefs.SetInt("needsToSaveScore", 0);
            PlayerPrefs.SetInt("score", 0);
        }
    }

    void loadStageData()
    {
        _StageData = loadDataFromJson<StageData>("stageData");
    }

    void saveStageData()
    {
        saveDataToJson<StageData>(_StageData, "stageData");
    }

    void initializeGameSetting()
    {
        PlayerPrefs.SetInt("recentStage", 1);
        PlayerPrefs.SetInt("needsToSaveScore", 0);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("isSoundOn", 1);
    }

    void initializeStageData()
    {
        _StageData = new StageData();
        _StageData.StageScore = new int[NumOfStages];

        _StageData.initializeScores();
        saveDataToJson<StageData>(_StageData, "stageData");
    }

    public StageData getStageData()
    {
        return _StageData;
    }

// Save & Load Data Function
    [ContextMenu("To Json Data")]
    public void saveDataToJson<T>(T dataToSave, string dataFileName)
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
    public T loadDataFromJson<T>(string dataFileName)
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
    
}

[System.Serializable]
public class StageData
{
    public int[] StageScore;
    public void initializeScores()
    {
        for(int i = 0; i < StageScore.Length; i++)
        {
            StageScore[i] = 0;
        }
    }

    public void setStageScore(int stageNum, int score)
    {
        StageScore[stageNum] = score;
    }
    public int getStageScore(int stageNum)
    {
        return StageScore[stageNum];
    }
}