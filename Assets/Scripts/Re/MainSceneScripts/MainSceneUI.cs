using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    public GameObject gameTitleGroup;
    public GameObject stageUIGroup;

    public Text[] stageNumText;
    public Image leftBox;
    public Image rightBox;
    public Image leftArrow;
    public Image rightArrow;
    public Image[] scoreStars;

    private bool isPlaying = false;
    private int _stageNum = 1;
    private StageData _StageData;
    private int _StageNumMax = 11;

    void Start()
    {
        _StageData = GetComponent<GameData>().getStageData();

        Debug.Log("is Playing " + PlayerPrefs.GetInt("isPlaying"));
        if(PlayerPrefs.HasKey("isPlaying"))
            isPlaying = (PlayerPrefs.GetInt("isPlaying") == 1) ? true : false;
        if(isPlaying)
            changeGameTitleToStageUI();

        initializeStageNum();
    }

    void initializeStageNum()
    {
        _stageNum = PlayerPrefs.GetInt("recentStage");
        Debug.Log("Stage Num : " + _stageNum);

        changeStageNumText();
        changeStageScore();
    }

    void changeGameTitleToStageUI()
    {
        gameTitleGroup.SetActive(false);
        stageUIGroup.SetActive(true);
    }

    void pressAnyButtonFunc()
    {
        changeGameTitleToStageUI();

        isPlaying = true;
    }

    void changeStageNumText()
    {
        stageNumText[0].text = "" + (_stageNum - 1);
        stageNumText[1].text = "" + _stageNum;
        stageNumText[2].text = "" + (_stageNum + 1);
        
        if(_stageNum == 0)
        {
            stageNumText[0].gameObject.SetActive(false);
            leftBox.gameObject.SetActive(false);
            leftArrow.gameObject.SetActive(false);
            // 0이면 무한모드이기 때문에 스코어를 숫자로 표시 (별은 꺼놈)
        }
        else if(_stageNum == _StageNumMax)
        {
            stageNumText[2].gameObject.SetActive(false);
            rightBox.gameObject.SetActive(false);
            rightArrow.gameObject.SetActive(false);
        }
        else
        {
            stageNumText[0].gameObject.SetActive(true);
            stageNumText[2].gameObject.SetActive(true);

            leftBox.gameObject.SetActive(true);
            rightBox.gameObject.SetActive(true);
            leftArrow.gameObject.SetActive(true);
            rightArrow.gameObject.SetActive(true);
        }
    }

    void changeStageScore()
    {
        int score = _StageData.getStageScore(_stageNum);

        for(int i = 0; i < score; i++)
        {
            scoreStars[i].gameObject.SetActive(true);
        }

        for(int i = 2; i > score - 1; i--)
        {
            scoreStars[i].gameObject.SetActive(false);
        }
    }

// Button Functions
    public void LeftButtonFunc()
    {
        if(!isPlaying)
        {
            pressAnyButtonFunc();
        }
        else
        {
            if(_stageNum > 0)
            {
                _stageNum--;
                changeStageNumText();
                changeStageScore();
            }
        }
    }

    public void RightButtonFunc()
    {
        if(!isPlaying)
        {
            pressAnyButtonFunc();
        }
        else
        {
            if(_stageNum < _StageNumMax)
            {
                _stageNum++;
                changeStageNumText();
                changeStageScore();
            }
        }
    }

    public void OKButtonFunc()
    {
        if(!isPlaying)
        {
            pressAnyButtonFunc();
        }
        else // 일반적인 OK의 기능
        {
            PlayerPrefs.SetInt("isPlaying", 1);
            PlayerPrefs.SetInt("recentStage", _stageNum);
            SceneManager.LoadScene("GamePlayScene");
        }
    }
}
