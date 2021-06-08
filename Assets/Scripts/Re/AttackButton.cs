using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    // Boss Stage에서 별 버튼 등장
    public static AttackButton instance;

    public Button[] colorButtons;
    public Sprite[] attackButtonSpr;

    private Image _ButtonImage;
    private int _Color = 0;
    private int _PressedButtonCount = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _ButtonImage = GetComponent<Button>().image;
        gameObject.SetActive(false);
    }

    void initializeAttackProcess()
    {
        _Color = 0;
        _PressedButtonCount = 0;

        for(int i = 0; i < colorButtons.Length; i++)
        {
            colorButtons[i].GetComponent<ColorButton>().initialize();
        }
    }

    public void Attack()
    {
        PlayerScript.instance.AttackAnim();
        AttackEffect.instance.startAttackAnim(_Color);

        initializeAttackProcess();

        gameObject.SetActive(false);
    }   

    public void changeSprite()
    {
        if(_Color != 0)
        {
            _ButtonImage.sprite = attackButtonSpr[_Color];
            gameObject.SetActive(true);
        }
        else
            gameObject.SetActive(false);
    }

    // Getter
    public int getPressedButtonCount()
    {
        return _PressedButtonCount;
    }

    public void addColorNum(int num)
    {
        _Color += num;
    }

    public void addPressedButtonCount(int num)
    {
        _PressedButtonCount += num;
    }

    public void hideAttackButton()
    {
        gameObject.SetActive(false);
    }

}
