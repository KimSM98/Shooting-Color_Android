using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    //_SpriteComponent.changeSprite(num) | num 0 : Not Pressed Img, 1 : Pressed Img
    public int color = 0;

    private bool _IsPressed = false;
    private Image _ButtonImage;
    private ChangeButtonSprite _SpriteComponent;

    void Start()
    {
        _SpriteComponent = GetComponent<ChangeButtonSprite>();
    }

    public void pressButton()
    {
        if(!_IsPressed && AttackButton.instance.getPressedButtonCount() < 2)
        {
            AttackButton.instance.addColorNum(color);
            AttackButton.instance.addPressedButtonCount(1);
            _IsPressed = true;
            _SpriteComponent.changeSprite(1);
        }
        else if(_IsPressed)
        {
            AttackButton.instance.addColorNum(color * -1);
            AttackButton.instance.addPressedButtonCount(-1);
            _IsPressed = false;
            _SpriteComponent.changeSprite(0);
        }
        
        AttackButton.instance.changeSprite();
    }

    public void initialize()
    {
        _IsPressed = false;
        _SpriteComponent.changeSprite(0);
    }
}
