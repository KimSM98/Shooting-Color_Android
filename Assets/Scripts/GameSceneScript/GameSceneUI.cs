using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    public Text monsterKillCountText;
    public Text bossAppearanceCountText;

    private ScoreStarDisplay _ScoreStarDisplay;

    void Start()
    {
        _ScoreStarDisplay = GetComponent<ScoreStarDisplay>();

        initializeTexts();
    }

    void initializeTexts()
    {
        int stageNum = GameStages.instance.getStageNum();
        if(stageNum == 0)
        {
            bossAppearanceCountText.text = "\u221E";
        }
        else
        {
            int _BossAppearanceCount = GameStages.instance.getBossAppearanceCount();
            bossAppearanceCountText.text = "" + _BossAppearanceCount;            
        }

        monsterKillCountText.text = "" + 0;
    }

    public void updateMonsterKillCountText(int count)
    {
        monsterKillCountText.text = "" + count;
    }

    public void displayStarScore(int score)
    {
        _ScoreStarDisplay.displayStarScore(score);
    }
}
