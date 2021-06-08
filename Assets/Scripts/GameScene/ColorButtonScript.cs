using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButtonScript : MonoBehaviour
{
    public int ArrayNum;
    public int ButtonColorNum;
    private bool isPushed = false;

    // public void GetButtonColor()
    // {
    //     if(Time.timeScale != 0 && !GameManager.instance.isGameOver){//Not Pause situation
    //         if(AttackManagerScript.instance.PushedButtonNum <2 && isPushed != true){//최대 2개 누를 수 있고, 선택된 것은 작동 x
    //         isPushed = true;
    //         AttackManagerScript.instance.PushColorButton(ButtonColorNum, ArrayNum);
            
    //         }//다시 누르면 뗌
    //         else if(AttackManagerScript.instance.PushedButtonNum>0 && isPushed == true){
    //             isPushed = false;
    //             AttackManagerScript.instance.releaseColorButton(ButtonColorNum,ArrayNum);
    //         }
    //         AttackManagerScript.instance.ChangeMSBSprite();
    //     }
        
    // }
    public void SetIsPushed(bool boolean){
        isPushed = boolean;
    }
    
}
