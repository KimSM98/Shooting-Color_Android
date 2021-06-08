using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;

    public enum GameState
    {
        puase,
        inGame,
        bossStage,
        gameOver,
        gameClear
    }

    public float gameSpeed = 0.025f;
    public GameObject specialAttackButtonGroup;
    public GameObject colorButtonGroup;
    public GameObject playerHpBar;
    public GameObject gameEndingGroup;
    public GameObject gameClearUIGroup;
    public GameObject gameOverUIGroup;
    public Image[] scoreImage;
    public Text monsterKillCountText;
    public Text bossAppearanceCountText;

    private GameState _GameState;
    private GameState _PreviousGameState;
    private int _MonsterKillCount = 0;
    private int _BossAppearanceCount = 0;
    private int _PlayerHP = 3;
    private HpBar _PlayerHpBarComponent;
    private int _Score = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        initialize();
    }

    // Initialization
    void initialize()
    {
        _GameState = GameState.inGame;

        initializePlayerHpBar();
        initializeTexts();
    }

    void initializePlayerHpBar()
    {
        _PlayerHpBarComponent = playerHpBar.GetComponent<HpBar>();
        _PlayerHpBarComponent.setHp(_PlayerHP);
    }

    void initializeTexts()
    {
        _BossAppearanceCount = GameStages.instance.getBossAppearanceCount();
        bossAppearanceCountText.text = "" + _BossAppearanceCount;
        monsterKillCountText.text = "" + 0;
    }

    // Setter
    public void setGameState(GameState gamestate)
    {
        _GameState = gamestate;
    }

    // Getter
    public GameState getGameState()
    {
        return _GameState;
    }

    // function
    public void increaseMonsterKillCount()
    {
        _MonsterKillCount++;
        updateMonsterKillCountText();
        
        if(_MonsterKillCount >= _BossAppearanceCount)
        {
            enterBossStageState();
        }
    }

    public void decreasePlayerHp()
    {
        _PlayerHP--;
        _PlayerHpBarComponent.decreaseHpUI();            

        if(_PlayerHP <= 0)
        {
            PlayerScript.instance.playDeadAnimation();
            enterGameOverState();
        }
        else
            PlayerScript.instance.playAttakedAnimation();

    }

    void updateMonsterKillCountText()
    {
        monsterKillCountText.text = "" + _MonsterKillCount;
    }

    void saveScore()
    {
        if(PlayerPrefs.GetInt("needsToSaveScore") == 1)
        {
            int previousScore = PlayerPrefs.GetInt("score");
            _Score = (_Score > previousScore) ? _Score : previousScore;
        }
        PlayerPrefs.SetInt("score", _Score);
        PlayerPrefs.SetInt("needsToSaveScore", 1);
        Debug.Log("needs to save from game scene " + PlayerPrefs.GetInt("needsToSaveScore"));
    }
    // Game State Function
    void enterBossStageState()
    {
        _GameState = GameState.bossStage;

        BossScript.instance.gameObject.SetActive(true);
        
        // Buttons
        AttackButton.instance.hideAttackButton();
        colorButtonGroup.SetActive(false);
        specialAttackButtonGroup.SetActive(true);
    }

    public void enterGameClearState()
    {
        setGameState(GameState.gameClear);
        displayGameClearUI();

        
        saveScore();
    }

    public void enterGameOverState()
    {
        setGameState(GameState.gameOver);
        displayGameOverUI();
    }
    
    public void displayGameClearUI()
    {
        gameEndingGroup.SetActive(true);
        gameClearUIGroup.SetActive(true);
        
        _Score = _PlayerHP;
        for(int i = 0; i < _Score; i++)
        {
            scoreImage[i].gameObject.SetActive(true);
        }
    }
    void displayGameOverUI()
    {
        gameEndingGroup.SetActive(true);
        gameOverUIGroup.SetActive(true);
    }
    public void pauseGame() // Pause Button function
    {
        if(_GameState != GameState.puase)
        {
            Time.timeScale = 0;
            _PreviousGameState = _GameState;
            setGameState(GameState.puase);
        }
        else
        {
            Time.timeScale = 1f;
            setGameState(_PreviousGameState);
        }
    }
}
