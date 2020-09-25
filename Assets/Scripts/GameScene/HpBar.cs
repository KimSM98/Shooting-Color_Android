using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public int Hp;
    public GameObject[] HpItem;

    void Start()
    {
        
    }

    public void SetHp(int num){
        Hp = num;
        for(int i=Hp; i < 5; i++){
            HpItem[i].SetActive(false);
        }
    }

    public void OffHpItem(){
        Hp--;
        HpItem[Hp].GetComponent<HpItem>().OffHpItem();
        //Hp--;
    }
}
