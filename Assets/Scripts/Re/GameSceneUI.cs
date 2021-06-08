using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    public Button pauseButton;
    public Button[] attackButtons; // pause state에서 눌리지 않는 버튼

    private GameSystem _GameSystem;
    private CommonUI _CommonUI;

    void Start()
    {
        _GameSystem = this.GetComponent<GameSystem>();
        _CommonUI = _GameSystem.GetComponent<CommonUI>();
    }

    public void powerButtonFunc()
    {
        _CommonUI.powerButtonFunc();

        if(Time.timeScale == 1f) // pause state가 아니면 
            Time.timeScale = 0f;

    }

    public void quitGame_Yes()
    {
        _CommonUI.quitGame_Yes();
    }

    public void quitGame_No()
    {
        _CommonUI.quitGame_No();

        if(_GameSystem.getGameState() != GameSystem.GameState.puase)
            Time.timeScale = 1f;
    }
    public void restartButtonFunc()
    {
        // 게임 씬 불러오기
        SceneManager.LoadScene("GamePlayScene");
    }

    public void pauseButtonFunc()
    {
        GameSystem.GameState gameState = _GameSystem.getGameState();
        
        if(gameState != GameSystem.GameState.puase)
        {
            disablingAttackButtons();
            pauseButton.GetComponent<ChangeButtonSprite>().changeSprite(1);
        }
        else
        {
            enablingAttackButtons();
            pauseButton.GetComponent<ChangeButtonSprite>().changeSprite(0);
        }
        
        _GameSystem.pauseGame();
    }

    private void disablingAttackButtons()
    {
        for(int i = 0; i < attackButtons.Length; i++)
        {
            attackButtons[i].image.raycastTarget = false;
        }
    }

    private void enablingAttackButtons()
    {
        for(int i = 0; i < attackButtons.Length; i++)
        {
            attackButtons[i].image.raycastTarget = true;
        }
    }

    public void homeButtonFunc()
    {
        // main scene 불러오기
        SceneManager.LoadScene("MainScreeScene");
    }
}
