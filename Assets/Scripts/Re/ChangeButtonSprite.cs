using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonSprite : MonoBehaviour
{
    public Sprite[] buttonSprites;

    private Image _ButtonImage;

    void Start()
    {
        _ButtonImage = GetComponent<Button>().image;
    }

    public void changeSprite(int num)
    {
        _ButtonImage.sprite = buttonSprites[num];
    }
}
