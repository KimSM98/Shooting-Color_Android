using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private GameSystem _GameSystem;
    private AttackButton _AttackButton;

    void Start()
    {
        _GameSystem = GameSystem.instance;
        _AttackButton = AttackButton.instance;
    }

    public void pauseButtonFunc()
    {
        GameSystem.GameState gameState = _GameSystem.getGameState();
        
        if(gameState != GameSystem.GameState.puase)
        {
            _AttackButton.disablingButtons();
            GetComponent<ChangeButtonSprite>().changeSprite(1);
        }
        else
        {
            _AttackButton.enablingButtons();
            GetComponent<ChangeButtonSprite>().changeSprite(0);
        }
        
        _GameSystem.pauseGame();
    }
}
