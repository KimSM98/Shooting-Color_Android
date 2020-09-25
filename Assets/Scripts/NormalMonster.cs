using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonster : Monster
{
    public AnimatorOverrideController[] animController;
    public int colorNum;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void setObjInfo(AnimatorOverrideController _animController, int _colorNum){
        animator.runtimeAnimatorController = _animController;
        colorNum = _colorNum;
    }

}



