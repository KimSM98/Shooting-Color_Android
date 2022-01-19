using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

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

    public float gameSpeed = 0.03f; // Default : 0.03f(PC) 0.095(Android)
    public GameObject specialAttackButtonGroup;
    public GameObject colorButtonGroup;
    public GameObject playerHpBar;
    public GameObject gameEndingGroup;
    public GameObject gameClearUIGroup;
    public GameObject gameOverUIGroup;

    private GameState _GameState;
    private GameState _PreviousGameState;
    private GameSceneUI _GameSceneUI;
    private HpBar _PlayerHpBarComponent;
    private int _MonsterKillCount = 0;
    private int _BossAppearanceCount = 0;
    private int _PlayerHP = 3;
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
        _GameSceneUI = GetComponent<GameSceneUI>();
        _GameState = GameState.inGame;
        _BossAppearanceCount = GameStages.instance.getBossAppearanceCount();
        initializeGameSpeed();
        initializePlayerHpBar();
    }

    void initializeGameSpeed()
    {
        gameSpeed *= GameStages.instance.getGameSpeedWeight();
    }

    void initializePlayerHpBar()
    {
        _PlayerHpBarComponent = playerHpBar.GetComponent<HpBar>();
        _PlayerHpBarComponent.setHp(_PlayerHP);
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

    // Game system
    public void increaseMonsterKillCount()
    {
        _MonsterKillCount++;
        updateMonsterKillCount();
        
        if(_MonsterKillCount == _BossAppearanceCount)
        {
            enterBossStageState();
        }

        bool isMultpleOfFive = (_MonsterKillCount % 5 == 0) ? true : false ;
        if(isMultpleOfFive)
            gameSpeed *= 1.1f;
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

    // Display
    void updateMonsterKillCount()
    {
        _GameSceneUI.updateMonsterKillCountText(_MonsterKillCount);
    }
    public void displayGameClearUI()
    {
        gameEndingGroup.SetActive(true);
        gameClearUIGroup.SetActive(true);
    }

    void displayGameOverUI()
    {
        gameEndingGroup.SetActive(true);
        gameOverUIGroup.SetActive(true);
    }

    // Game State Function
    void enterBossStageState()
    {
        setGameState(GameState.bossStage);

        BossScript.instance.gameObject.SetActive(true);
        
        // Buttons
        AttackButton.instance.hideAttackButton();
        colorButtonGroup.SetActive(false);
        specialAttackButtonGroup.SetActive(true);

        // Sound
        GameSound.instance.playBossAppearSound();
    }

    public void enterGameClearState()
    {
        if(_GameState != GameState.gameOver)
        {
            setGameState(GameState.gameClear);

            displayGameClearUI();

            _Score = _PlayerHP;
            _GameSceneUI.displayStarScore(_Score);

            saveScore();

            // Sound
            GameSound.instance.playGameClearSound();
        }
    }

    public void enterGameOverState()
    {
        if(_GameState != GameState.gameClear)
        {
            setGameState(GameState.gameOver);

            displayGameOverUI();

            if(GameStages.instance.getStageNum() == 0)
            {
                _Score = _MonsterKillCount;
                saveScore();
            }

            // Sound
            GameSound.instance.playGameOverSound();

            // Attack Buttons
            AttackButton.instance.disablingButtons();
        }
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
