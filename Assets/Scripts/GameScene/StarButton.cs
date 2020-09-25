using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarButton : MonoBehaviour
{

    public void OffObj(){
        if(GameManager.instance.isBossMove == true)
            gameObject.SetActive(false);
    }
}
