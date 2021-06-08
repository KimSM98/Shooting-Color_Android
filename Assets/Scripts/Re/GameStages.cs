using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStages : MonoBehaviour
{
    public static GameStages instance;
    
    private int _StageNum = 1; // stage 0은 무한 모드. main씬에서 stage정보를 가져온다.
    private int[] _BossAppearanceCount;
    private int[][] _StageMonsterColor = new int[12][];
    private int[] _bossHP;

    void Awake()
    {
        instance = this;

        int stageNum = PlayerPrefs.GetInt("recentStage");
        setStageNum(stageNum);
        
        initializeStage();
    }

    // initialize function
    void initializeStage()
    {
        initializeMonsterNum();
        initializeStageMonsterColor();
        initializeBossHp();
    }

    void initializeMonsterNum()
    {
        _BossAppearanceCount = new int[] { -1, 15, 15, 20, 15, 25, 25, 25, 30, 30, 30, 50};
    }

    void initializeStageMonsterColor()
    {
        _StageMonsterColor[0] = new int[] { 1 };
        _StageMonsterColor[1] = new int[] { 1, 2, 4, 8, 16 };
        _StageMonsterColor[2] = new int[] { 1, 2, 4, 8, 16 };
        _StageMonsterColor[3] = new int[] { 1, 2, 4, 8, 16 };
        _StageMonsterColor[4] = new int[] { 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 16, 17, 18, 20, 24 };
        _StageMonsterColor[5] = new int[] { 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 16, 17, 18, 20, 24 };
        _StageMonsterColor[6] = new int[] { 3, 5, 6, 9, 10, 12, 17, 18, 20, 24 };
        _StageMonsterColor[7] = new int[] { 3, 5, 6, 9, 10, 12, 17, 18, 20, 24 };
        _StageMonsterColor[8] = new int[] { 3, 5, 9, 10, 17 };
        _StageMonsterColor[9] = new int[] { 2, 3, 6, 10, 18};
        _StageMonsterColor[10] = new int[] { 16, 17, 18, 20, 24 };
        _StageMonsterColor[11] = new int[] { 3, 5, 6, 9, 10, 12, 17, 18, 20, 24 };
    }

    void initializeBossHp()
    {
        _bossHP = new int[] { 0, 2, 3, 4, 3, 4, 4, 5, 5, 5, 5, 5};
    }

    // Setter
    void setStageNum(int num)
    {
        _StageNum = num;
    }

    // Getter
    public int getBossAppearanceCount()
    {
        return _BossAppearanceCount[_StageNum];
    }

    public int[] getStageMonsterColor()
    {
        return _StageMonsterColor[_StageNum];
    }

    public int getBossHp()
    {
        return _bossHP[_StageNum];
    }
}
