using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackEffect : MonoBehaviour
{
    public void PlayAttackEffectAnimation()
    {
        GetComponent<Animator>().SetTrigger("Attacked");
    }
}
