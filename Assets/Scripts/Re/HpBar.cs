using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public GameObject[] HpUIObjects;
    private int _Hp;

    public void decreaseHpUI(){
        if(_Hp > 0)
        {
            _Hp--;
            HpUIObjects[_Hp].SetActive(false);
        }
    }

    public void setHp(int num)
    {
        _Hp = num;

        int arrLength = HpUIObjects.Length;
        if(arrLength != _Hp)
        {
            for(int i = _Hp; i < arrLength; i++)
            {
                HpUIObjects[i].SetActive(false);
            }
        }
    }
}
