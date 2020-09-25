using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : Enemy
{
    public static Boss instance;
    public AnimatorOverrideController[] AnimController;
    //public int Hp;
    private int Hp;
    public GameObject HpBar;

    Animator BossAnim;
    bool isBossDead;
    public Boss(){
        //Hp = GameManager.instance.GetBossHP();
    }
    void Start()
    {
        isBossDead = false;
        Hp = GameManager.instance.GetBossHP();//0619
        HpBar.GetComponent<HpBar>().SetHp(Hp);        
        Debug.Log("boss" + Hp);

        instance = this;
        BossAnim = new Animator();
        BossAnim = GetComponent<Animator>();

        SetAnim();
        gameObject.SetActive(false);
        /*int ranNum = Random.Range(0,AnimController.Length);
        BossAnim.runtimeAnimatorController = AnimController[ranNum];
        */
    }
    private void SetAnim(){
        int ranNum = Random.Range(0,AnimController.Length);
        BossAnim.runtimeAnimatorController = AnimController[ranNum];
    }
    
    public override void Move(){
        this.transform.Translate(speed*GameManager.instance.Speed*Time.timeScale, 0, 0);            
        
    }
    public override void Attacked()
    {
        Hp -= 1;
        HpBar.GetComponent<HpBar>().OffHpItem();//0901

        if(Hp == 0){
            GetComponent<Animator>().SetTrigger("Dead");
            GameManager.instance.GameClear();
            isBossDead = true;
        }
        AttackManagerScript.instance.DecreaseStarNum(isBossDead);
    }
    public void OffObj(){
        gameObject.SetActive(false);
    }

    public int GetBossHp(){
        return Hp;
    }

}
