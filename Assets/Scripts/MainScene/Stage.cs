using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage : MonoBehaviour
{
    public Text StageNumText;
    int stageNum {get;set;}
    // Start is called before the first frame update
    void Awake()
    {
        //List<Dictionary<string, object>>data = CSVReader.Read("StageScoreCSV");
    }
    public void SetStageNum(int num){
        stageNum = num;
        StageNumText.text = num.ToString();
    }
}
