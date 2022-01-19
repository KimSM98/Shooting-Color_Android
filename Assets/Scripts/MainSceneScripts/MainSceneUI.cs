using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    public GameObject gameTitleGroup;
    public GameObject stageUIGroup;
    public GameObject scoreDisplay;

    public Text[] stageNumText;
    public Image leftBox;
    public Image rightBox;
    public Image leftArrow;
    public Image rightArrow;

    private bool isPlaying = false;
    private int _stageNum = 1;
    private int _StageNumMax = 11;
    // Components
    private StageData _StageData;
    private ScoreDisplay_Main _ScoreDisplay;

    void Start()
    {
        _StageData = GetComponent<GameData>().getStageData();
        _ScoreDisplay = scoreDisplay.GetComponent<ScoreDisplay_Main>();

        if(PlayerPrefs.HasKey("isPlaying"))
            isPlaying = (PlayerPrefs.GetInt("isPlaying") == 1) ? true : false;
        if(isPlaying)
            changeGameTitleToStageUI();

        initializeStageNum();

    }

    void initializeStageNum()
    {
        _stageNum = PlayerPrefs.GetInt("recentStage");

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

    void setStageNumText()
    {
        stageNumText[0].text = "" + (_stageNum - 1);
        stageNumText[1].text = "" + _stageNum;
        stageNumText[2].text = "" + (_stageNum + 1);
    }

    void changeStageNumText()
    {
        setStageNumText();

        stageNumText[0].gameObject.SetActive(true);
        stageNumText[2].gameObject.SetActive(true);

        leftBox.gameObject.SetActive(true);
        rightBox.gameObject.SetActive(true);
        leftArrow.gameObject.SetActive(true);
        rightArrow.gameObject.SetActive(true);

        if(_stageNum == 0)
        {
            stageNumText[1].text = "\u221E";
            stageNumText[0].gameObject.SetActive(false);
            leftBox.gameObject.SetActive(false);
            leftArrow.gameObject.SetActive(false);
            // 0이면 무한모드이기 때문에 스코어를 숫자로 표시 (별은 꺼놈)
        }
        else if(_stageNum == 1)
        {
            stageNumText[0].text = "\u221E";
        }
        else if(_stageNum == _StageNumMax)
        {
            stageNumText[2].gameObject.SetActive(false);
            rightBox.gameObject.SetActive(false);
            rightArrow.gameObject.SetActive(false);
        }
    }

    void changeStageScore()
    {
        int score = _StageData.getStageScore(_stageNum);

        if(_stageNum == 0)
            _ScoreDisplay.displayInfinityModeScore(score);
        else
            _ScoreDisplay.displayStarScore(score);
    }

    void playGame()
    {
        if(Time.timeScale == 0f)
            Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlayScene");
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
            playGame();
        }
    }
}
