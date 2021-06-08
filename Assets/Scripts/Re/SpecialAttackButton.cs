using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackButton : MonoBehaviour
{   
    private ChangeButtonSprite _ButtonSpriteComponent;
    private bool isPressd = false;

    void Start()
    {
        _ButtonSpriteComponent = GetComponent<ChangeButtonSprite>();
    }

    public void hideButton() // Boss Attack
    {
        if(!isPressd)
        {
            _ButtonSpriteComponent.changeSprite(0);
            isPressd = true;
            BossScript.instance.attackBoss();
        }
    }
}
