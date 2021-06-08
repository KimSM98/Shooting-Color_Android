using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    void Awake()
    {
        instance = this;
    }
    
    public void AttackAnim()
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }

    public void playAttakedAnimation()
    {
        GetComponent<Animator>().SetTrigger("IsAttacked");
    }

    public void playDeadAnimation()
    {
        GetComponent<Animator>().SetTrigger("IsDead");
    }
}
