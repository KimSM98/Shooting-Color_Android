using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : MonoBehaviour
{
    public Sprite[] HpItemImg;
    
    public void OnHpItem(){
        GetComponent<SpriteRenderer>().sprite = HpItemImg[1];
    }
    public void OffHpItem(){
        GetComponent<SpriteRenderer>().sprite = HpItemImg[0];
    }
}
