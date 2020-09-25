using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;
    public int hp;

    private Vector2 firstPos;
    private bool isMove = false;

    void Start()
    {
        firstPos = this.transform.position;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player")){
            Debug.Log("player와 부딪힘");
        }
        else if(coll.CompareTag("AttackEffect")){
            //if ColorNum이 같으면 
            Debug.Log("Attacked");
        }
    }

    public void Move(){
        if (this.transform.position.x < -2.9f){
            isMove = false;
            //오브젝트 원래 자리로
        }

        while(isMove){
            this.transform.Translate(speed*GameManager.instance.Speed*Time.timeScale, 0, 0);
        }
    }

    public void ResetObj(){        
        hp=1;
        gameObject.SetActive(false);
        transform.position = firstPos;
        //0616
        EnemyManagerScript.instance.SpawnEnemy();//스폰은 애니메이션 끝나고
        gameObject.SetActive(true);     

    }

}

