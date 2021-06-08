using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = -0.1f;

    public int Hp { get; set; }
    public int ColorNum;
    private Vector2 firstPos;
    
    public Enemy()
    {
        Hp = 1;
        
        //speed = 0.1f;
    }
    void Start()
    {
        firstPos = this.transform.position;
    }

    virtual public void Attacked()
    {
        Hp -= 1;
        if(Hp == 0){
            GetComponent<Animator>().SetTrigger("Dead");
        }
    }

    public virtual void Move()
    {
        if (this.transform.position.x > -3.3f)
            this.transform.Translate(speed*GameManager.instance.Speed*Time.timeScale, 0, 0);
        else{
            ResetObj();
        }
            
    }

    public void ResetObj(){        
        Hp=1;
        gameObject.SetActive(false);
        if(!GameManager.instance.isGameOver){
            transform.position = firstPos;
            EnemyManagerScript.instance.SpawnEnemy();//스폰은 애니메이션 끝나고
            gameObject.SetActive(true);     
        }         
    }

    public int GetColorNum(){
        return ColorNum;
    }
    public void SetColorNum(int num){
        ColorNum = num;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player")){
            if(Hp > 0){
                coll.GetComponent<Player>().Attacked();
                GameManager.instance.DecreaseMonsterNum();
                //Debug.Log("플레이어랑 부딪힘");
            }               
        }
    }
    
}
